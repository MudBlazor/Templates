# TODO


## .Net MAUI

MAUI Should allow for applications that can be published to IOS / Android / MacOS / Linux etc
Since MAUI should have support for BlazorWebView

  * https://devblogs.microsoft.com/dotnet/announcing-net-maui-preview-5/
  * https://www.c-sharpcorner.com/article/getting-started-with-maui-xamarin-forms-application-using-visual-studio-2019-pre/
  * https://luismts.com/msbuild-dotnetmaui-preview-4/


## Frameless Window

For a frameless window (where you implement the top bar yourself instead of using the default winform / wpf title bar)
Currently it's possible to add a close / maximise / restore button to the top right hand side using a custom AppBar
However implementing a drag area seems to be a problem, in that BlazorWebView overrides anything undereath including with WPF

  * https://github.com/dotnet/maui/issues/1304
  * https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/distribution#fixed-version-distribution-mode


## WebView2 Standalone

BlazorWebView relies on the use of a control called WebView2
In theory it should be possible to install this control in one of two ways

  * Evergreen distribution mode - this is where you just install the runtime onto the machine so that it can be used by all projects
  * Fixed Version distribution mode - this is where you download / extract the WebView2 control to a directory
    then reference the directory directly from CSharp. This is useful where you want to bundle a specific version with the app
    or avoid the need for installing the WebView2 control as a seperate entity

Currently I've only managed to get things working via the Evergreen distribution mode.
For the fixed version mode it seems to have problems finding the specified directory
this may be related to BlazorWebView acting as a wrapper on top of WebView2.

  * https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/distribution

It's probably best to wait until .Net6 is released fully before seeing if there's a workaround for this.
