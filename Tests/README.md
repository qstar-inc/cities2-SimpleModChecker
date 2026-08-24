# Tests

Checks for the mod-settings backup, against the real mapping classes loaded out of the built
`SimpleModCheckerPlus.dll`.

```
dotnet build SimpleModCheckerPlus.csproj
dotnet run --project Tests
```

Exit code is the number of failures. Game assemblies come from `CSII_MANAGEDPATH`.

The mapping classes, `SettingsBackup`, the `ModSettings` root and `SkipUnsetSettingsResolver`
are the real thing. The resolver is nested inside `ModSettingsBackup`, and building a nested
type doesn't run the outer type's initializer, so it comes straight out of the DLL.

`OnlyDeclaredKeys`, `ParseBackup` and the per-key fill are copies. They're private statics on
`ModSettingsBackup`, and calling one runs that initializer, which reaches
`Colossal.Logging.ILog` — net48 can't load its default interface methods. Group 1 asserts
that, so if it ever changes the copies can go.
