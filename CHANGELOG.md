# 3.5.1 (2025-06-14) - 14298 subs
- Compatibility update for updated mods after 1.3.3f1.

# 3.5.0 (2025-06-11) - 13722 subs
- Compatibility update for 1.3.3f1.
- NEW: Clean up all playsets for old mod versions.
- Completely moved to LangVersion 9.
- Fix assembly namespace issues.
- Fixed changes related to 'Demand Master Control', 'I18N Everywhere', 'InfoLoom', 'Realistic Workplace and Households', 'Real Life', 'Simple Mod Checker Plus'.
- Added "Smart Upkeep Manager".

# 3.4.5 (2025-04-02) - 8902 subs
- NEW: Option to remove the "Resume" button in the launcher.
- NEW: Option to disable the "Continue Game" button in the main menu.
- Removed deprecated CID backup options that wasn't removed 3.4.4.

# 3.4.4 (2025-04-01) - 8923 subs
- Removed CID backup system as it's no longer necessary and conflicts with the current PDX SDK.
- Added an one time check to remove all `.cid.backup` files that didn't come from the mod itself.

# 3.4.3 (2025-03-24) - 8771 subs
- Fix mod/package count in Option's list missing line breaks.
- Fixed changes related to 'Asset Packs Manager'.

# 3.4.2 (2025-03-22) - 8722 subs
- Added try-catch block to catch long path exception for CID Backup/Restore.
- Re-enabled EAI backup/restore but removed the 'EAI Database' option.
- Added "Vehicle Controller".
- Fixed changes related to 'Demand Master Control'.
- Added new option to backup for 'Realistic Trips'.

# 3.4.1 (2025-03-18) - 8668 subs
- Recompiled for 1.2.5f1.
- Disabled EAI restoring to reduce Collection emuneration instance issues.
- Mod verification now also takes file size into consideration.

# 3.4.0 (2025-02-14) - 6705 subs
- Sort downloaded mods list.
- Fix for Verify All Mods not showing accurate result after using Verify Selected Mod.

# 3.3.9 (2025-02-08) - 5981 subs
- Fix notification not disappearing in certain cases.
- Added new option to backup for 'ExtraAssetImporter' and 'Find It'.

# 3.3.8 (2025-02-06) - 5852 subs
- Hotfix for verification failing when there are more than 2 versions of the same mod (thanks to computment).

# 3.3.7 (2025-02-05) - 5827 subs
- Added new options to backup for 'Realistic Workplaces And Households' and 'Realistic Trips'.
- Added ability to verify one selected mod at a time.

# 3.3.6 (2025-01-30) - 5716 subs
- Fixes to Mod Verification process showing incorrect dirtyness.
- Mod Verification is now on a different tab.
- Moved Profile Name out of Advanced section.

# 3.3.5 (2025-01-28) - 5701 subs
- Changed CID backup/restore to work only on currently active mods.
- Shows more details about the mod with CID backup/restore.
- Missing CID Exception will show in UI only if the "Delete Mods with Missing CID" active.
- Updated for I18N Everywhere.

# 3.3.4 (2025-01-17) - 5522 subs
- Added "Asset UI Manager".
- Update to "Auto Vehicle Renamer" changes.

# 3.3.3 (2025-01-10) - 5384 subs
- Fixed "InfoLoom" causing backups to fail.

# 3.2.2 (2024-12-21) - 4987 subs
- Added trackers to keep count of how many settings restored.
- Show the restore notification only if there's anything to restore.
- Remove obsolete online ModDatabase check. ModDatabase is now retrieved locally.
- Added "Historical Start" to Mod Settings Backup/Restore.
- Fixed cases where Mod Restore caused error to be triggered.

# 3.2.0 (2024-12-19) - 4949 subs
- Play a sound after Mod Initialization completes.
- New "Loaded Mods" list which now includes Package (non code) mods as well in a separate group.
- "Loaded Mods" now will show info directly from your current playset instead of curated ModDatabase, including mod version and if a mod is outdated (info depend on latest PDX mod sync data run by the game/Skyve).
- ModDatabase is now only used for enabling/disabling what mod to back up. If a mod is causing issue, you can manually edit the `ModDatabase.json` file until I get an update out.
- Under the "Loaded Mods" list, there is now a "Verify Mods" button, which when clicked will launch a set of checks to ensure the integrity of the mods. It will check if you have multiple version of the same mod downloaded and also the integrity of each file in your whole PDX Mods folder. Any files ending with "backup" are ignored.
- The process will only inform you about the verification result, any other steps to resolve those issues will need to be done manually.
- Removed deprecated mod "TripsData" from Mod Settings Backup/Restore.
- Added "InfoLoom", "Citizen Model Manager" and "Road Wear Adjuster" to Mod Settings Backup/Restore.
- Fixes for Mod Settings Backup/Restore not working for "Tree Controller", "Better Bulldozer", "FPS Limiter".

# 3.1.0 (2024-12-12) - 4843 subs
- Keybind backup for all mods.

# 3.0.0 (2024-12-11) - 4840 subs
- Compatibility with 1.2.0f1
- Frameworks for Keybind Backup/Restore (Not available yet)
- Better settings apply procedure
- Removed "Mods with issues" (shipped with vanilla DLLs) section

# 2.3.0 (2024-11-04) - 4024 subs
- New system for notifying about mods with issues. Currently only notifies about vanilla DLLs being shipped with the mod.
- Compatibility with 'All Aboard' update.
- More check to determine broken coc files.
- Warning popup when known bad DLLs are being loaded.

# 2.2.9 (2024-10-23) - 3676 subs
- Fix for mod backup not keeping backups for not loaded mods.
- Database layout changed.

# 2.2.8 (2024-10-23) - 4094 subs
- Compatibility with game version 1.1.10f1.
- Compatibility with 'Hall of Fame' update.
- Extended and fixed ModDatabase update check logic.

# 2.2.7 (2024-10-15) - 3785 subs
- Fix for CID deletion not working in all cases as expected.
- Fix for wrong OptionsUI tab layout.
- Code cleanup.

# 2.2.6 (2024-10-11) - 3586 subs
- Code logic update for bug fixes in certain conditions.

# 2.2.5 (2024-10-10) - 3553 subs
- Minor bug fix for indefinite notifications.
- OptionsUI now have Mod List as first tab instead of Options.

# 2.2.4 (2024-10-04) - 3483 subs
- Mod Database is no longer hardcoded in the mod/code.
- Mod Database can be downloaded in runtime from GitHub, reducing the need to push constant code updates
- In case of no internet, there's also a backup copy of Mod Database shipped with the mod.
- Newly added supported mods: AreaBucket, Whiteness Toogle (Updated).
- Reorganizing and cleaning up the options UI.
- DLL name starting with "Colossal" namespaces are now ignored. If your mod has them, you should remove them from being shipped.
- Interface style is no longer restored if subscribed to ExtraUI Screens mod.
- Clicking on the main notification of "Loaded X mods" now takes users to the options page instead of opening the log file.
- Minor Bug Fixes.

# 2.2.3 (2024-10-01) - 3425 subs
- New Mod List tab in Options UI to check the loaded mods.
- Support for more mods settings backup/restore.
- Newly added supported mods: AdvancedSimulationSpeed, All Aboard! (Faster Boarding Mod), Asset Packs Manager, Asset Variation Changer, AutoDistrictNameStations, Auto Vehicle Renamer, Better Bulldozer, BetterMoonLight, BetterSaveList, Boundary Lines Modifier, Brush Size Unlimiter, Cim Route Highlighter, City Stats, Demand Master Pro [Alpha], Depot Capacity Changer, Extended Tooltip, ExtraAssetsImporter, First Person Camera Continued, FPS Limiter, Hall of Fame, Image Overlay, Move It, No Pollution, No Teleporting, No Vehicle Despawn, Pathfinding Customizer, Realistic Parking Mod, Realistic Trips, Realistic Workplaces And Households, Real Life, Recolor, Road Builder [BETA], Road Name Remover, School Capacity Balancer, SmartTransportation, Station Naming, Stiffer Vehicles, Sun Glasses, Toggle Overlays, Trading Cost Tweaker, Traffic, Traffic Lights Enhancement Alpha, Traffic Simulation Adjuster, Transit Capacity Multiplier, TransportPolicyAdjuster, Tree Controller, Trips Data, Vehicle Variation Packs, Water Features, Water Visual Tweaks, Zone Color Changer.

# 2.2.2 (2024-09-28) - 3342 subs
- Support for mod settings backup/restore.
- Currently supported mods: 529 Tiles, Anarchy, Asset Icon Library, Find It, I18n Everywhere, Plop The Growables, Simple Mod Checker Plus.

# 2.2.1 (2024-09-23) - 3255 subs
- Added a check to auto restore settings only if something changed, and changed the auto restore notification message.

# 2.2.0 (2024-09-22) - 3209 subs
- Added settings backup/restore.
- Removed 'Autosave On on crash'.
- Removed 'Disable Radio on crash'.

# 2.1.3 (2024-07-27)
- Minor bug fix which prevents the notification to disappear on Game Load.

...

# 1.1 (2024-04-23)
- Added separate system and the notification is only viewable on the Main Menu.

# 1.0 (2024-04-21)
- Initial Release