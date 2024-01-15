# ![MudBlazor](content/MudBlazor-GitHub-NoBg.png)
# Blazor Template pre-configured with MudBlazor.

[![GitHub](https://img.shields.io/github/license/garderoben/mudblazor?color=%23594ae2&style=flat-square)](https://github.com/Garderoben/MudBlazor.Templates/blob/master/LICENSE)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)
[![Nuget version](https://img.shields.io/nuget/v/MudBlazor.Templates?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.Templates/)
[![Nuget downloads](https://img.shields.io/nuget/dt/MudBlazor.Templates?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.Templates/)

We're excited to announce the availability of a new template for .NET 8 Web Apps: the MudBlazor Web App template. This template is based on the Microsoft Web App template, but has been modified to include MudBlazor components.

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022, JetBrains Rider or Visual Studio Code 

## Getting Started
### Installation
```
dotnet new install MudBlazor.Templates
```
## Usage
### Interactive per Page
```
dotnet new mudblazor --interactivity (Auto|Server|WebAssembly)
```

### Interactive Global
```
dotnet new mudblazor --interactivity (Auto|Server|WebAssembly) --all-interactive
```

### Adding Authentication
```
dotnet new mudblazor --interactivity Auto --auth Individual
dotnet new mudblazor --interactivity Auto --auth Individual --all-interactive
```

### Visual Studio Templates
The templates can also be used in Visual Studio and should show up in the list when creating a new project.

## To Do for the .NET 8 Template

- Integrate MudBlazor components into the authentication system (currently using Bootstrap components from the original template)
