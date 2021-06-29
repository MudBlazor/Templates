# Development.Maui

MAUI Should allow for applications that can be published to IOS / Android / MacOS etc via BlazorWebView
However it seems to lack Linux support currently.
That being said Chromely can be used to cover linux.

  * https://www.youtube.com/watch?v=_rNfdhUpg3g
  * https://devblogs.microsoft.com/dotnet/announcing-net-maui-preview-5/
  * https://www.c-sharpcorner.com/article/getting-started-with-maui-xamarin-forms-application-using-visual-studio-2019-pre/
  * https://luismts.com/msbuild-dotnetmaui-preview-4/


## General Setup

### Adding the needed extensions

First we need to add a couple of extensions to Visual Studio
These are needed for the WinUI target of MAUI

  * Project Reunion
    In the youtube clip it recommends the preview version, but I think the non preview version is now ahead with a later version number
  * Single Project MSIX Packaging Tools

### Installing the Android SDK

  * Open up the Visual Studio Installer
  * Select Visual Studio 2019 Preview / Modify

Under Workloads

  * Tick Mobile Development With .Net

### Adding the MAUI Preview Nuget Source

Next we need to make sure Visual Studio 2019 Preview uses the MAUI preview Nuget source
```
dotnet nuget add source -n maui-preview https://aka.ms/maui-preview/index.json
```

### Running the MAUI Check App

Next is to run from the Visual Studio 2019 Preview command line the maui-check
```
dotnet tool install -g redth.net.maui.check
maui-check
```

## Android Setup

### Setting up Hyper-V or HAXM

In order to run the Android emulator at a decent speed we need one of two things

  * Hyper-V to be enabled
  * HAXM which is a driver for intel chips that allows acceleration without Hyper-V enabled
    https://github.com/intel/haxm/releases

Personally I've found HAXM to be the best option (although it does require an Intel Processor).
It avoids the need for Hyper-V which can have a performance impact on your machine if used for gaming for example.
The setup is farily straightforward with just running the setup exe

To show if Haxm is running after install
```
sc query intelhaxm
```

### Setting up an Android Emulator

  * https://docs.microsoft.com/en-gb/xamarin/android/get-started/installation/android-emulator/device-manager?tabs=windows&pivots=windows

Under Visual Studio 2019 Preview

  * Select Tools -> Android -> Android Device Manager
  * Select New

At this point you can leave the options at the defaults if you want.
Then just click create

Note when starting for the first time, if you don't have Hyper-V enabled it can take a while to startup


## Things to watch out for

### Path too Deep Errors

Sometimes if the directory you have cloned the source into is too deep
This can result in strange build errors for Android

  * https://docs.microsoft.com/en-us/answers/questions/313806/why-am-i-getting-this-error-on-a-new-xamarin-forms.html

### blazor.webview.js autostart

One thing that's required to work under Android at least is to make sure in the index.html
that autostart is set to false for blazor.webview.js
Otherwise things will work for WinUI but not mobile

```
<script src="_framework/blazor.webview.js" autostart="false"></script>
```

## Other bits

  * Not tested IOS / Macos since I don't have one of those handy
  * I've managed to launch to an Android emulator but the debug session seems to disconnect for some reason, that might just be my machine.
  * upgrading the ProjectReunion Nuget packages in DefaultBlazor.Desktop.Maui.WinUI from 0.8-preview to 0.8 seems to break the build
