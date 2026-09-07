// This code is untested and may require additional context or dependencies to run successfully.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace SimpleModCheckerPlus.Tests
{
    /// <summary>
    /// Checks the mod-settings backup against the real mapping classes, loaded from the built
    /// SimpleModCheckerPlus.dll. Run it with `dotnet run --project Tests` after building the
    /// mod. Exit code is the number of failures.
    ///
    /// See README.md for what is real here and what is transcribed, and why.
    /// </summary>
    internal static class Program
    {
        private const string ModFile = "SimpleModCheckerPlus.dll";
        private const string ProjectFile = "SimpleModCheckerPlus.csproj";

        private static Assembly mod;
        private static Type settingsBackupInterface;
        private static Type modSettingsType;
        private static JsonSerializerSettings settings;

        private static int passes;
        private static int failures;

        private static int Main()
        {
            string managed = Program.FindManagedPath();
            string modDll = Program.FindModAssembly();

            if (managed == null || modDll == null)
            {
                Console.WriteLine(
                    managed == null
                        ? "Game assemblies not found. Set CSII_MANAGEDPATH."
                        : "Mod assembly not found. Build the mod first."
                );

                return 1;
            }

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string name = new AssemblyName(args.Name).Name;
                string path = Path.Combine(managed, name + ".dll");

                return File.Exists(path) ? Assembly.LoadFrom(path) : null;
            };

            Program.mod = Assembly.LoadFrom(modDll);

            Program.settingsBackupInterface = Program.mod.GetType(
                "SimpleModCheckerPlus.Systems.ISettingsBackup",
                true
            );

            Program.modSettingsType = Program.mod.GetType(
                "SimpleModCheckerPlus.Systems.ModSettings",
                true
            );

            Program.settings = Program.MakeSettings();

            Type[] mapping = Program
                .mod.GetTypes()
                .Where(t =>
                    t.IsClass
                    && !t.IsAbstract
                    && t.Namespace == "SimpleModCheckerPlus.Systems.ModSettingsClasses"
                )
                .OrderBy(t => t.Name)
                .ToArray();

            Console.WriteLine($"SimpleModCheckerPlus {Program.mod.GetName().Version}");
            Console.WriteLine(
                $"{mapping.Length} mapping classes, "
                    + $"{Program.CountProperties(mapping)} properties"
            );

            Program.Reachability();
            Program.Structure(mapping);
            Program.ResolverAtScale(mapping);
            Program.DefaultOfTHazard(mapping);
            Program.DeclaredKeys(mapping);
            Program.PerKeyFill(mapping);
            Program.DateHandling(mapping);
            Program.RestoreGuard(mapping);
            Program.RoundTrip(mapping);
            Program.WholeWritePath(mapping);
            Program.OriginalBug(mapping);

            Console.WriteLine();
            Console.WriteLine(
                Program.failures == 0
                    ? $"ALL PASS ({Program.passes} checks)"
                    : $"{Program.failures} FAILED, {Program.passes} passed"
            );

            return Program.failures;
        }

        /// <summary>
        /// The shipped resolver, not a copy. It is nested inside ModSettingsBackup, and building
        /// a nested type does not run the outer type's initializer, so this one we can have for
        /// real. Group 1 covers the two static helpers that stay out of reach.
        /// </summary>
        private static IContractResolver ShippedResolver()
        {
            Type backup = Program.mod.GetType(
                "SimpleModCheckerPlus.Systems.ModSettingsBackup",
                true
            );

            Type resolver = backup.GetNestedType(
                "SkipUnsetSettingsResolver",
                BindingFlags.NonPublic
            );

            if (resolver == null)
            {
                throw new InvalidOperationException(
                    "SkipUnsetSettingsResolver is gone from ModSettingsBackup."
                );
            }

            return (IContractResolver)Activator.CreateInstance(resolver, true);
        }

        // --- transcribed from Systems/ModSettingsBackup.cs ---------------------------------
        //
        // These two are private statics on ModSettingsBackup, and calling either runs the class
        // initializer, which cannot start off the engine. Group 1 proves it. Keep them in step
        // with the source by hand.

        private static JsonSerializerSettings MakeSettings() =>
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                MaxDepth = 5,
                Formatting = Formatting.Indented,
                ContractResolver = Program.ShippedResolver(),
                Error = (sender, args) => args.ErrorContext.Handled = true,
            };

        private static JObject OnlyDeclaredKeys(JObject section, Type classType)
        {
            HashSet<string> declared = new HashSet<string>(
                classType.GetProperties().Select(p => p.Name)
            );

            JObject kept = new JObject();

            foreach (JProperty prop in section.Properties())
            {
                if (declared.Contains(prop.Name))
                {
                    kept.Add(prop.Name, prop.Value);
                }
            }

            return kept;
        }

        private static JObject ParseBackup(string json)
        {
            using (StringReader text = new StringReader(json))
            using (
                JsonTextReader reader = new JsonTextReader(text)
                {
                    DateParseHandling = DateParseHandling.None,
                }
            )
            {
                return JObject.Load(reader);
            }
        }

        private static void Fill(JObject output, Dictionary<string, JToken> previousSections)
        {
            foreach (KeyValuePair<string, JToken> previous in previousSections)
            {
                if (!(output[previous.Key] is JObject fresh))
                {
                    output[previous.Key] = previous.Value;
                    continue;
                }

                foreach (JProperty old in ((JObject)previous.Value).Properties())
                {
                    if (!fresh.TryGetValue(old.Name, out JToken _))
                    {
                        fresh.Add(old.Name, old.Value);
                    }
                }
            }
        }

        // --- groups -----------------------------------------------------------------------

        /// <summary>
        /// What the tests get to run for real and what they only mirror. If the last check here
        /// ever fails, the class initializer has become runnable and the copies can go.
        /// </summary>
        private static void Reachability()
        {
            Program.Group("1. What is the shipped code and what is a copy");

            Program.Check(
                "the resolver under test is the one ModSettingsBackup ships",
                Program.settings.ContractResolver.GetType().DeclaringType?.FullName
                    == "SimpleModCheckerPlus.Systems.ModSettingsBackup"
            );

            Type backup = Program.mod.GetType(
                "SimpleModCheckerPlus.Systems.ModSettingsBackup",
                true
            );

            string[] wanted = { "OnlyDeclaredKeys", "ParseBackup", "ProcessFragmentSource" };

            string[] found = backup
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Select(m => m.Name)
                .Where(n => wanted.Contains(n))
                .Distinct()
                .OrderBy(n => n)
                .ToArray();

            Program.Check(
                $"the shipped helpers still exist under these names ({string.Join(", ", found)})",
                found.Length == wanted.Length
            );

            string failure = null;

            try
            {
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(
                    backup.TypeHandle
                );
            }
            catch (Exception ex)
            {
                Exception root = ex;

                while (root.InnerException != null)
                {
                    root = root.InnerException;
                }

                failure = $"{root.GetType().Name}";
            }

            Program.Check(
                "ModSettingsBackup's static constructor cannot run off the engine "
                    + $"({failure ?? "it ran - the copies are no longer needed"})",
                failure == "TypeLoadException"
            );

            Program.Report(
                "it reaches Colossal.Logging.ILog, whose default interface methods the net48 "
                    + "CLR refuses to load"
            );

            Program.Report(
                "so ParseBackup and OnlyDeclaredKeys, both private statics on it, are mirrored "
                    + "below rather than called"
            );
        }

        /// <summary>The shape the resolver and the filter both assume.</summary>
        private static void Structure(Type[] mapping)
        {
            Program.Group("2. Shape of the mapping classes");

            Type settingsBackup = Program.mod.GetType(
                "SimpleModCheckerPlus.Systems.SettingsBackup",
                true
            );

            Type[] notBacked = mapping.Where(t => !settingsBackup.IsAssignableFrom(t)).ToArray();

            Program.Check(
                $"all derive from SettingsBackup ({notBacked.Length} do not)",
                notBacked.Length == 0
            );

            PropertyInfo[] props = mapping.SelectMany(t => t.GetProperties()).ToArray();

            Program.Check(
                "no indexer properties, which would collide on member.Name",
                props.All(p => p.GetIndexParameters().Length == 0)
            );

            Program.Check("every property is read/write", props.All(p => p.CanRead && p.CanWrite));

            Program.Check(
                "no class declares a name twice",
                mapping.All(t => t.GetProperties().GroupBy(p => p.Name).All(g => g.Count() == 1))
            );

            Program.Report(
                $"{props.Count(p => p.PropertyType.IsValueType)} value-typed, "
                    + $"{props.Count(p => !p.PropertyType.IsValueType)} reference-typed"
            );

            Program.Report(
                "types in use: "
                    + string.Join(
                        ", ",
                        props.Select(p => p.PropertyType.Name).Distinct().OrderBy(n => n)
                    )
            );
        }

        /// <summary>
        /// The resolver's whole job: a property the live mod never gave us must not appear in
        /// the backup at all. Before the fix it appeared as an explicit null.
        /// </summary>
        private static void ResolverAtScale(Type[] mapping)
        {
            Program.Group("3. Unset means absent, on every class");

            List<string> leaks = new List<string>();
            List<string> wrong = new List<string>();

            foreach (Type t in mapping)
            {
                JObject empty = JObject.Parse(
                    JsonConvert.SerializeObject(Activator.CreateInstance(t), Program.settings)
                );

                if (empty.HasValues)
                {
                    leaks.Add($"{t.Name} emitted {empty.Properties().Count()} keys");
                }

                PropertyInfo first = t.GetProperties()
                    .FirstOrDefault(p =>
                        p.PropertyType == typeof(string) || p.PropertyType == typeof(bool)
                    );

                if (first == null)
                {
                    continue;
                }

                object one = Activator.CreateInstance(t);

                first.SetValue(one, first.PropertyType == typeof(string) ? "x" : (object)true);

                JObject oneJson = JObject.Parse(JsonConvert.SerializeObject(one, Program.settings));

                if (oneJson.Properties().Count() != 1 || oneJson[first.Name] == null)
                {
                    wrong.Add($"{t.Name}.{first.Name} -> {oneJson.ToString(Formatting.None)}");
                }
            }

            Program.Check(
                $"a never-touched instance serializes to {{}} ({leaks.Count} leak)",
                leaks.Count == 0
            );

            Program.List(leaks);

            Program.Check(
                $"setting one property emits exactly one key ({wrong.Count} wrong)",
                wrong.Count == 0
            );

            Program.List(wrong);
        }

        /// <summary>
        /// The reason the null branch is gated on !IsValueType. Reflection turns a null into
        /// default(T) without complaining, and that value then looks like a real setting.
        /// </summary>
        private static void DefaultOfTHazard(Type[] mapping)
        {
            Program.Group("4. The default(T) hazard the value-type guard prevents");

            List<string> atRisk = new List<string>();
            int tombstones = 0;

            foreach (Type t in mapping)
            {
                foreach (PropertyInfo p in t.GetProperties())
                {
                    object bag = Activator.CreateInstance(t);

                    p.SetValue(bag, null);

                    bool recorded = Program.HasValue(bag, p.Name);
                    object stored = Program.GetValue(bag, p.Name);

                    if (p.PropertyType.IsValueType)
                    {
                        if (recorded && stored != null)
                        {
                            atRisk.Add($"{t.Name}.{p.Name} ({p.PropertyType.Name}) -> {stored}");
                        }
                    }
                    else if (recorded && stored == null)
                    {
                        tombstones++;
                    }
                }
            }

            Program.Check(
                "SetValue(null) on a value type stores default(T), so the guard is required",
                atRisk.Count > 0
            );

            Program.Report($"{atRisk.Count} properties would be corrupted without it");
            Program.List(atRisk.Take(3).ToList());

            Program.Check(
                $"a null on a reference type records cleanly ({tombstones} properties)",
                tombstones > 0
            );
        }

        /// <summary>
        /// The mapping classes are curated: a property commented out of one is one we stopped
        /// backing up on purpose, and a stale copy must not survive in the file.
        /// </summary>
        private static void DeclaredKeys(Type[] mapping)
        {
            Program.Group("5. OnlyDeclaredKeys drops what a class no longer declares");

            string[] gone =
            {
                "MistralAPIKey",
                "GoogleaiAPIKey",
                "SavedPresets",
                "EnableAssetPacks",
            };
            List<string> leaks = new List<string>();
            int kept = 0;

            foreach (Type t in mapping)
            {
                string[] declared = t.GetProperties().Select(p => p.Name).ToArray();

                if (declared.Length == 0)
                {
                    continue;
                }

                JObject old = new JObject { [declared[0]] = "keep" };

                foreach (string name in gone)
                {
                    old[name] = "stale";
                }

                JObject filtered = Program.OnlyDeclaredKeys(old, t);

                if (filtered[declared[0]] == null)
                {
                    leaks.Add($"{t.Name} lost its own {declared[0]}");
                }
                else
                {
                    kept++;
                }

                foreach (string name in gone.Where(n => !declared.Contains(n)))
                {
                    if (filtered[name] != null)
                    {
                        leaks.Add($"{t.Name} kept undeclared {name}");
                    }
                }
            }

            Program.Check($"declared keys survive ({kept} classes)", kept > 0);
            Program.Check($"undeclared keys are dropped ({leaks.Count} leaks)", leaks.Count == 0);
            Program.List(leaks);
        }

        /// <summary>
        /// The write-path fill is a union: what we just read wins, gaps come from the old
        /// backup, and a setting the user cleared is present-as-null and must stay cleared.
        /// </summary>
        private static void PerKeyFill(Type[] mapping)
        {
            Program.Group("6. Per-key fill, with the fresh read winning");

            List<string> wrong = new List<string>();
            int covered = 0;

            foreach (Type t in mapping)
            {
                PropertyInfo[] strings = t.GetProperties()
                    .Where(p => p.PropertyType == typeof(string))
                    .Take(2)
                    .ToArray();

                if (strings.Length < 2)
                {
                    continue;
                }

                covered++;

                Dictionary<string, JToken> previous = new Dictionary<string, JToken>
                {
                    [t.Name] = new JObject
                    {
                        [strings[0].Name] = "old-a",
                        [strings[1].Name] = "old-b",
                    },
                };

                JObject output = new JObject
                {
                    [t.Name] = new JObject { [strings[0].Name] = "fresh-a" },
                };

                Program.Fill(output, previous);

                JObject merged = (JObject)output[t.Name];

                if ((string)merged[strings[0].Name] != "fresh-a")
                {
                    wrong.Add($"{t.Name}: the fresh read was overwritten");
                }

                if ((string)merged[strings[1].Name] != "old-b")
                {
                    wrong.Add($"{t.Name}: the gap was not filled");
                }

                JObject cleared = new JObject
                {
                    [t.Name] = new JObject { [strings[0].Name] = JValue.CreateNull() },
                };

                Program.Fill(cleared, previous);

                if (cleared[t.Name][strings[0].Name].Type != JTokenType.Null)
                {
                    wrong.Add($"{t.Name}: a cleared setting was resurrected");
                }
            }

            Program.Check(
                "union, fresh wins, cleared stays cleared "
                    + $"({covered} classes, {wrong.Count} wrong)",
                wrong.Count == 0
            );

            Program.List(wrong);
        }

        /// <summary>
        /// JObject.Parse re-reads a date-shaped string as a DateTime and hands back a different
        /// string than the mod stored. Carried-forward sections come straight off that parse.
        /// </summary>
        private static void DateHandling(Type[] mapping)
        {
            Program.Group("7. Reading the backup leaves strings alone");

            string[] samples =
            {
                "2024-01-15T10:30:00+02:00",
                "2024-01-15T10:30:00Z",
                "/Date(1234567890)/",
                "2024-01-15",
                "2024-01-15 10:30:00",
                "10:30",
                "1.2.3",
                "not a date at all",
            };

            int mangled = 0;
            List<string> survived = new List<string>();

            foreach (string sample in samples)
            {
                string json = new JObject { ["S"] = new JObject { ["V"] = sample } }.ToString(
                    Formatting.None
                );

                if (JObject.Parse(json)["S"]["V"].Type != JTokenType.String)
                {
                    mangled++;
                }

                JToken viaBackup = Program.ParseBackup(json)["S"]["V"];

                if (viaBackup.Type != JTokenType.String || (string)viaBackup != sample)
                {
                    survived.Add($"{sample} -> {viaBackup}");
                }
            }

            Program.Check(
                $"JObject.Parse turns some of these into dates ({mangled} of {samples.Length})",
                mangled > 0
            );

            Program.Check(
                $"ParseBackup returns every one unchanged ({survived.Count} mangled)",
                survived.Count == 0
            );

            Program.List(survived);

            Type withString = mapping.First(t =>
                t.GetProperties().Any(p => p.PropertyType == typeof(string))
            );

            string prop = withString
                .GetProperties()
                .First(p => p.PropertyType == typeof(string))
                .Name;

            string onDisk = new JObject
            {
                [withString.Name] = new JObject { [prop] = "2024-01-15T10:30:00+02:00" },
            }.ToString(Formatting.Indented);

            JObject reread = Program.ParseBackup(onDisk);

            Dictionary<string, JToken> carried = new Dictionary<string, JToken>
            {
                [withString.Name] = Program.OnlyDeclaredKeys(
                    (JObject)reread[withString.Name],
                    withString
                ),
            };

            JObject output = new JObject { [withString.Name] = JValue.CreateNull() };

            Program.Fill(output, carried);

            Program.Check(
                "a date-shaped setting survives read -> filter -> fill -> write",
                (string)output[withString.Name][prop] == "2024-01-15T10:30:00+02:00"
            );
        }

        /// <summary>
        /// A null in an older backup must never reach a live mod, whatever the target type.
        /// This is what un-breaks a user who already holds a poisoned file.
        /// </summary>
        private static void RestoreGuard(Type[] mapping)
        {
            Program.Group("8. Restore skips every null");

            JsonSerializer serializer = JsonSerializer.Create(Program.settings);

            Type[] types = mapping
                .SelectMany(t => t.GetProperties())
                .Select(p => p.PropertyType)
                .Distinct()
                .ToArray();

            List<string> restored = new List<string>();

            foreach (Type type in types)
            {
                object value = JValue.CreateNull().ToObject(type, serializer);

                if (value != null)
                {
                    restored.Add($"{type.Name} -> {value}");
                }
            }

            Program.Check(
                $"a JSON null converts to null for all {types.Length} types in use "
                    + $"({restored.Count} would be written into a mod)",
                restored.Count == 0
            );

            Program.List(restored);
        }

        /// <summary>Nothing is lost or changed by a write then read.</summary>
        private static void RoundTrip(Type[] mapping)
        {
            Program.Group("9. Round trip, every property of every class");

            JsonSerializer serializer = JsonSerializer.Create(Program.settings);
            List<string> lost = new List<string>();
            int covered = 0;

            foreach (Type t in mapping)
            {
                object bag = Activator.CreateInstance(t);
                Dictionary<string, object> expected = new Dictionary<string, object>();

                foreach (PropertyInfo p in t.GetProperties())
                {
                    object sample = Program.SampleFor(p.PropertyType);

                    if (sample == null)
                    {
                        continue;
                    }

                    p.SetValue(bag, sample);
                    expected[p.Name] = sample;
                }

                JObject json = JObject.Parse(JsonConvert.SerializeObject(bag, Program.settings));

                foreach (KeyValuePair<string, object> kv in expected)
                {
                    covered++;

                    JToken token = json[kv.Key];

                    if (token == null)
                    {
                        lost.Add($"{t.Name}.{kv.Key} vanished");
                        continue;
                    }

                    object back = token.ToObject(t.GetProperty(kv.Key).PropertyType, serializer);

                    if (back is Array a && kv.Value is Array b)
                    {
                        if (a.Length != b.Length)
                        {
                            lost.Add($"{t.Name}.{kv.Key} array length changed");
                        }

                        continue;
                    }

                    if (!Equals(back, kv.Value))
                    {
                        lost.Add($"{t.Name}.{kv.Key}: {kv.Value} -> {back}");
                    }
                }
            }

            Program.Check(
                $"every set property survives ({covered} checked, {lost.Count} lost)",
                lost.Count == 0
            );

            Program.List(lost.Take(8).ToList());
        }

        /// <summary>
        /// The write path on the real root object, with one mod read in full, one whose getters
        /// all threw, and one that is not loaded.
        /// </summary>
        private static void WholeWritePath(Type[] mapping)
        {
            Program.Group("10. The write path on the real ModSettings root");

            object root = Activator.CreateInstance(Program.modSettingsType);

            Program.modSettingsType.GetProperty("ModVersion").SetValue(root, "4.1.4");
            Program.modSettingsType.GetProperty("LastUpdated").SetValue(root, "today");

            Type full = mapping.First(t =>
                t.GetProperties().Count(p => p.PropertyType == typeof(string)) >= 2
            );

            Type emptied = mapping.First(t => t != full);
            Type absent = mapping.First(t => t != full && t != emptied);

            PropertyInfo[] strings = full.GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Take(2)
                .ToArray();

            object fullBag = Activator.CreateInstance(full);

            strings[0].SetValue(fullBag, "fresh");

            Program.modSettingsType.GetProperty(full.Name).SetValue(root, fullBag);

            Program
                .modSettingsType.GetProperty(emptied.Name)
                .SetValue(root, Activator.CreateInstance(emptied));

            // `absent` stays null: that mod is not loaded.

            JObject output = JObject.FromObject(
                root,
                JsonSerializer.CreateDefault(Program.settings)
            );

            Program.Check(
                "the root's own fields serialize",
                (string)output["ModVersion"] == "4.1.4"
            );

            Program.Check(
                "a section read in full carries only what was read",
                output[full.Name] is JObject f
                    && f.Properties().Count() == 1
                    && (string)f[strings[0].Name] == "fresh"
            );

            Program.Check(
                "a section whose getters all threw serializes to {}",
                output[emptied.Name] is JObject e && !e.HasValues
            );

            Program.Check(
                "an unloaded mod's section serializes to null",
                output[absent.Name] != null && output[absent.Name].Type == JTokenType.Null
            );

            Dictionary<string, JToken> previous = new Dictionary<string, JToken>
            {
                [full.Name] = new JObject
                {
                    [strings[0].Name] = "old",
                    [strings[1].Name] = "old-b",
                },
                [emptied.Name] = Program.SectionFor(emptied),
                [absent.Name] = Program.SectionFor(absent),
            };

            Program.Fill(output, previous);

            Program.Check(
                "the fresh read wins over the old backup",
                (string)output[full.Name][strings[0].Name] == "fresh"
            );

            Program.Check(
                "the gap in a partial read is filled from the old backup",
                (string)output[full.Name][strings[1].Name] == "old-b"
            );

            Program.Check(
                "a section that came back empty is restored wholesale",
                output[emptied.Name] is JObject e2 && e2.HasValues
            );

            Program.Check(
                "an unloaded mod's section is carried forward, not left null",
                output[absent.Name] is JObject a2 && a2.HasValues
            );

            string written = output.ToString(Formatting.Indented);

            Program.Check(
                "the file we write reads back identically",
                JToken.DeepEquals(Program.ParseBackup(written), output)
            );

            int nulls = output
                .Properties()
                .Where(p => p.Value.Type == JTokenType.Object)
                .SelectMany(p => ((JObject)p.Value).Properties())
                .Count(p => p.Value.Type == JTokenType.Null);

            Program.Check("no explicit nulls inside any section", nulls == 0);
        }

        /// <summary>
        /// The bug that started this, reproduced and then shown fixed: a mapping class ahead of
        /// the installed mod used to write a null for every property the mod did not have, and
        /// a null string behind a [SettingsUIDropdown] crashes the vanilla options UI.
        /// </summary>
        private static void OriginalBug(Type[] mapping)
        {
            Program.Group("11. The reported bug");

            Type hof = mapping.FirstOrDefault(t => t.Name == "HallOfFameSettings");

            if (hof == null)
            {
                Program.Report("HallOfFameSettings is gone from the database, skipping");
                return;
            }

            object bag = Activator.CreateInstance(hof);

            // What the live mod gave us: three of the class's properties.
            string[] sample = { "CreatorName", "ViewMaxAge", "EnableMainMenuSlideshow" };

            foreach (string name in sample)
            {
                PropertyInfo p = hof.GetProperty(name);

                p?.SetValue(bag, Program.SampleFor(p.PropertyType));
            }

            int declared = hof.GetProperties().Length;

            JsonSerializerSettings without = Program.MakeSettings();

            without.ContractResolver = new DefaultContractResolver();

            JObject before = JObject.Parse(JsonConvert.SerializeObject(bag, without));
            JObject after = JObject.Parse(JsonConvert.SerializeObject(bag, Program.settings));

            int beforeNulls = before.Properties().Count(p => p.Value.Type == JTokenType.Null);

            Program.Check(
                $"without the fix, {beforeNulls} of {declared} properties come out null",
                beforeNulls > 0
            );

            Program.Check(
                "with the fix, none do",
                after.Properties().All(p => p.Value.Type != JTokenType.Null)
            );

            Program.Check(
                "and the values the mod did give us are still there",
                after.Properties().Count() == 3
            );

            // NamesTranslationMode is the one that crashed the options UI.
            if (hof.GetProperty("NamesTranslationMode") != null)
            {
                Program.Check(
                    "NamesTranslationMode, the dropdown that crashed, is absent not null",
                    after["NamesTranslationMode"] == null
                        && before["NamesTranslationMode"] != null
                        && before["NamesTranslationMode"].Type == JTokenType.Null
                );
            }

            Program.ReportedScenario(hof);
        }

        /// <summary>
        /// The reporter's case end to end. Their backup was written when HallOfFameSettings had
        /// the 13 properties below; the class has since grown. On a launch with Hall of Fame not
        /// loaded, the old code rebuilt the section through the grown class and wrote a null for
        /// every property it had gained. Those nulls went back into the mod on the next restore.
        /// </summary>
        private static void ReportedScenario(Type hof)
        {
            string[] asShipped =
            {
                "CreatorID",
                "IsParadoxAccountID",
                "CreatorName",
                "TrendingScreenshotWeight",
                "RecentScreenshotWeight",
                "ArcheologistScreenshotWeight",
                "RandomScreenshotWeight",
                "SupporterScreenshotWeight",
                "ViewMaxAge",
                "ScreenshotResolution",
                "CreateLocalScreenshot",
                "DisableGlobalIllumination",
                "BaseUrl",
            };

            JObject old = new JObject();

            foreach (string name in asShipped)
            {
                PropertyInfo p = hof.GetProperty(name);

                old[name] =
                    p == null
                        ? JToken.FromObject("tuned")
                        : JToken.FromObject(Program.SampleFor(p.PropertyType) ?? "tuned");
            }

            string onDisk = new JObject { [hof.Name] = old }.ToString(Formatting.Indented);

            // A launch where the mod is not loaded: nothing to read, so the section is null and
            // the old backup is all we have.
            JObject reread = Program.ParseBackup(onDisk);

            Dictionary<string, JToken> previous = new Dictionary<string, JToken>
            {
                [hof.Name] = Program.OnlyDeclaredKeys((JObject)reread[hof.Name], hof),
            };

            JObject output = new JObject { [hof.Name] = JValue.CreateNull() };

            Program.Fill(output, previous);

            JObject section = (JObject)output[hof.Name];

            int nulls = section.Properties().Count(p => p.Value.Type == JTokenType.Null);
            int grownBy = hof.GetProperties().Length - asShipped.Length;

            Program.Check(
                $"the class has grown by {grownBy} properties since that backup was written",
                grownBy > 0
            );

            Program.Check(
                $"not one of them is invented as a null ({nulls} nulls in the section)",
                nulls == 0
            );

            Program.Check(
                $"and the {asShipped.Length} the user had tuned all survive",
                asShipped
                    .Where(n => hof.GetProperty(n) != null)
                    .All(n => section[n] != null && section[n].Type != JTokenType.Null)
            );

            Program.Report(
                $"section carries {section.Properties().Count()} keys, "
                    + $"the {asShipped.Count(n => hof.GetProperty(n) != null)} still declared"
            );
        }

        // --- plumbing ---------------------------------------------------------------------

        private static JToken SectionFor(Type t)
        {
            PropertyInfo p = t.GetProperties().First();
            object sample = Program.SampleFor(p.PropertyType);

            return new JObject
            {
                [p.Name] = sample == null ? JValue.CreateNull() : JToken.FromObject(sample),
            };
        }

        private static object SampleFor(Type t)
        {
            if (t == typeof(string))
            {
                return "sample";
            }

            if (t == typeof(bool))
            {
                return true;
            }

            if (t == typeof(int))
            {
                return 42;
            }

            if (t == typeof(uint))
            {
                return 42u;
            }

            if (t == typeof(float))
            {
                return 1.5f;
            }

            if (t == typeof(double))
            {
                return 1.5d;
            }

            if (t == typeof(int[]))
            {
                return new[] { 1, 2, 3 };
            }

            if (t == typeof(string[]))
            {
                return new[] { "a", "b" };
            }

            if (t.IsEnum)
            {
                return Enum.GetValues(t).GetValue(0);
            }

            if (t == typeof(CultureInfo))
            {
                return CultureInfo.GetCultureInfo("fr-FR");
            }

            return null;
        }

        private static bool HasValue(object bag, string name) =>
            (bool)
                Program
                    .settingsBackupInterface.GetMethod("HasValue")
                    .Invoke(bag, new object[] { name });

        private static object GetValue(object bag, string name) =>
            Program
                .settingsBackupInterface.GetMethod("GetValue")
                .Invoke(bag, new object[] { name });

        private static int CountProperties(Type[] mapping) =>
            mapping.Sum(t => t.GetProperties().Length);

        private static string FindManagedPath()
        {
            string[] candidates =
            {
                Environment.GetEnvironmentVariable("CSII_MANAGEDPATH"),
                Environment.GetEnvironmentVariable(
                    "CSII_MANAGEDPATH",
                    EnvironmentVariableTarget.User
                ),
                @"C:\Program Files (x86)\Steam\steamapps\common\Cities Skylines II"
                    + @"\Cities2_Data\Managed",
                @"C:\XboxGames\Cities- Skylines II - PC Edition\Content\Cities2_Data\Managed",
            };

            return candidates.FirstOrDefault(c =>
                !string.IsNullOrEmpty(c) && File.Exists(Path.Combine(c, "Game.dll"))
            );
        }

        private static string FindModAssembly()
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (dir != null && !File.Exists(Path.Combine(dir.FullName, ProjectFile)))
            {
                dir = dir.Parent;
            }

            if (dir == null)
            {
                return null;
            }

            return new[] { "Debug", "Release" }
                .Select(c => Path.Combine(dir.FullName, "bin", c, "net48", ModFile))
                .FirstOrDefault(File.Exists);
        }

        private static void Group(string name)
        {
            Console.WriteLine();
            Console.WriteLine(name);
        }

        private static void Check(string what, bool ok)
        {
            if (ok)
            {
                Program.passes++;
                Console.WriteLine($"  PASS  {what}");
            }
            else
            {
                Program.failures++;
                Console.WriteLine($"  FAIL  {what}");
            }
        }

        private static void Report(string line) => Console.WriteLine($"        {line}");

        private static void List(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                Program.Report(line);
            }
        }
    }
}
