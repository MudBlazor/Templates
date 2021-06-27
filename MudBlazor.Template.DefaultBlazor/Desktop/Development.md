# Development

## Requirements

Currently this is experimental in that you will need

  * Visual Studio 2019 Community Preview 16.11.0 or later
    (this can be installed at the same time as stable Studio 2019)
    https://visualstudio.microsoft.com/vs/preview/
  * .Net 6 Preview 5 or later
    https://dotnet.microsoft.com/download/dotnet/6.0
  * The webview2 control
    https://developer.microsoft.com/en-us/microsoft-edge/webview2/#download-section

This seems to work with WinForms and WPF
It may also be possible later on via the .Net Multi-Platform App UI (MAUI) which is also still under development
but would allow for cross platform desktop applications.


## Browser dev tools

It's possible to open up the embedded browser dev tools within winforms by using Ctrl-Shift-i

  * https://github.com/dotnet/aspnetcore/issues/30524


## Hot Reloading

.Net 6 preview 5 includes a feature for hot reloading CSharp code on the fly.
Although this does not yet include the razor page content (That's upcoming as of writing)

  * https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-4/
  * https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/

One way to get hot reloading of the razor content is to launch the app via DefaultBlazor.Desktop.Web
using the "UI Watch" launch profile, this uses dotnet watch to launch the site.
You won't be able to debug the CSharp code, but this method is useful for editing the razor content / design on the fly.


## Loading in pages from multiple libraries

Normally a blazor app only looks within it's own assembly for pages.
Since we use pages from a seperate library such as DefaultBlazor.Desktop.Shared
We need to indicate which libraries to look for when looking for razor content.

Typically this can be speciied within the AdditionalAssemblies properties of the router.

**App/AppRoot.razor**
```
<Router AppAssembly="@typeof(Program).Assembly"
        AdditionalAssemblies="new[] { typeof(MainLayout).Assembly }"
        PreferExactMatches="@true">

```


## Publish

To reduce the file count when publishing
```
# Includes the framework
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true

# Leaves the framework out
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true --no-self-contained
```


## Links

  * Blog post on how to setup a winforms / wpf project
  * https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-3/#blazorwebview-controls-for-wpf-windows-forms

  * This is a test application used within the official dotnet / aspnetcore repo
    https://github.com/dotnet/aspnetcore/tree/main/src/Components/WebView/Platforms/WindowsForms

  * ASP.NET Core Razor components
    https://docs.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-5.0

  * ASP.NET Core Blazor data binding
    https://docs.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-5.0
    https://blazor-university.com/components/one-way-binding/
    https://blazor-university.com/components/two-way-binding/

  * ASP.NET Core Blazor event handling
    https://docs.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-5.0
