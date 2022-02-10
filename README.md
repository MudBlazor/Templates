# ![MudBlazor](content/MudBlazor-GitHub-NoBg.png)
# Blazor Template pre configured with MudBlazor.

[![GitHub](https://img.shields.io/github/license/garderoben/mudblazor?color=%23594ae2&style=flat-square)](https://github.com/Garderoben/MudBlazor.Templates/blob/master/LICENSE)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)
[![Nuget version](https://img.shields.io/nuget/v/MudBlazor.Templates?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.Templates/)
[![Nuget downloads](https://img.shields.io/nuget/dt/MudBlazor.Templates?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.Templates/)

## Prerequisites

- .NET 6
- Visual Studio 2022, JetBrains Rider or VsCode 

## Getting Started
### Installation
```
dotnet new --install MudBlazor.Templates
```
### Usage
```
dotnet new mudblazor --host wasm --name MyApplication
```
### Template Options
Specific template options:
| Options                 | Description                                           | Type                                                                         | Default   |
|-------------------------|-------------------------------------------------------|------------------------------------------------------------------------------|-----------|
| `-ho` \| `--host`       | Project Type                                          | `wasm` \| `wasm-hosted`<br> `wasm-pwa` \| `wasm-pwa-hosted`<br> `server`<br> | `wasm`    |
| `-s` \| `--skipRestore` | Skips the automatic restore of the project on create. | `bool`                                                                       | `false`   |

For none MudBlazor specific options run:
```
dotnet new -h
```

### Visual Studio Templates
The templates can be used in Visual Studio as well and should show up in the list when creating a new project.
![VisualStudioTemplate](content/visual-studio-template.png)

## Default Blazor - Template
![DefaultBlazorTemplate](content/DefaultBlazorTemplate.png)
