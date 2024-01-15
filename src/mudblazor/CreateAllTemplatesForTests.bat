dotnet new install .\ --force
c:
MD C:\temp\tests\mudTemplates
CD C:\temp\tests\mudTemplates

RD /S /Q interactivityNone

RD /S /Q interactivityAuto
RD /S /Q interactivityServer
RD /S /Q interactivityWebAssembly

RD /S /Q interactivityAuto_allInteractive
RD /S /Q interactivityServer_allInteractive
RD /S /Q interactivityWebAssembly_allInteractive

RD /S /Q interactivityAuto_auth
RD /S /Q interactivityAuto_allInteractive_auth

RD /S /Q interactivityAuto_useMain

dotnet new mudblazorwebapp --interactivity None --output C:\temp\tests\mudTemplates\interactivityNone

dotnet new mudblazorwebapp --interactivity Auto --output C:\temp\tests\mudTemplates\interactivityAuto
dotnet new mudblazorwebapp --interactivity Server --output C:\temp\tests\mudTemplates\interactivityServer
dotnet new mudblazorwebapp --interactivity WebAssembly --output C:\temp\tests\mudTemplates\interactivityWebAssembly

dotnet new mudblazorwebapp --interactivity Auto --output C:\temp\tests\mudTemplates\interactivityAuto_allInteractive --all-interactive
dotnet new mudblazorwebapp --interactivity Server --output C:\temp\tests\mudTemplates\interactivityServer_allInteractive --all-interactive
dotnet new mudblazorwebapp --interactivity WebAssembly --output C:\temp\tests\mudTemplates\interactivityWebAssembly_allInteractive --all-interactive

dotnet new mudblazorwebapp --interactivity Auto --output C:\temp\tests\mudTemplates\interactivityAuto_auth --auth Individual
dotnet new mudblazorwebapp --interactivity Auto --output C:\temp\tests\mudTemplates\interactivityAuto_allInteractive_auth --all-interactive --auth Individual

dotnet new mudblazorwebapp --interactivity Auto --output C:\temp\tests\mudTemplates\interactivityAuto_useMain --use-program-main

cd %~dp0