using Colossal.IO.AssetDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SimpleModChecker.Systems
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                      .FirstOrDefault() as DescriptionAttribute;
                return attribute != null ? attribute.Description : value.ToString();
            }
            return value.ToString();
        }
    }
    public partial class ModsWithIssues
    {
        public static Dictionary<string, ModWithIssueInfo> LoadedModsWithIssue = SimpleModChecker.Systems.ModCheckup.LoadedModsWithIssue;
        public class ModWithIssueInfo
        {            
            public string AssemblyName { get; set; }
            public string ModName { get; set; }
            public string Author { get; set; }
            public IssueEnum Issue { get; set; }
            public bool Local { get; set; }
            public string Folder { get; set; }
        }

        public enum IssueEnum
        {
            [Description("Mods that includes some versions of vanilla DLLs")]
            VanillaDLL
        }

        public static List<KeyValuePair<string, ModWithIssueInfo>> SortModsWithIssue(string LoggedInUserName = "")
        {
            var sortedList = LoadedModsWithIssue
                .OrderByDescending(mod => mod.Value.Author == LoggedInUserName)
                .OrderBy(mod => mod.Value.Author)
                .ThenBy(mod => mod.Key)
                .ToList();

            return sortedList;
        }

    }
}
