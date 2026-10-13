# Arabic-English Layout Converter

A small Windows tool (`Anti.exe`) for text typed with the wrong keyboard layout: `lvpfh` becomes `مرحبا`, and `اثممخ` becomes `hello`. It follows the standard Arabic (101) layout key by key. Written in C# with WPF on .NET Framework 4.0.

## Features

- **Hotkey:** select text in any program and press **Ctrl+Shift+Space**. The tool copies the selection, converts it, pastes it back in place and puts your clipboard back the way it was. The direction is picked from the text itself: mostly Arabic letters → English, otherwise → Arabic.
- **Tray icon:** minimizing the window hides it to the notification area, and the hotkey keeps working. Double-click the icon (or right-click → Open) to bring the window back; right-click → Exit closes the tool.
- **Window:** paste text in the top box, pick **English to Arabic**, **Arabic to English**, **To Capital** or **To Small**, and press **GO AHEAD**.
- Covers every key of the layout, shifted keys and diacritics included (`Shift+C` → `}`, `~` → `ّ`), and the lam-alef keys (`b` → `لا`, `B` → `لآ`, `G` → `لأ`, `T` → `لإ`).

## Requirements

Windows with .NET Framework 4.0 or later. Windows 8, 10 and 11 already include it.

## Usage

Download `Arabic-English-Layout-Converter-v1.0.0.7z` from [Releases](https://github.com/Mohammad-Diab/Arabic-English-Layout-Converter/releases), extract it, and run `Anti.exe`. There is no installer.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

Notes on the hotkey:

- Select the text first. Some editors (VS Code, for example) copy the whole line when nothing is selected, and that line would be converted.
- It can't reach programs running as administrator unless the tool runs as administrator too.
- Arabic → English reads `لا` as the `b` key, so text typed as `g` then `h` comes back as `b`. Both give the same Arabic text.

## Building

```
git clone https://github.com/Mohammad-Diab/Arabic-English-Layout-Converter.git
```

Open `Anti.sln` in Visual Studio and build, or run:

```
MSBuild Anti.sln /p:Configuration=Release
```

The exe is written to `Anti\bin\Release`.

The project targets .NET Framework 4.0. Recent Visual Studio versions don't ship its reference assemblies; if the build stops with `MSB3644`, extract the [Microsoft.NETFramework.ReferenceAssemblies.net40](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net40) NuGet package and point MSBuild at its `build` folder:

```
MSBuild Anti.sln /p:Configuration=Release /p:TargetFrameworkRootPath=<package>\build
```

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
