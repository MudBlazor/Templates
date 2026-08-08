# A failing dotnet exit code is not a PowerShell error, so without these the script runs to the end and reports the exit code of the last build only.
$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true

$tests = Join-Path $PSScriptRoot '/tests'

Remove-Item -LiteralPath $tests -Force -Recurse -ErrorAction SilentlyContinue
New-Item -Path $tests -ItemType Directory

dotnet new install $(Join-Path $PSScriptRoot '/src/mudblazor') --force 
dotnet new install $(Join-Path $PSScriptRoot '/src/mudblazor-wasm') --force 

dotnet new mudblazor --interactivity None --output $(Join-Path $tests 'InteractivityNone')
dotnet build $(Join-Path $tests '/InteractivityNone') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto')
dotnet build $(Join-Path $tests '/InteractivityAuto') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer')
dotnet build $(Join-Path $tests 'InteractivityServer') /warnaserror

dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'InteractivityWasm')
dotnet build $(Join-Path $tests 'InteractivityWasm') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_Global') --all-interactive
dotnet build $(Join-Path $tests 'InteractivityAuto_Global') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer_Global') --all-interactive
dotnet build $(Join-Path $tests 'InteractivityServer_Global') /warnaserror

dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'InteractivityWasm_Global') --all-interactive
dotnet build $(Join-Path $tests 'InteractivityWasm_Global') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_Auth') --auth Individual
dotnet build $(Join-Path $tests 'InteractivityAuto_Auth') /warnaserror

dotnet new mudblazor --interactivity None --output $(Join-Path $tests 'InteractivityNone_Auth') --auth Individual
dotnet build $(Join-Path $tests 'InteractivityNone_Auth') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer_Auth') --auth Individual
dotnet build $(Join-Path $tests 'InteractivityServer_Auth') /warnaserror

dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'InteractivityWasm_Auth') --auth Individual
dotnet build $(Join-Path $tests 'InteractivityWasm_Auth') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_Global_Auth') --all-interactive --auth Individual
dotnet build $(Join-Path $tests 'InteractivityAuto_Global_Auth') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer_Global_Auth') --all-interactive --auth Individual
dotnet build $(Join-Path $tests 'InteractivityServer_Global_Auth') /warnaserror

dotnet new mudblazor --interactivity WebAssembly --output $(Join-Path $tests 'InteractivityWasm_Global_Auth') --all-interactive --auth Individual
dotnet build $(Join-Path $tests 'InteractivityWasm_Global_Auth') /warnaserror

dotnet new mudblazor --interactivity Server --output $(Join-Path $tests 'InteractivityServer_Auth_LocalDb') --auth Individual --use-local-db
dotnet build $(Join-Path $tests 'InteractivityServer_Auth_LocalDb') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_Auth_LocalDb') --auth Individual --use-local-db
dotnet build $(Join-Path $tests 'InteractivityAuto_Auth_LocalDb') /warnaserror

dotnet new mudblazor --interactivity Auto --output $(Join-Path $tests 'InteractivityAuto_UseMain') --use-program-main
dotnet build $(Join-Path $tests 'InteractivityAuto_UseMain') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone')
dotnet build $(Join-Path $tests 'WasmStandalone') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_Auth_Individual') --auth Individual
dotnet build $(Join-Path $tests 'WasmStandalone_Auth_Individual') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_Auth_B2C') --auth IndividualB2C
dotnet build $(Join-Path $tests 'WasmStandalone_Auth_B2C') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_Auth_SingleOrg') --auth SingleOrg
dotnet build $(Join-Path $tests 'WasmStandalone_Auth_SingleOrg') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_Pwa') --pwa
dotnet build $(Join-Path $tests 'WasmStandalone_Pwa') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_UseMain') --use-program-main
dotnet build $(Join-Path $tests 'WasmStandalone_UseMain') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_Empty') --empty
dotnet build $(Join-Path $tests 'WasmStandalone_Empty') /warnaserror

dotnet new mudblazorwasm --output $(Join-Path $tests 'WasmStandalone_CallsWebApi') --auth IndividualB2C --called-api-url https://example.com/api --called-api-scopes api.read
dotnet build $(Join-Path $tests 'WasmStandalone_CallsWebApi') /warnaserror
