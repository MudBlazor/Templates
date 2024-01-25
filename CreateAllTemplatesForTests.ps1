$tests = Join-Path $PSScriptRoot '/tests'

Remove-Item -LiteralPath $tests -Force -Recurse
New-Item -Path $tests -ItemType Directory

dotnet new install $PSScriptRoot --force

dotnet new mudblazor --interactivity None --output $(Join-Path $tests '/interactivityNone')

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests '/interactivityAuto')
dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'interactivityServer')
dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'interactivityWebAssembly')

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'interactivityAuto_allInteractive') --all-interactive
dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'interactivityServer_allInteractive') --all-interactive
dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'interactivityWebAssembly_allInteractive') --all-interactive

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'interactivityAuto_auth') --auth Individual
dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'interactivityAuto_allInteractive_auth') --all-interactive --auth Individual

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'interactivityAuto_useMain') --use-program-main