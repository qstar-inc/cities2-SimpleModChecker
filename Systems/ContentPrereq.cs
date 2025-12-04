//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Colossal.Serialization.Entities;
//using Game;
//using Game.Prefabs;
//using Game.Serialization;
//using SimpleModCheckerPlus.Prefabs;
//using StarQ.Shared.Extensions;
//using Unity.Entities;
//using UnityEngine;

//namespace SimpleModCheckerPlus.Systems
//{
//    public partial class ContentPrereq : GameSystemBase, IPreDeserialize
//    {
//        public bool FirstRun = true;
//#nullable disable
//        private PrefabSystem prefabSystem;

//        public static List<string> contentPrereqs = new();

//        protected override void OnCreate()
//        {
//            base.OnCreate();
//            prefabSystem = WorldHelper.PrefabSystem;
//        }

//        protected override void OnUpdate() { }

//        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
//        {
//            base.OnGameLoadingComplete(purpose, mode);
//            if (!FirstRun)
//                return;

//            List<TypeIndex> _registeredComponents = new();
//            _registeredComponents = TypeManager
//                .AllTypes.Where(t =>
//                    t.TypeIndex != TypeIndex.Null
//                    && (
//                        t.Category == TypeManager.TypeCategory.ComponentData
//                        || t.Category == TypeManager.TypeCategory.BufferData
//                        || t.Category == TypeManager.TypeCategory.ISharedComponentData
//                    )
//                )
//                .Select(t => t.TypeIndex)
//                .ToList();

//            _registeredComponents.Sort(
//                (index, typeIndex) =>
//                    string.Compare(
//                        ComponentType.FromTypeIndex(index).GetManagedType()?.FullName,
//                        ComponentType.FromTypeIndex(typeIndex).GetManagedType()?.FullName
//                    )
//            );

//            foreach (TypeIndex registeredComponent in _registeredComponents)
//            {
//                ComponentType type = ComponentType.FromTypeIndex(registeredComponent);
//                Type managedType = type.GetManagedType();
//                if (managedType == null)
//                    continue;

//                string moduleName = managedType.Module.ScopeName.Replace(".dll", "");
//                if (moduleName == "Game" || moduleName.StartsWith("Unity"))
//                    continue;

//                if (!contentPrereqs.Contains(moduleName))
//                    contentPrereqs.Add(moduleName);
//            }

//            contentPrereqs.Sort();
//            LogHelper.SendLog(
//                contentPrereqs.Count
//                    + " mods with components\n"
//                    + string.Join("\n", contentPrereqs),
//                LogLevel.DEV
//            );

//            foreach (var item in contentPrereqs)
//                CreateContentPrefab(item);

//            FirstRun = false;
//        }

//        public void CreateContentPrefab(string name)
//        {
//            //if (string.IsNullOrEmpty(name) || name != "Anarchy")
//            //    return;

//            if (!prefabSystem.TryGetPrefab(new PrefabID("ContentPrefab", name), out PrefabBase _))
//            {
//                ContentPrefab contentPrefabNew = ScriptableObject.CreateInstance<ContentPrefab>();
//                contentPrefabNew.name = name;
//                var dlc = contentPrefabNew.AddComponent<DlcRequirement>();

//                dlc.m_Notes = name;
//                dlc.m_BaseGameRequiresDatabase = false;
//                dlc.m_Dlc = new Colossal.PSI.Common.DlcId(-2009);

//                prefabSystem.AddPrefab(contentPrefabNew);
//            }
//        }

//        public void PreDeserialize(Context context)
//        {
//            foreach (var item in contentPrereqs)
//            {
//                LogHelper.SendLog($"PreDeserialize {item}");
//                if (
//                    !prefabSystem.TryGetPrefab(
//                        new PrefabID("ContentPrefab", item),
//                        out PrefabBase contentPrefab
//                    )
//                )
//                    continue;
//                LogHelper.SendLog($"ContentPrefab found {item}");

//                ModPrefab modPrefab = ScriptableObject.CreateInstance<ModPrefab>();
//                modPrefab.name = item;

//                if (
//                    !prefabSystem.TryGetPrefab(modPrefab.GetPrefabID(), out _)
//                    && prefabSystem.AddPrefab(modPrefab)
//                    && prefabSystem.TryGetEntity(modPrefab, out Entity FakePrefabRef)
//                )
//                {
//                    var cp = modPrefab.AddOrGetComponent<ContentPrerequisite>();
//                    cp.m_ContentPrerequisite = (ContentPrefab)contentPrefab;
//                    modPrefab.AddComponentFrom(cp);
//                    prefabSystem.UpdatePrefab(modPrefab);
//                    continue;
//                }
//            }
//        }
//    }
//}
