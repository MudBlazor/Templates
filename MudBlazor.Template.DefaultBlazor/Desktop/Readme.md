# Readme

Included are some examples for the use of BlazorWebView
This allows Mudblazor to be used in the context of a desktop application.

BlazorWebView is a method of embedding a specialised web control inside a winforms / wpf / maui application
This is used within the WinForms / WPF / Maui frontends

See [Development.md](./Development.md) for more details on requirements and publishing apps


## Projects

### DefaultBlazor.Desktop.Common

This contains the main content of the application including all the pages / services shared between all the different projects.
The other projects can be thought of as front ends / wrappers for the content within this Razor Class Library.

### DefaultBlazor.Desktop.WinForms

An example of launching via a windows forms applcation
It's main advantage is being simple to setup, the main downside being windows only.

### DefaultBlazor.Desktop.Wpf

An example of launching via a wpf application.
It's main advantage is being simple to setup, the main downside being windows only.

### DefaultBlazor.Desktop.Web

An example of just launching as a website.
currently this is useful for razor page hot reloading where you want to edit razor content on the fly.

### DefaultBlazor.Desktop.Chromely

This is an example using the Chromely library to host the application.
If you want something that will work under Linux then this is probably the best way to do it at the moment.
Chromely in some ways is very similar to the Microsoft approach of using WebView2.
Instead they use libcef which is part of chrome

Note when publishing if you try to use the publish to single file option.
Then this will prevent the automatic download of libcef files / runtime.
In which case those libcef files need to be bundled with the app otherwise

Upsides:

  * Currently works with Linux
  * Can implement a frameless window with a drag area
  * Can be run as a website

Downsides:

  * Requires the use of a TCP port between the backend and frontend code
    So the IPC may be less direct that WebView2
  * I think it bundles libcef with the application or tries to download it if not present
    which can make the size of the application bigger (this is the equivilent of the webview2 runtime)
