param([Parameter(Mandatory=$true)][string]$CarpetaAplicacion)
$ErrorActionPreference = 'Stop'
$credencialLocal = $null
$datosLocales = $null
try {
    $carpeta = (Resolve-Path -LiteralPath $CarpetaAplicacion).Path
    if (-not (Test-Path -LiteralPath (Join-Path $carpeta 'LaboratorioLA2026.exe'))) { throw 'No se encontró LaboratorioLA2026.exe en la carpeta seleccionada.' }
    $archivo = Join-Path $carpeta 'conexion.ini'
    if (Test-Path -LiteralPath $archivo) { throw 'Ya existe conexion.ini. No se sobrescribió: revisá primero la configuración local existente.' }
    Add-Type -AssemblyName System.Data
    $credencialLocal = Get-Credential -Message 'Cuenta de MariaDB instalada en ESTA notebook, no usuario de la aplicación'
    if ($null -eq $credencialLocal) { return }
    if ([string]::IsNullOrWhiteSpace($credencialLocal.UserName)) { throw 'Falta indicar el usuario de MariaDB.' }
    $datosLocales = New-Object System.Data.Common.DbConnectionStringBuilder
    $datosLocales['Server'] = '127.0.0.1'
    $datosLocales['Port'] = 3306
    $datosLocales['Database'] = 'laboratorio_la_2026'
    $datosLocales['User ID'] = $credencialLocal.UserName
    $datosLocales['Password'] = $credencialLocal.GetNetworkCredential().Password
    [System.IO.File]::WriteAllText($archivo, $datosLocales.ConnectionString, [System.Text.UTF8Encoding]::new($false))
    Write-Host 'Conexión local configurada. Abrí la aplicación y elegí Probar conexión y lectura.'
    Write-Host 'No publicar conexion.ini. Cada equipo utiliza su propio servidor y sus propias credenciales.'
}
catch {
    Write-Host 'No se completó la configuración. Revisá la carpeta y si ya existe conexion.ini. No se mostraron credenciales.'
    throw 'Configuración local no completada.'
}
finally {
    if ($null -ne $datosLocales) { $datosLocales.Clear() }
    $credencialLocal = $null
    $datosLocales = $null
}
