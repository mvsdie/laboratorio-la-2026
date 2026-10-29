param([string]$Destino)
$ErrorActionPreference = 'Stop'
if (-not [Environment]::Is64BitOperatingSystem) { throw 'Esta publicación está destinada a Windows x64.' }
$raiz = Split-Path -Parent $PSScriptRoot
$proyecto = Join-Path $raiz 'src/LaboratorioLA2026/LaboratorioLA2026.vbproj'
$versiones = Join-Path (Split-Path -Parent $proyecto) 'packages.win-x64.lock.json'
if ([string]::IsNullOrWhiteSpace($Destino)) { $Destino = Join-Path $raiz 'publicacion/win-x64' }
if (Test-Path -LiteralPath $Destino) { throw 'Elegí una carpeta de salida nueva; no se sobrescriben publicaciones anteriores.' }
& dotnet publish $proyecto -c Release -r win-x64 --self-contained true -p:PublishSingleFile=false -p:PublishTrimmed=false -p:DebugType=None -p:DebugSymbols=false "-p:NuGetLockFilePath=$versiones" -p:RestoreLockedMode=true -o $Destino
if ($LASTEXITCODE -ne 0) { throw 'Falló la publicación.' }
$privado = Get-ChildItem -LiteralPath $Destino -Recurse -Force -File | Where-Object { $_.Name -in @('conexion.ini','ACCESOS_DEMOSTRACION.txt','accesos_demostracion.json') }
if ($privado) { throw 'La salida contiene configuración privada. No distribuirla.' }
Write-Host 'Publicación Windows x64 completa. Distribuir toda la carpeta, no solo el exe. MariaDB se instala aparte.'
