using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Game.PSI;
using Game.UI.Localization;
using Newtonsoft.Json.Linq;
using StarQ.Shared.Extensions;
using UnityEngine;

namespace SimpleModCheckerPlus.Systems
{
    public class ModVerifier
    {
        public static string translateKey = $"{Mod.Id}.Verify";
        public static string Header = LocaleHelper.Translate($"{translateKey}.Header.WillAppear");
        public static string Progress = "";
        public static int ModCount = 0;
        public static int donePercent = 0;

        //public static string IssueList = "";
        public static int ProcesStatus = 0;
        public static DateTime verifyStartUtc;
        public static List<int> DownloadedModList = new();
        public static List<int> DupedModList = new();
        public static Dictionary<string, Dictionary<string, string>> ManifestData = new();
        private static readonly object _issueListLock = new();
        private static List<int> ModsById;
        public static LocalizedString VerificationResultText => GetText();

        private static readonly Regex csvRegex = new(
            @"(?:^|,)(?:(?:""(?<value>[^""]*)"")|(?<value>[^,""]*))",
            RegexOptions.Compiled
        );

        private static bool NoModsSubscribed = false;

        private static readonly SortedDictionary<ModData, List<ModIssues>> ModDataIssues = new();
        private static readonly SortedList<int, int> ModWithOldSDK = new();
        private static readonly List<string> MetadataOldFormat = new();

        public class ModData : IComparable<ModData>
        {
            public int modId;
            public string modName;
            public string modVersion;

            public int CompareTo(ModData other)
            {
                if (other == null)
                    return 1;

                return modId.CompareTo(other.modId);
            }

            public override bool Equals(object obj)
            {
                if (obj is not ModData other)
                    return false;
                return modId == other.modId;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(modId, modName, modVersion);
            }
        }

        public class ModIssues
        {
            public IssueType issueType;
            public string filePath;
        }

        public enum IssueType
        {
            None,
            Dirty,
            Foreign,
            MultipleVersion,
            CIDMismatch,
            AccessDenied,
            UnknownError,
            Missing,
            NoManifest,
            ErrorManifest,
        }

        private static LocalizedString GetText()
        {
            return ProcesStatus switch
            {
                0 => Header,
                1 => $"{Header}\n- {ExtraText()}\n{Progress}",
                2 => $"{Header}\n{GetIssueText()}",
                _ => $"{Header}\n{GetIssueText()}",
            };
        }

        private static string GetIssueText()
        {
            if (NoModsSubscribed)
                return LocaleHelper.Translate($"{translateKey}.Issue.NoModsSubscribed");

            string finalText = string.Empty;
            if (
                ModDataIssues.Count == 0
                && ModWithOldSDK.Count == 0
                && MetadataOldFormat.Count == 0
            )
                return LocaleHelper.Translate($"{translateKey}.Issue.NoIssue");

            foreach (var x in ModDataIssues.ToList())
            {
                ModData modData = x.Key;
                List<ModIssues> issues = x.Value;
                string currentHeader =
                    modData.modId.ToString() == modData.modName
                        ? $"<{modData.modId}>"
                        : $"<{modData.modId}> {modData.modName}";

                string issueText = string.Empty;
                foreach (var item in issues)
                {
                    issueText += $"- <{item.issueType}>: **{item.filePath}**\n";
                }

                finalText += $"{currentHeader}:\n{issueText}\n";
            }

            if (ModWithOldSDK.Count > 0)
            {
                finalText = "Mods with old metadata.json Format: ";
                foreach (var x in ModWithOldSDK.ToList())
                    finalText += $"{x.Key}, ";

                finalText = finalText.TrimEnd(' ', ',');
            }

            if (MetadataOldFormat.Count > 0)
            {
                finalText = "Old metadata.json Format:";
                foreach (var x in MetadataOldFormat.ToList())
                    finalText += $"\n{x}".Replace("\\", "/").Replace("/", "/\u200B");
            }

            return finalText.TrimEnd();
        }

        public static string ExtraText() =>
            $" {donePercent}% {LocaleHelper.Translate($"{translateKey}.Complete")} | {LocaleHelper.Translate($"{translateKey}.Elapsed")} {DateTime.UtcNow - verifyStartUtc:hh\\:mm\\:ss}";

        private static readonly int[] RegionPackIds = new int[]
        {
            91930, // French Pack
            91931, // German Pack
            92859, // UK Pack
            94094, // Japan Pack
            98960, // Eastern Europe Pack
            100454, // China Pack
            101898, // USA Southwest Pack
            101948, // USA Northeast Pack
            121130, // Netherlands Pack
        };

        public enum ProcessType
        {
            All,
            Selected,
            NoRP,
            ActivePlayset,
            //CheckMetadataFormat,
        }

        public static async Task VerifyMods(ProcessType pt, string selected = null)
        {
            ModDataIssues.Clear();
            ManifestData.Clear();
            DownloadedModList.Clear();
            DupedModList.Clear();

            verifyStartUtc = DateTime.UtcNow;
            LogHelper.SendLog(
                $"[Verify] START {verifyStartUtc:O} selected={(selected ?? "ALL")}",
                LogLevel.DEV
            );

            NotificationSystem.Push(
                "starq-smc-verify-mod",
                title: Mod.Name,
                text: LocaleHelper.Translate($"{translateKey}.Starting"),
                progressState: ProgressState.Indeterminate,
                onClicked: () =>
                    ModCheckup.uISystem.OpenPage($"{Mod.Id}.{Mod.Id}.Mod", "VerifyTab", false)
            );

            Header = LocaleHelper.Translate($"{translateKey}.Header.Running");
            ProcesStatus = 1;
            Mod.m_Setting.VerifyRunning = true;

            string rootFolder = EnvPath.kCacheDataPath + "/Mods/mods_subscribed";
            if (!Directory.Exists(rootFolder))
            {
                Header = LocaleHelper.Translate($"{translateKey}.Header.Failed");
                NoModsSubscribed = true;
                ProcesStatus = 3;
                NotificationSystem.Push(
                    "starq-smc-verify-mod",
                    title: Mod.Name,
                    text: LocaleHelper.Translate($"{translateKey}.Failed"),
                    progressState: ProgressState.Failed,
                    onClicked: () =>
                    {
                        ModCheckup.uISystem.OpenPage(
                            $"{Mod.Id}.{Mod.Id}.Mod",
                            "Setting.VerifyTab",
                            false
                        );
                        NotificationSystem.Pop("starq-smc-verify-mod");
                    }
                );
                LogHelper.SendLog("Mod Verification Process failed, no `mods_subscribed'");
                return;
            }

            var modFolders =
                selected == null
                    ? Directory
                        .GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
                        .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]))
                        .ToArray()
                    : new string[] { selected };

            ModCount = pt == ProcessType.NoRP ? modFolders.Length - 7 : modFolders.Length;
            ModsById = new();

            switch (pt)
            {
                case ProcessType.NoRP:
                    ModCount = modFolders.Length - 7;
                    break;
                case ProcessType.ActivePlayset:
                    ModCount = ModCheckup.allMods.Count;
                    ModsById = ModCheckup.allMods.Values.Select(m => m.Id).ToList();
                    break;
            }
            int i = 0;

            foreach (var subfolder in modFolders)
            {
                if (selected != null && subfolder != selected)
                    continue;

                string modFolder = Path.GetFileName(subfolder);

                string metadataFile = Path.Combine(subfolder, ".metadata", "metadata.json");

                string[] modFolderParts = modFolder.Split('_');
                if (modFolderParts.Length != 2)
                    continue;

                ModData modData = new()
                {
                    modId = int.Parse(modFolderParts[0]),
                    modName = modFolderParts[0],
                    modVersion = modFolderParts[1],
                };

                List<ModIssues> issues = new();

                if (pt == ProcessType.NoRP && RegionPackIds.Contains(modData.modId))
                    continue;

                if (pt == ProcessType.ActivePlayset && !ModsById.Contains(modData.modId))
                    continue;

                i++;
                int percent = (int)Math.Round(i / (float)ModCount * 100);
                donePercent = percent;

                try
                {
                    if (File.Exists(metadataFile))
                    {
                        JObject jsonObject = JObject.Parse(
                            await File.ReadAllTextAsync(metadataFile)
                        );
                        //if (pt == ProcessType.CheckMetadataFormat)
                        //{
                        //    if (jsonObject["displayName"] == null)
                        //    {
                        //        MetadataOldFormat.Add(metadataFile);
                        //        //ModWithOldSDK.Add(modData.modId, modData.modId);
                        //    }

                        //    continue;
                        //}
                        modData.modName =
                            jsonObject["DisplayName"]?.ToString()
                            ?? jsonObject["displayName"]?.ToString()
                            ?? modData.modId.ToString();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog("Error reading metadata: " + ex.Message);
                }

                NotificationSystem.Push(
                    "starq-smc-verify-mod",
                    title: Mod.Name,
                    text: new LocalizedString(
                        $"{translateKey}.Running",
                        null,
                        new Dictionary<string, ILocElement>
                        {
                            { "I", new LocalizedNumber<int>(i) },
                            { "ModCount", new LocalizedNumber<int>(ModCount) },
                            { "ModName", LocalizedString.Value(modData.modName) },
                        }
                    ),
                    progressState: ProgressState.Progressing,
                    progress: percent
                );

                if (
                    DownloadedModList.Contains(modData.modId)
                    && DupedModList.All(d => d != modData.modId)
                )
                    issues.Add(new() { issueType = IssueType.MultipleVersion });
                else
                    DownloadedModList.Add(modData.modId);

                Progress = LocaleHelper
                    .Translate($"{translateKey}.Progress.Processing")
                    .Replace("{I}", $"{new LocalizedNumber<int>(i).value}")
                    .Replace("{ModName}", modData.modName)
                    .Replace("{ModCount}", $"{new LocalizedNumber<int>(ModCount).value}");

                string manifestPath = FindManifestFile(subfolder);
                if (string.IsNullOrEmpty(manifestPath))
                {
                    issues.Add(new ModIssues() { issueType = IssueType.NoManifest });
                    //LogHelper.SendLog($"No manifest found for subfolder: {subfolder}");
                    continue;
                }

                Dictionary<string, string> manifestData;

                try
                {
                    manifestData = ReadManifestFile(manifestPath);
                }
                catch (Exception ex)
                {
                    issues.Add(new ModIssues() { issueType = IssueType.ErrorManifest });
                    LogHelper.SendLog($"Error reading manifest at '{manifestPath}': {ex.Message}");
                    continue;
                }

                try
                {
                    await Task.Run(() =>
                        VerifyFolderFilesParallel(subfolder, manifestData, issues)
                    );
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog($"Error verifying files in '{subfolder}': {ex.Message}");
                }
                if (issues.Count > 0)
                    ModDataIssues.Add(modData, issues);
            }
            ProcesStatus = 2;
            var verifyElapsed = DateTime.UtcNow - verifyStartUtc;
            LogHelper.SendLog($"Completed Mod Verification in {verifyElapsed}");
            LogHelper.SendLog(GetIssueText());

            //if (pt == ProcessType.CheckMetadataFormat && MetadataOldFormat.Count > 0)
            //{
            //    string notifPrefix = $"{Mod.Id}.Cleanup";
            //    NotificationSystem.Push(
            //        "starq-smc-cleanup-restart",
            //        title: new LocalizedString($"{notifPrefix}.Title", null, null),
            //        text: LocalizedString.Id($"{notifPrefix}.Desc"),
            //        onClicked: () =>
            //        {
            //            NotificationSystem.Pop("starq-smc-coc-restart");
            //            Application.Quit(0);
            //        }
            //    );
            //    foreach (var item in MetadataOldFormat)
            //        File.Delete(item);
            //}

            Header =
                $"{LocaleHelper.Translate($"{translateKey}.Header.End")} ({ModCount} mods) | {LocaleHelper.Translate($"{translateKey}.TimeTaken")}: {verifyElapsed:hh\\:mm\\:ss}";

            ProgressState hasIssue =
                (ModDataIssues.Count > 0 || ModWithOldSDK.Count > 0 || MetadataOldFormat.Count > 0)
                    ? ProgressState.Warning
                    : ProgressState.Complete;

            NotificationSystem.Push(
                "starq-smc-verify-mod",
                title: Mod.Name,
                text: LocaleHelper.Translate($"{translateKey}.End"),
                progressState: hasIssue,
                onClicked: () =>
                {
                    NotificationSystem.Pop("starq-smc-verify-mod");
                    ModCheckup.uISystem.OpenPage($"{Mod.Id}.{Mod.Id}.Mod", "VerifyTab", false);
                }
            );
            Mod.m_Setting.VerifyRunning = false;
        }

        public static string FindManifestFile(string subfolder)
        {
            string cpatchFolder = Path.Combine(subfolder, ".cpatch");
            if (!Directory.Exists(cpatchFolder))
                return null;
            try
            {
                string folderName = Path.GetFileName(Path.GetDirectoryName(cpatchFolder));
                if (folderName == null || !folderName.Contains("_"))
                    return null;

                string version = folderName.Split('_')[1];

                var randomFolders = Directory.GetDirectories(
                    cpatchFolder,
                    "*",
                    SearchOption.TopDirectoryOnly
                );

                foreach (var folder in randomFolders)
                {
                    string manifestPath = Path.Combine(folder, version, "complete", "manifest");
                    if (File.Exists(manifestPath))
                        return manifestPath;
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Error searching for manifest in '.cpatch': {ex.Message}");
            }

            return null;
        }

        public static Dictionary<string, string> ReadManifestFile(string manifestPath)
        {
            if (ManifestData.TryGetValue(manifestPath, out var cached))
                return cached;

            var manifestData = new Dictionary<string, string>(StringComparer.Ordinal);

            foreach (var line in File.ReadLines(manifestPath))
            {
                var parts = csvRegex
                    .Matches(line)
                    .Cast<Match>()
                    .Select(m => m.Groups["value"].Value)
                    .ToList();

                if (parts.Count >= 4)
                {
                    string relativePath = parts[0].Trim('"').Replace("/", "\\");
                    string size = parts[1];
                    string hash = parts[2];
                    manifestData[relativePath] = $"{size};;{hash}";
                }
            }

            ManifestData[manifestPath] = manifestData;
            return manifestData;
        }

        private static void VerifyFolderFilesParallel(
            string subfolder,
            Dictionary<string, string> manifestData,
            List<ModIssues> issues
        )
        {
            if (!Directory.Exists(subfolder))
                return;

            var concurrentIssues = new ConcurrentBag<ModIssues>();

            var files = Directory
                .EnumerateFiles(subfolder, "*", SearchOption.AllDirectories)
                .Where(file => !file.Contains(".metadata") && !file.Contains(".cpatch"))
                .ToArray();

            Parallel.ForEach(
                files,
                filePath =>
                {
                    string relativePath = GetRelativePath(subfolder, filePath).Replace("/", "\\");
                    string relativePathForText = $"{relativePath.Replace("\\", "/")}";
                    try
                    {
                        if (manifestData.TryGetValue(relativePath, out var entry))
                        {
                            string[] manifestParts = entry.Split(
                                new string[] { ";;" },
                                StringSplitOptions.None
                            );
                            string expectedSize = manifestParts[0];
                            string expectedHash = manifestParts[1];

                            long actualSize = new FileInfo(filePath).Length;

                            if (
                                !string.Equals(
                                    expectedSize,
                                    actualSize.ToString(),
                                    StringComparison.Ordinal
                                )
                            )
                            {
                                lock (_issueListLock)
                                {
                                    concurrentIssues.Add(
                                        new ModIssues()
                                        {
                                            issueType = IssueType.Dirty,
                                            filePath = relativePathForText.Replace("/", "/\u200B"),
                                        }
                                    );
                                    //LogHelper.SendLog(
                                    //    $"File '{relativePath}' size mismatch. Expected: {expectedSize} bytes, Found: {actualSize} bytes",
                                    //    LogLevel.DEV
                                    //);
                                }

                                manifestData.Remove(relativePath);
                                return;
                            }

                            string actualHash = ComputeSHA256HashSync(filePath);

                            if (!string.Equals(expectedHash, actualHash, StringComparison.Ordinal))
                            {
                                lock (_issueListLock)
                                {
                                    concurrentIssues.Add(
                                        new ModIssues()
                                        {
                                            issueType = IssueType.Dirty,
                                            filePath = relativePathForText.Replace("/", "/\u200B"),
                                        }
                                    );
                                    //LogHelper.SendLog(
                                    //    $"File '{relativePath}' hash mismatch. Expected: {expectedHash}, Found: {actualHash} ({actualSize} bytes)",
                                    //    LogLevel.DEV
                                    //);
                                }
                            }

                            manifestData.Remove(relativePath);
                        }
                        else if (!filePath.EndsWith(".backup"))
                        {
                            lock (_issueListLock)
                            {
                                concurrentIssues.Add(
                                    new ModIssues()
                                    {
                                        issueType = IssueType.Foreign,
                                        filePath = relativePathForText.Replace("/", "/\u200B"),
                                    }
                                );
                                //LogHelper.SendLog(
                                //    $"File '{relativePath}' is not listed in the manifest.",
                                //    LogLevel.DEV
                                //);
                            }
                        }
                        else if (filePath.EndsWith(".backup"))
                        {
                            string realFilePath = filePath[..^7];
                            relativePath = GetRelativePath(subfolder, realFilePath)
                                .Replace("/", "\\");
                            relativePathForText = relativePath.Replace("\\", "/");

                            string actualCid = File.Exists(realFilePath)
                                ? File.ReadAllText(realFilePath)
                                : "";

                            string backupCid = File.Exists(filePath)
                                ? File.ReadAllText(filePath)
                                : "";

                            if (actualCid != backupCid)
                            {
                                lock (_issueListLock)
                                {
                                    concurrentIssues.Add(
                                        new ModIssues()
                                        {
                                            issueType = IssueType.CIDMismatch,
                                            filePath = relativePathForText.Replace("/", "/\u200B"),
                                        }
                                    );
                                    //LogHelper.SendLog(
                                    //    $"Value of '{relativePath}' does not match with the backup.",
                                    //    LogLevel.DEV
                                    //);
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        lock (_issueListLock)
                        {
                            concurrentIssues.Add(
                                new ModIssues()
                                {
                                    issueType = IssueType.AccessDenied,
                                    filePath = relativePathForText.Replace("/", "/\u200B"),
                                }
                            );
                            //LogHelper.SendLog($"Access denied to file '{filePath}'. Skipping.");
                        }
                    }
                    catch (Exception ex)
                    {
                        lock (_issueListLock)
                        {
                            concurrentIssues.Add(
                                new ModIssues()
                                {
                                    issueType = IssueType.UnknownError,
                                    filePath = relativePathForText.Replace("/", "/\u200B"),
                                }
                            );
                            LogHelper.SendLog($"Error processing file '{filePath}': {ex.Message}");
                        }
                    }
                }
            );

            foreach (var missingFile in manifestData)
            {
                string relativePath = missingFile.Key;
                lock (_issueListLock)
                {
                    concurrentIssues.Add(
                        new ModIssues()
                        {
                            issueType = IssueType.Missing,
                            filePath = relativePath.Replace("/", "/\u200B"),
                        }
                    );
                    //LogHelper.SendLog(
                    //    $"File '{relativePath}' is listed in the manifest but missing from the folder.",
                    //    LogLevel.DEV
                    //);
                }
            }
            issues.AddRange(concurrentIssues);
        }

        private static string ComputeSHA256HashSync(string filePath)
        {
            try
            {
                filePath = AddLongPathPrefix(filePath);
                using var sha256 = SHA256.Create();

                using var stream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read,
                    1 << 20,
                    FileOptions.SequentialScan
                );

                byte[] hash = sha256.ComputeHash(stream);

                return Convert.ToBase64String(hash).Replace("/", "_").Replace("+", "-");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException($"Access to file '{filePath}' is denied.");
            }
            catch (IOException ex)
            {
                throw new IOException(
                    $"Error computing SHA256 for file '{filePath}': {ex.Message}",
                    ex
                );
            }
        }

        private static string AddLongPathPrefix(string path) =>
            path.StartsWith(@"\\?\") ? path : @"\\?\" + Path.GetFullPath(path);

        public static string GetRelativePath(string basePath, string fullPath)
        {
            try
            {
                Uri baseUri = new(
                    basePath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar
                );
                Uri fullUri = new(fullPath);
                return Uri.UnescapeDataString(
                    baseUri
                        .MakeRelativeUri(fullUri)
                        .ToString()
                        .Replace('/', Path.DirectorySeparatorChar)
                );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Failed to compute relative path for '{fullPath}': {ex.Message}",
                    ex
                );
            }
        }
    }
}
