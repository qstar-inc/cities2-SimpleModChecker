using System;
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


namespace SimpleModCheckerPlus.Systems
{
    public class ModVerifier
    {
        public static string Header = "Mod Verification Result will appear here.";
        public static string Progress = "";
        public static int ModCount = 0;
        public static string IssueList = "";
        public static int ProcesStatus = 0;
        public static Dictionary<string, string> DownloadedModList = new();
        public static List<string> DupedModList = new();
        public static int RemovedBackupCIDs = 0;
        public static int SkippedBackupCIDs = 0;
        public static Dictionary<string, Dictionary<string, string>> ManifestData = new();
        public static List<string> backupsToCheck = new();
        public static string translateKey = $"{Mod.Id}.Verify";
        public static LocalizedString VerificationResultText => GetText();

        private static readonly Regex CsvRegex =
            new(@"(?:^|,)(?:(?:""(?<value>[^""]*)"")|(?<value>[^,""]*))",
                RegexOptions.Compiled);

        public static LocalizedString GetText()
        {
            if (ProcesStatus == 0)
            {
                return Header;
            }
            else if (ProcesStatus == 1)
            {
                return $"{Header}\n{Progress}\n{IssueList}";
            }
            else if (ProcesStatus == 2)
            {
                return $"{Header}\n{IssueList}";
            }
            else
            {
                return $"{Header}\n{IssueList}";
            }
        }

        public static void IssueTextHeader(string modId, string modName)
        {
            if (modId == modName)
            {
                IssueList += $"<{modId}>:\n";
            }
            else
            {
                IssueList += $"<{modId}> {modName}:\n";
            }
        }

        public static void RemoveBackupCID()
        {
            try
            {
                string rootFolder = EnvPath.kCacheDataPath + "/Mods/mods_subscribed";
                if (!Directory.Exists(rootFolder))
                {
                    return;
                }

                foreach (
                    var subfolder in Directory
                        .GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
                        .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]))
                )
                {
                    string modFolder = Path.GetFileName(subfolder);
                    string metadataFile = Path.Combine(subfolder, ".metadata", "metadata.json");

                    string[] modFolderParts = modFolder.Split('_');
                    if (modFolderParts.Length != 2)
                    {
                        continue;
                    }

                    if (subfolder != null)
                    {
                        try
                        {
                            CheckForBackupCID(subfolder);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog(
                                $"Error verifying files in '{subfolder}': {ex.Message}"
                            );
                        }
                    }
                }

                foreach (var filePath in backupsToCheck)
                {
                    string subfolder =
                        $"{EnvPath.kCacheDataPath}/Mods/mods_subscribed/{filePath.Replace(EnvPath.kCacheDataPath, "").Replace("\\", "/").Replace("/Mods/mods_subscribed/", "").Split('/')[0]}";

                    string relativePath = GetRelativePath(subfolder, filePath).Replace("/", "\\");
                    string manifestPath = FindManifestFile(subfolder);
                    if (string.IsNullOrEmpty(manifestPath))
                    {
                        LogHelper.SendLog($"No manifestPath found for subfolder: {subfolder}");
                        continue;
                    }

                    Dictionary<string, string> manifestData;

                    try
                    {
                        manifestData = ReadManifestFile(manifestPath);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.SendLog(
                            $"Error reading manifest at '{manifestPath}': {ex.Message}"
                        );
                        continue;
                    }

                    if (!manifestData.ContainsKey(relativePath))
                    {
                        File.Delete(filePath);
                        RemovedBackupCIDs++;
                        LogHelper.SendLog($"Deleted '{relativePath}'.");
                    }
                    else
                    {
                        SkippedBackupCIDs++;
                        //Mod.log.Info($"Skipped '{relativePath}'.");
                    }
                }

                LogHelper.SendLog(
                    $"Backup CIDs: Removed {RemovedBackupCIDs}; Ignored {SkippedBackupCIDs}"
                );
                Mod.Setting.DeletedBackupCIDs = true;
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex.ToString());
            }
        }

        public static async Task VerifyMods(string selected = null)
        {
            ManifestData.Clear();
            DownloadedModList.Clear();
            DupedModList.Clear();
            IssueList = "";

            // mark when Verify run starts (UTC), log time elapsed at the end
            var verifyStartUtc = DateTime.UtcNow;
            LogHelper.SendLog($"[Verify] START {verifyStartUtc:O}  selected={(selected ?? "ALL")}");

            NotificationSystem.Push(
                "starq-smc-verify-mod",
                title: Mod.Name,
                text: LocaleHelper.Translate($"{translateKey}.Starting"),
                progressState: ProgressState.Indeterminate,
                onClicked: () =>
                {
                    ModCheckup.uISystem.OpenPage($"{Mod.Id}.{Mod.Id}.Mod", "VerifyTab", false);
                }
            );

            Header = LocaleHelper.Translate($"{translateKey}.Header.Running");
            ProcesStatus = 1;
            Mod.Setting.VerifiedRecently = true;
            if (selected != null)
            {
                LogHelper.SendLog($"Starting Mod Verification for {selected}");
            }
            else
            {
                LogHelper.SendLog("Starting Mod Verification (all subscribed mods)");
            }
            string rootFolder = EnvPath.kCacheDataPath + "/Mods/mods_subscribed";
            if (!Directory.Exists(rootFolder))
            {
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
                Header = LocaleHelper.Translate($"{translateKey}.Header.Failed");
                IssueList = LocaleHelper.Translate($"{translateKey}.Issue.NoModsSubscribed");
                ProcesStatus = 3;
                LogHelper.SendLog("Mod Verification Process failed, no `mods_subscribed'");
                return;
            }

            string selectedModName = "";
            string selectedModFolder = "";
            ModCount =
                selected != null
                    ? 1
                    : Directory
                        .GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
                        .Length;
            int i = 0;

            foreach (
                var subfolder in Directory
                    .GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
                    .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]))
            )
            {
                if (selected != null && subfolder != selected)
                {
                    continue;
                }
                i++;
                float percent = i / (float)ModCount * 100;
                bool posted = false;

                string modFolder = Path.GetFileName(subfolder);

                string metadataFile = Path.Combine(subfolder, ".metadata", "metadata.json");

                string multiText = LocaleHelper.Translate($"{translateKey}.Issue.MultiText");

                string[] modFolderParts = modFolder.Split('_');
                string modId = "";
                string modVersion = "";
                string modName = modId;
                if (modFolderParts.Length == 2)
                {
                    modId = modFolderParts[0];
                    modVersion = modFolderParts[1];

                    modName = modId;
                    try
                    {
                        string jsonContent = File.ReadAllText(metadataFile);
                        JObject jsonObject = JObject.Parse(jsonContent);
                        if (jsonObject["DisplayName"] != null)
                        {
                            modName = jsonObject["DisplayName"].ToString();
                            selectedModName = modName;
                            selectedModFolder = modFolder;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.SendLog("Error: " + ex.Message);
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
                                { "ModName", LocalizedString.Value(modName.ToString()) },
                            }
                        ),
                        progressState: ProgressState.Progressing,
                        progress: (int)Math.Round(percent)
                    );

                    if (DownloadedModList.ContainsKey(modId) && !DupedModList.Contains(modId))
                    {
                        if (!posted)
                        {
                            IssueTextHeader(modId, modName);
                            posted = true;
                        }
                        IssueList += multiText;
                        if (!DupedModList.Contains(modId))
                        {
                            LogHelper.SendLog($"{multiText.Replace("\n", "")}: {modId}");
                            DupedModList.Add(modId);
                        }
                    }
                    else
                    {
                        DownloadedModList.Add(modId, modVersion);
                    }
                }
                else
                {
                    continue;
                }
                Progress = (LocaleHelper.Translate($"{translateKey}.Progress.Processing"))
                    .Replace("{I}", $"{new LocalizedNumber<int>(i).value}")
                    .Replace("{ModName}", modName)
                    .Replace("{ModCount}", $"{new LocalizedNumber<int>(ModCount).value}");

                string manifestPath = FindManifestFile(subfolder);
                if (string.IsNullOrEmpty(manifestPath))
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += LocaleHelper.Translate($"{translateKey}.Issue.NoManifest");
                    LogHelper.SendLog($"No manifest found for subfolder: {subfolder}");
                    continue;
                }

                Dictionary<string, string> manifestData;

                try
                {
                    manifestData = ReadManifestFile(manifestPath);
                    //foreach (var item in manifestData)
                    //{
                    //    Mod.log.Info($"{item.Key} : {item.Value}");
                    //}
                }
                catch (Exception ex)
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += LocaleHelper.Translate($"{translateKey}.Issue.ErrorManifest");
                    LogHelper.SendLog($"Error reading manifest at '{manifestPath}': {ex.Message}");
                    continue;
                }

                //string modFolder = subfolder;
                if (subfolder != null)
                {
                    try
                    {
                        await VerifyFolderFiles(subfolder, manifestData, modId, modName, posted);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.SendLog($"Error verifying files in '{subfolder}': {ex.Message}");
                    }
                }
            }
            ProcesStatus = 2;
            LogHelper.SendLog("Completed Mod Verification");

            // Compute + log elapsed time for the whole Verify run (real time)
            var verifyEndUtc = DateTime.UtcNow;
            var verifyElapsed = verifyEndUtc - verifyStartUtc;
            LogHelper.SendLog($"[Verify] END   {verifyEndUtc:O}  elapsed={verifyElapsed}");

            // UI line shows time elapsed for Verify to complete
            Header = $"{LocaleHelper.Translate($"{translateKey}.Header.End")} — Elapsed: {verifyElapsed:mm\\:ss\\.f}";


            //Mod.log.Info(IssueList);
            ProgressState hasIssue = ProgressState.Complete;
            if (IssueList != "")
            {
                hasIssue = ProgressState.Warning;
            }
            else
            {
                IssueList = LocaleHelper.Translate($"{translateKey}.Issue.NoIssue");
                if (selected != null)
                {
                    IssueList += $"\n{selectedModName} ({selectedModFolder})";
                }
            }
            NotificationSystem.Push(
                "starq-smc-verify-mod",
                title: Mod.Name,
                text: LocaleHelper.Translate($"{translateKey}.End"),
                progressState: hasIssue,
                onClicked: () =>
                {
                    NotificationSystem.Pop("starq-smc-verify-mod");
                    ModCheckup.uISystem.OpenPage(
                        $"{Mod.Id}.{Mod.Id}.Mod",
                        "Setting.ModListTab",
                        false
                    );
                }
            );
            if (selected != null)
            {
                Mod.Setting.VerifiedRecently = false;
            }
        }

        private static string FindManifestFile(string subfolder)
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
                    {
                        return manifestPath;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Error searching for manifest in '.cpatch': {ex.Message}");
            }

            return null;
        }

        private static Dictionary<string, string> ReadManifestFile(string manifestPath)
        {

            if (ManifestData.ContainsKey(manifestPath))
            {
                return ManifestData[manifestPath];
            }

            var manifestData = new Dictionary<string, string>(StringComparer.Ordinal);

            try
            {
                // Stream lines to keep memory flat; parse with compiled regex; normalize keys once
                foreach (var line in File.ReadLines(manifestPath))
                {
                    var matches = CsvRegex.Matches(line);
                    var parts = matches.Cast<Match>().Select(m => m.Groups["value"].Value).ToList();

                    if (parts.Count >= 4)
                    {
                        string relativePath = parts[0].Trim('"').Replace("/", "\\"); // normalize slashes/quotes
                        string size = parts[1];
                        string hash = parts[2];
                        manifestData[relativePath] = $"{size};;{hash}";
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Failed to read manifest file: {ex}", LogLevel.Error);
            }

            ManifestData[manifestPath] = manifestData;
            return manifestData;
        }

        private static async Task VerifyFolderFiles(
            string subfolder,
            Dictionary<string, string> manifestData,
            string modId,
            string modName,
            bool posted
        )
        {
            if (!Directory.Exists(subfolder))
                return;


            var files = Directory.EnumerateFiles(subfolder, "*", SearchOption.AllDirectories)
                .Where(file => !file.Contains(".metadata") && !file.Contains(".cpatch"));

            foreach (var filePath in files)
            {
                string relativePath = GetRelativePath(subfolder, filePath).Replace("/", "\\");
                string relativePathForText = $"**{relativePath.Replace("\\", "/")}**";
                try
                {
                    // fetch manifest entry if present (keys are normalized already)
                    if (manifestData.TryGetValue(relativePath, out var entry))
                    {

                        string[] manifestParts = entry.Split(new string[] { ";;" }, StringSplitOptions.None);
                        string expectedSize = manifestParts[0];
                        string expectedHash = manifestParts[1];

                        long actualSize = new FileInfo(filePath).Length;

                        // EARLY OUT: size mismatch => mark dirty, do NOT hash
                        if (!string.Equals(expectedSize, actualSize.ToString(), StringComparison.Ordinal))
                        {
                            if (!posted)
                            {
                                IssueTextHeader(modId, modName);
                                posted = true;
                            }
                            IssueList += LocaleHelper
                                .Translate($"{translateKey}.Issue.Dirty")
                                .Replace("{RelativePath}", relativePathForText);
                            LogHelper.SendLog(
                                $"File '{relativePath}' size mismatch. Expected: {expectedSize} bytes, Found: {actualSize} bytes");

                            manifestData.Remove(relativePath);
                            continue;
                        }

                        // Size matched => compute hash one pass
                        string actualHash = await ComputeSHA256Hash(filePath);

                        if (!string.Equals(expectedHash, actualHash, StringComparison.Ordinal))
                        {
                            if (!posted)
                            {
                                IssueTextHeader(modId, modName);
                                posted = true;
                            }
                            IssueList += LocaleHelper
                                .Translate($"{translateKey}.Issue.Dirty")
                                .Replace("{RelativePath}", relativePathForText);
                            LogHelper.SendLog(
                                $"File '{relativePath}' hash mismatch. Expected: {expectedHash}, Found: {actualHash} ({actualSize} bytes)");
                        }

                        manifestData.Remove(relativePath);
                    }
                    else if (!filePath.EndsWith(".backup"))
                    {
                        if (!posted)
                        {
                            IssueTextHeader(modId, modName);
                            posted = true;
                        }
                        IssueList += LocaleHelper
                            .Translate($"{translateKey}.Issue.Foreign")
                            .Replace("{RelativePath}", relativePathForText);
                        LogHelper.SendLog($"File '{relativePath}' is not listed in the manifest.");
                    }
                    else if (filePath.EndsWith(".backup"))
                    {
                        string realFilePath = filePath[..^7];
                        relativePath = GetRelativePath(subfolder, realFilePath).Replace("/", "\\");
                        relativePathForText = relativePath.Replace("\\", "/");

                        string actualCid = File.Exists(realFilePath)
                            ? File.ReadAllText(realFilePath)
                            : "";

                        string backupCid = File.Exists(filePath) ? File.ReadAllText(filePath) : "";

                        if (actualCid != backupCid)
                        {
                            if (!posted)
                            {
                                IssueTextHeader(modId, modName);
                                posted = true;
                            }
                            IssueList += LocaleHelper
                                .Translate($"{translateKey}.Issue.CIDMismatch")
                                .Replace("{RelativePath}", relativePathForText);
                            LogHelper.SendLog(
                                $"Value of '{relativePath}' does not match with the backup."
                            );
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += LocaleHelper
                        .Translate($"{translateKey}.Issue.AccessDenied")
                                    .Replace("{RelativePath}", relativePathForText);
                    LogHelper.SendLog($"Access denied to file '{filePath}'. Skipping.");
                }
                catch (Exception ex)
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += LocaleHelper
                        .Translate($"{translateKey}.Issue.UnknownError")
                        .Replace("{RelativePath}", relativePathForText);
                    LogHelper.SendLog($"Error processing file '{filePath}': {ex.Message}");
                }
            }

            foreach (var missingFile in manifestData)
            {
                string relativePath = missingFile.Key;
                if (!posted)
                {
                    IssueTextHeader(modId, modName);
                    posted = true;
                }
                IssueList += LocaleHelper
                    .Translate($"{translateKey}.Issue.Missing")
                                .Replace("{RelativePath}", $"**{relativePath.Replace("\\", "/")}**");
                LogHelper.SendLog(
                                $"File '{relativePath}' is listed in the manifest but missing from the folder."
                            );
            }
        }

        private static void CheckForBackupCID(string subfolder)
        {
            if (!Directory.Exists(subfolder))
                return;

            var files = Directory
                .GetFiles(subfolder, "*", SearchOption.AllDirectories)
                .Where(file =>
                    !file.Contains(".metadata")
                    && !file.Contains(".cpatch")
                    && file.Contains(".cid.backup")
                );

            foreach (var filePath in files)
            {
                try
                {
                    if (filePath.EndsWith(".backup"))
                        backupsToCheck.Add(filePath);
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog($"Error processing file '{filePath}': {ex.Message}");
                }
            }
        }

        private static async Task<string> ComputeSHA256Hash(string filePath)
        {
            try
            {
                filePath = AddLongPathPrefix(filePath);
                using var sha256 = SHA256.Create();

                const int BufferSize = 1 << 20; // larger 1 MiB reads: fewer I/O calls
                using var stream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read,
                    BufferSize,
                    FileOptions.Asynchronous | FileOptions.SequentialScan   // sequential to prefetch efficiently
                );

                byte[] buffer = new byte[BufferSize];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    sha256.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                }

                sha256.TransformFinalBlock(Array.Empty<byte>(), 0, 0);

                return Convert.ToBase64String(sha256.Hash!).Replace("/", "_").Replace("+", "-");
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

        private static string AddLongPathPrefix(string path)
        {
            if (path.StartsWith(@"\\?\"))
                return path;
            return @"\\?\" + Path.GetFullPath(path);
        }

        private static string GetRelativePath(string basePath, string fullPath)
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
