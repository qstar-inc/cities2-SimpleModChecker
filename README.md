# Simple Mod Checker Plus
I'm a simple man; I see "Loaded {x} mods", I start playing.

This mod adds a **persistent** notification to the Main Menu, showing how many mods have loaded in the current session.

The notification will automatically hide once a Game or Editor is loaded.

If for some reason a broken mod prevents other mods from loading, just by looking at the number you can recognize something is wrong.

If you don't see the notification at all, it means no mods were loaded and you need to restart the game.

## Additional features
* Get notified when a Setting file is corrupted.
* See list of all mods loaded in the current session (grouped by Code Mods and non-Code/packaged mods).
* Backup and Restore Game Settings and selected Mod Settings, and all keybinds (game and mod).
* Automatically restore settings with values saved to 'Profile 1' on startup.
* Trigger a mod verification checkup for all/selected downloaded mods (checks weather the files has been tampered, or if there's more than one version of the same mode is on storage). Found on the "" list, which when clicked will launch a set of checks to ensure the integrity of the mods. It will check if you have multiple version of the same mod downloaded and also the integrity of each file in your whole PDX Mods folder. Any files ending with "backup" are ignored. The process will only inform you about the verification result, any other steps to resolve those issues will need to be done manually.
* Automatic clean up all playsets for old mod versions.
* Get chirp message when auto save is disabled in-game. (Requires "Custom Chirp" mod)
* Remove the "Resume" button in the launcher and/or the "Continue Game" button in the main menu.
* `ModsData/ModDatabase.json` is now only used for enabling/disabling what mod to back up. If a mod is causing issue, you can manually edit the `ModDatabase.json` file until I get an update out.
* [REMOVED] ~~Get notified when .Prefab or .cok files have missing CIDs. (Includes automatic backup, original idea by Konsi/Mimonsi)~~ (Removed as backup CIDs are no longer necessary).
* [REMOVED] ~~Get notified when any of your locally installed or published mods includes vanilla DLLs.~~ (Removed as its part of the base game since 1.2.0f1).

**IMPORTANT**: It is required to make separate backup manually in Profile 1 for Game Settings, Mod Settings and Keybinds first time for the Auto Restore to work afterwards.

### By default on exit, the corrupted setting files will be deleted automatically.

# All options are optional...

Check Options in-game for the current list of supported mods for settings backup/restore.

Safe to remove anytime.

Find me on **Cities: Skylines** Official Discord or **Cities: Skylines Modding** Discord.

Feedback / Bug Report: https://discord.com/channels/1024242828114673724/1287440491239047208

## License Notes
This project is licensed under GPLv3 (see LICENSE). A quick summary of what that means in practice:

- You're free to use, modify, and redistribute this code.
- Any modified version you distribute must also be licensed under GPLv3 (copyleft). This means you can't use this code in a closed-source project.
- Please retain attribution to the original author when redistributing or forking.

### Forks and Redistribution
This mod is distributed exclusively via Paradox Mods, and I actively maintain it there.

If you'd like to contribute, please consider submitting a PR or reaching out instead of publishing a separate copy or fork.

I kindly ask that you do **not**:
- Upload this mod, or any fork of it, to Nexus Mods or any platform other than Paradox Mods, under any circumstances.
- Publish it as a separate listing on Paradox Mods, unless the original mod is abandoned and I'm unresponsive to contact for an extended period.

If you do publish a fork under those circumstances, please:
- Clearly mark it as a fork/unofficial version (not the original),
- Link back to this repository and credit the original work,
- Follow GPLv3's requirements for source availability and licensing.

This is a request from the maintainer, not an added legal restriction beyond what GPLv3 already requires. It does not modify or limit any rights granted under the GPLv3 license, which remains the sole binding license for this Software.

Reposting an actively maintained mod under a new listing, without need, fragments the community and support for users.