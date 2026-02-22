# ![MudBlazor Logo](content/MudBlazor-GitHub-NoBg-Dark.png)
# Blazor Template pre-configured with MudBlazor.

[![GitHub](https://img.shields.io/github/license/garderoben/mudblazor?color=%23594ae2&style=flat-square)](https://github.com/Garderoben/MudBlazor.Templates/blob/master/LICENSE)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)
[![Nuget version](https://img.shields.io/nuget/v/MudBlazor.Templates?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.Templates/)
[![Nuget downloads](https://img.shields.io/nuget/dt/MudBlazor.Templates?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.Templates/)

We're excited to announce the availability of a new template for .NET 10 Web Apps: the MudBlazor Web App template. This template is based on the Microsoft Web App template, but has been modified to include MudBlazor components.

## Prerequisites

- .NET 10 SDK
- Visual Studio 2026, JetBrains Rider or Visual Studio Code 

## Getting Started
### Installation
```
dotnet new install MudBlazor.Templates
```

### Updating the Template

If you already installed `MudBlazor.Templates` and want the latest version, update your installed template packages with:

```bash
dotnet new update
```

This checks installed template packages and installs available updates.

To preview updates without changing anything:

```bash
dotnet new update --check-only
```

To verify which version is installed / available:

```bash
dotnet new list mudblazor
```

If you want to reinstall manually (for example, to pin a specific version), uninstall and install again:

```bash
dotnet new uninstall MudBlazor.Templates
dotnet new install MudBlazor.Templates
```

Install a specific version:

```bash
dotnet new install MudBlazor.Templates::<version>
```

`dotnet new update` updates all installed template packages, not just `MudBlazor.Templates`.

## Usage
### Common Commands

Create a new app (default is `Server` interactivity):
```bash
dotnet new mudblazor -o MyMudApp
```

Create a static server-rendered app (no interactivity):
```bash
dotnet new mudblazor -o MyMudApp -int None
```

Create an app with per-page interactive components:
```bash
dotnet new mudblazor -o MyMudApp -int Auto
```

Create an app with interactive rendering enabled globally:
```bash
dotnet new mudblazor -o MyMudApp -int Auto -ai
```

Create an app with Individual authentication:
```bash
dotnet new mudblazor -o MyMudApp -int Auto -au Individual
```

Create an app with Individual authentication and global interactivity:
```bash
dotnet new mudblazor -o MyMudApp -int Auto -au Individual -ai
```

Create an app with Individual authentication using LocalDB (instead of SQLite):
```bash
dotnet new mudblazor -o MyMudApp -au Individual -uld
```

Create an empty starter (omit sample/demo pages and styling):
```bash
dotnet new mudblazor -o MyMudApp -e
```

Create an app without HTTPS (for local development only):
```bash
dotnet new mudblazor -o MyMudApp --no-https
```

Create an app with a custom project name and output folder:
```bash
dotnet new mudblazor -n Acme.Portal -o src/Acme.Portal -int WebAssembly
```

### Options (Common)

| Option | Values / Type | Default | Description / Notes |
| --- | --- | --- | --- |
| `-int`, `--interactivity` | `Auto`, `None`, `Server`, `WebAssembly` | `Server` | Selects the interactive render mode. Use `None` for static SSR only. |
| `-ai`, `--all-interactive` | `bool` | `false` | Applies interactivity globally (root-level). Only enabled when interactivity is not `None`. |
| `-au`, `--auth` | `None`, `Individual` | `None` | Adds authentication support. |
| `-uld`, `--use-local-db` | `bool` | `false` | Uses LocalDB instead of SQLite. Only applies with `-au Individual`. |
| `-e`, `--empty` | `bool` | `false` | Omits sample pages and demo styling. |
| `--no-https` | `bool` | `false` | Disables HTTPS for local development. Ignored when `-au Individual` is used. |
| `--exclude-launch-settings` | `bool` | `false` | Excludes `Properties/launchSettings.json` from generated output. |
| `--no-restore` | `bool` | `false` | Skips automatic `dotnet restore` after project creation. |
| `--use-program-main` | `bool` | `false` | Generates an explicit `Program` class and `Main` method instead of top-level statements. |
| `--localhost-tld` | `bool` | `false` | Uses the `.dev.localhost` TLD in the local application URL. |

For the complete option list (including advanced template options), run:
```bash
dotnet new mudblazor --help
```

### Visual Studio Templates
The templates can also be used in Visual Studio and should show up in the "Create a new project" template list.
Common options map to Visual Studio's project creation UI, but the CLI examples above are the best reference for advanced combinations and flags.

## Contributing
### Installing directly from Source Code
If you want to test changes to the template source code that haven't been published yet, 
clone the source code and execute the InstallAndBuildAllTemplates.ps1 powershell script
```
git clone https://github.com/MudBlazor/Templates.git
```
If you get an error about the script not being digitally signed use this command to change the security policy for this shell session:
```
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```
