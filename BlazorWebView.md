# BlazorWebView

Included are some examples for the use of BlazorWebView
This is a method of embedding a specialised web control inside a winforms / wpf application
Then using Mudblazor in the context of a desktop application.


## Requirements

Currently this is experimental in that you will need

  * Visual Studio 2019 Community Preview 16.11.0 or later
    (this can be installed at the same time as stable Studio 2019)
    https://visualstudio.microsoft.com/vs/preview/
  * .Net 6 Preview 4 or later
    https://dotnet.microsoft.com/download/dotnet/6.0
  * The webview2 control
    https://developer.microsoft.com/en-us/microsoft-edge/webview2/#download-section

This seems to work with WinForms and WPF
It may also be possible later on via the .Net Multi-Platform App UI (MAUI) which is also still under development but would allow for cross platform desktop applications.


## Links

  * Blog post on how to setup a winforms / wpf project
  * https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-3/#blazorwebview-controls-for-wpf-windows-forms

  * This is a test application used within the official dotnet / aspnetcore repo
    https://github.com/dotnet/aspnetcore/tree/main/src/Components/WebView/Platforms/WindowsForms


## Browser dev tools

It's possible to open up the embedded browser dev tools within winforms for example
By using Ctrl-Shift-i

  * https://github.com/dotnet/aspnetcore/issues/30524


## Hot Reloading

.Net 6 preview 4 includes a feature for hot reloading CSharp code on the fly.
Although this doesn't yet include the razor page content (That's upcoming as of writing)

  * https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-4/
  * https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/


## Publish

To reduce the file count when publishing
```
# Includes the framework
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true

# Leaves the framework out
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true --no-self-contained
```
