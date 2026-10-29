# Ejecutar localmente desde PowerShell; no compartir el archivo generado.
$ErrorActionPreference = 'Stop'
$credencialLocal = $null
$datosLocales = $null
try {
    Add-Type -AssemblyName System.Data
    $credencialLocal = Get-Credential -Message 'Usuario y contraseña de tu conexión MariaDB local (no del login de la aplicación)'
    if ($null -eq $credencialLocal) { return }
    if ([string]::IsNullOrWhiteSpace($credencialLocal.UserName)) {
        Write-Host 'No se guardó configuración: falta usuario.'
        return
    }
    $datosLocales = New-Object System.Data.Common.DbConnectionStringBuilder
    $datosLocales['Server'] = '127.0.0.1'
    $datosLocales['Port'] = 3306
    $datosLocales['Database'] = 'laboratorio_la_2026'
    $datosLocales['User ID'] = $credencialLocal.UserName
    $datosLocales['Password'] = $credencialLocal.GetNetworkCredential().Password
    $carpetaLocal = Join-Path $PSScriptRoot '.local'
    [System.IO.Directory]::CreateDirectory($carpetaLocal) | Out-Null
    $archivoLocal = Join-Path $carpetaLocal 'conexion.ini'
    [System.IO.File]::WriteAllText($archivoLocal, $datosLocales.ConnectionString, [System.Text.UTF8Encoding]::new($false))
    Write-Host 'Configuración local guardada. Compilá nuevamente y elegí Probar conexión y lectura.'
    Write-Host 'No compartas conexion.ini ni las carpetas bin/obj o .local.'
}
catch {
    Write-Host 'No se pudo guardar la configuración local. No se mostraron credenciales.'
}
finally {
    if ($null -ne $datosLocales) { $datosLocales.Clear() }
    $credencialLocal = $null
    $datosLocales = $null
}
