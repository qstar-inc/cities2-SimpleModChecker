// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.PSI;
using Game.UI.Localization;
using Newtonsoft.Json.Linq;
using SimpleModCheckerPlus;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;

namespace SimpleModChecker.Systems
{
    public class ModVerifier
    {
        public static string Header = "Mod Verification Result will appear here.";
        public static string Progress = "";
        public static int ModCount = 0;
        public static string IssueList = "";
        public static int ProcesStatus = 0;
        public static Dictionary<string, string> DownloadedModList = [];
        public static List<string> DupedModList = [];
        public static LocalizedString VerificationResultText => LocalizedString.Id(GetText());

        public static string GetText()
        {
            if (ProcesStatus == 0)
            {
                return Header;
            }
            else if (ProcesStatus == 1)
            {
                return $"{Header}\r\n{Progress}\r\n{IssueList}";
            }
            else if (ProcesStatus == 2)
            {
                return $"{Header}\r\n{IssueList}";
            }
            else
            {
                return $"{Header}\r\n{IssueList}";
            }
        }

        public static void IssueTextHeader(string modId, string modName)
        {
            if (modId == modName)
            {
                IssueList += $"<{modId}>:\r\n";
            }
            else
            {
                IssueList += $"<{modId}> {modName}:\r\n";
            }
        }


        public static async Task VerifyMods(string selected = null)
        {
            NotificationSystem.Push("starq-smc-verify-mod",
                titleId: "SimpleModCheckerPlus",
                textId: "SimpleModCheckerPlus.VerifyStart",
                progressState: Colossal.PSI.Common.ProgressState.Indeterminate,
                onClicked: () => {
                    ModCheckup.uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false);
                });


            Header = $"Mod Verification Process is running...";
            ProcesStatus = 1;
            Mod.Setting.VerifiedRecently = true;
            Mod.log.Info("Starting Mod Verification");
            string rootFolder = EnvPath.kCacheDataPath + "/Mods/mods_subscribed";
            if (!Directory.Exists(rootFolder))
            {
                NotificationSystem.Push("starq-smc-verify-mod",
                    titleId: "SimpleModCheckerPlus",
                    textId: "SimpleModCheckerPlus.VerifyFailed",
                    progressState: Colossal.PSI.Common.ProgressState.Failed,
                    onClicked: () => {
                        ModCheckup.uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false); 
                        NotificationSystem.Pop("starq-smc-verify-mod");
                    }
                );
                Header = $"Mod Verification Process failed!";
                IssueList = "\'mods_subscribed\' does not exist";
                ProcesStatus = 3;
                Mod.log.Info(Header);
                return;
            }

            ModCount = selected != null ? 1 : Directory.GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly).Length;
            int i = 0;

            foreach (var subfolder in Directory.GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
                                   .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0])))
            {
                if (selected != null && subfolder != selected)
                {
                    continue;
                }
                i++;
                float percent = (i/ (float)ModCount) * 100;
                bool posted = false;

                string modFolder = Path.GetFileName(subfolder);

                string metadataFile = Path.Combine(subfolder, ".metadata", "metadata.json");

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
                        }
                    }
                    catch (Exception ex)
                    {
                        Mod.log.Info("Error: " + ex.Message);
                    }

                    NotificationSystem.Push("starq-smc-verify-mod",
                        titleId: "SimpleModCheckerPlus",
                        text: new LocalizedString("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.VerifyingMods]", null,
                            new Dictionary<string, ILocElement>
                            {
                                {"modCount", LocalizedString.Value(i.ToString())},
                                {"total", LocalizedString.Value(ModCount.ToString())},
                                {"modName", LocalizedString.Value(modName.ToString())},
                            }),
                        progressState: Colossal.PSI.Common.ProgressState.Progressing,
                        progress: (int)Math.Round(percent)
                        );

                    if (DownloadedModList.ContainsKey(modId) && !DupedModList.Contains(modId))
                    {
                        if (!posted)
                        {
                            IssueTextHeader(modId, modName);
                            posted = true;
                        }
                        IssueList += "- Multiple versions of the same mod downloaded.\r\n";
                        DupedModList.Add(modId);
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
                Progress = $"- {i} ({modName}) out of {ModCount} mods processing...";

                string cpatchFolder = Path.Combine(subfolder, ".cpatch");
                if (!Directory.Exists(cpatchFolder))
                    continue;

                string manifestPath = FindManifestFile(cpatchFolder);
                if (string.IsNullOrEmpty(manifestPath))
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += $"- No manifest found\r\n";
                    Mod.log.Info($"No manifest found for subfolder: {subfolder}");
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
                    IssueList += $"- Error reading manifest\r\n";
                    Mod.log.Info($"Error reading manifest at '{manifestPath}': {ex.Message}");
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
                        Mod.log.Info($"Error verifying files in '{subfolder}': {ex.Message}");
                    }
                }
            }
            ProcesStatus = 2;
            Header = "Mod Verification Process is complete";
            Mod.log.Info("Completed Mod Verification");
            //Mod.log.Info(IssueList);
            Colossal.PSI.Common.ProgressState hasIssue = Colossal.PSI.Common.ProgressState.Complete;
            if (IssueList != "")
            {
                hasIssue = Colossal.PSI.Common.ProgressState.Warning;
            }
            else
            {
                IssueList = "No issues found";
            }
            NotificationSystem.Push("starq-smc-verify-mod",
                titleId: "SimpleModCheckerPlus",
                textId: "SimpleModCheckerPlus.VerifyEnd",
                progressState: hasIssue,
                onClicked: () => {
                    NotificationSystem.Pop("starq-smc-verify-mod");
                    ModCheckup.uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false);
                }
            );
            if (selected != null)
            {
                Mod.Setting.VerifiedRecently = false;
            }
        }

        private static string FindManifestFile(string cpatchFolder)
        {
            try
            {
                string folderName = Path.GetFileName(Path.GetDirectoryName(cpatchFolder));
                Mod.log.Info(folderName);
                if (folderName == null || !folderName.Contains("_")) return null;

                string version = folderName.Split('_')[1];
                Mod.log.Info(version);

                var randomFolders = Directory.GetDirectories(cpatchFolder, "*", SearchOption.TopDirectoryOnly);

                foreach (var folder in randomFolders)
                {
                    string manifestPath = Path.Combine(folder, version, "complete", "manifest");
                    Mod.log.Info(manifestPath);
                    if (File.Exists(manifestPath))
                    {
                        return manifestPath;
                    }
                }
            }
            catch (Exception ex)
            {
                Mod.log.Info($"Error searching for manifest in '.cpatch': {ex.Message}");
            }

            return null;
        }

        private static Dictionary<string, string> ReadManifestFile(string manifestPath)
        {
            //Mod.log.Info($"Reading {manifestPath}");
            var manifestData = new Dictionary<string, string>();

            try
            {
                var lines = File.ReadAllLines(manifestPath);
                //foreach (var line in lines)
                //{
                //    if (line.Contains(","))
                //    {
                //        var parts = line.Split(',');
                //        if (parts.Length >= 3)
                //        {
                //            string relativePath = parts[0];
                //            string hash = parts[2];
                //            manifestData[relativePath] = hash;
                //        }
                //    }
                //}

                var csvPattern = @"(?:^|,)(?:(?:""(?<value>[^""]*)"")|(?<value>[^,""]*))";

                foreach (var line in lines)
                {
                    var matches = Regex.Matches(line, csvPattern);
                    var parts = matches
                        .Cast<Match>()
                        .Select(m => m.Groups["value"].Value)
                        .ToList();

                    if (parts.Count >= 3)
                    {
                        string relativePath = parts[0];
                        string hash = parts[2];
                        manifestData[relativePath] = hash;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to read manifest file: {ex.Message}", ex);
            }
            return manifestData;
        }

        private static async Task VerifyFolderFiles(string subfolder, Dictionary<string, string> manifestData, string modId, string modName, bool posted)
        {
            if (!Directory.Exists(subfolder))
                return;

            var files = Directory.GetFiles(subfolder, "*", SearchOption.AllDirectories)
                                 .Where(file => !file.Contains(".metadata") && !file.Contains(".cpatch"));
            foreach (var filePath in files)
            {
                string relativePath = GetRelativePath(subfolder, filePath).Replace("/", "\\");
                string relativePathForText = relativePath.Replace("\\", "/");
                try
                {
                    //Mod.log.Info(relativePath);
                    if (manifestData.ContainsKey(relativePath) || manifestData.ContainsKey($"\"{relativePath}\""))
                    {
                        string expectedHash = manifestData[relativePath];
                        string actualHash = await ComputeSHA256Hash(filePath);
                        if (expectedHash == actualHash)
                        {
                            //Mod.log.Info($"File '{relativePath}' is valid.");
                        }
                        else
                        {
                            if (!posted)
                            {
                                IssueTextHeader(modId, modName);
                                posted = true;
                            }
                            IssueList += $"- '{relativePathForText}' is dirty/modified\r\n";
                            Mod.log.Info($"File '{relativePath}' is dirty/modified. Expected: {expectedHash}, Found: {actualHash}");
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
                        IssueList += $"- '{relativePathForText}' is not from the mod\r\n";
                        Mod.log.Info($"File '{relativePath}' is not listed in the manifest.");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += $"- Access denied to file '{relativePathForText}'\r\n";
                    Mod.log.Info($"Access denied to file '{filePath}'. Skipping.");
                }
                catch (Exception ex)
                {
                    if (!posted)
                    {
                        IssueTextHeader(modId, modName);
                        posted = true;
                    }
                    IssueList += $"- Error processing file '{relativePathForText}'\r\n";
                    Mod.log.Info($"Error processing file '{filePath}': {ex.Message}");
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
                IssueList += $"- '{relativePath.Replace("\\", "/")}' is missing from the mod folder\r\n";
                Mod.log.Info($"File '{relativePath}' is listed in the manifest but missing from the folder.");
            }
        }

        private static async Task<string> ComputeSHA256Hash(string filePath)
        {
            try
            {
                filePath = AddLongPathPrefix(filePath);
                using var sha256 = SHA256.Create();
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 8192, useAsync: true);
                byte[] buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    sha256.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                }

                sha256.TransformFinalBlock([], 0, 0);

                return Convert.ToBase64String(sha256.Hash!).Replace("/", "_").Replace("+", "-");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException($"Access to file '{filePath}' is denied.");
            }
            catch (IOException ex)
            {
                throw new IOException($"Error computing SHA256 for file '{filePath}': {ex.Message}", ex);
            }
        }

        private static string AddLongPathPrefix(string path)
        {
            if (path.StartsWith(@"\\?\")) return path;
            return @"\\?\" + Path.GetFullPath(path);
        }

        private static string GetRelativePath(string basePath, string fullPath)
        {
            try
            {
                Uri baseUri = new(basePath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar);
                Uri fullUri = new(fullPath);
                return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fullUri).ToString().Replace('/', Path.DirectorySeparatorChar));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to compute relative path for '{fullPath}': {ex.Message}", ex);
            }
        }
    }
}
