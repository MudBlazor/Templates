$tests = Join-Path $PSScriptRoot '/tests'

Remove-Item -LiteralPath $tests -Force -Recurse -ErrorAction SilentlyContinue
New-Item -Path $tests -ItemType Directory

dotnet new install $(Join-Path $PSScriptRoot '/src/mudblazor') --force 

dotnet new mudblazor --interactivity None --output $(Join-Path $tests 'InteractivityNone')
dotnet build $(Join-Path $tests '/InteractivityNone') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests '/InteractivityAuto')
dotnet build $(Join-Path $tests '/InteractivityAuto') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer')
dotnet build $(Join-Path $tests 'InteractivityServer') /warnaserror

dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'InteractivityWebAssembly')
dotnet build $(Join-Path $tests 'InteractivityWebAssembly') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_AllInteractive') --all-interactive
dotnet build $(Join-Path $tests 'InteractivityAuto_AllInteractive') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer_AllInteractive') --all-interactive
dotnet build $(Join-Path $tests 'InteractivityServer_AllInteractive') /warnaserror

dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'InteractivityWebAssembly_AllInteractive') --all-interactive
dotnet build $(Join-Path $tests 'InteractivityWebAssembly_AllInteractive') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_Auth') --auth Individual
dotnet build $(Join-Path $tests 'InteractivityAuto_Auth') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_AllInteractive_Auth') --all-interactive --auth Individual
dotnet build $(Join-Path $tests 'InteractivityAuto_AllInteractive_Auth') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_UseMain') --use-program-main
dotnet build $(Join-Path $tests 'InteractivityAuto_UseMain') /warnaserror