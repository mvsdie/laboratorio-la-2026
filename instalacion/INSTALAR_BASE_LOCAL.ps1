param(
    [Parameter(Mandatory=$true)][ValidateSet('Esquema','Datos','Verificar')][string]$Paso,
    [Parameter(Mandatory=$true)][string]$ClienteMariaDB,
    [string]$UsuarioMariaDB
)
$ErrorActionPreference = 'Stop'
if ([string]::IsNullOrWhiteSpace($UsuarioMariaDB)) { $UsuarioMariaDB = Read-Host 'Usuario de MariaDB de esta notebook' }
if ([string]::IsNullOrWhiteSpace($UsuarioMariaDB)) { throw 'Falta indicar el usuario de MariaDB.' }
$cliente = (Resolve-Path -LiteralPath $ClienteMariaDB).Path
if ([System.IO.Path]::GetFileName($cliente) -notin @('mariadb.exe','mysql.exe')) { throw 'Seleccioná el cliente de consola mariadb.exe de tu instalación.' }
$argumentos = @('--no-defaults','--protocol=tcp','--host=127.0.0.1','--port=3306',"--user=$UsuarioMariaDB",'--password','--batch','--skip-force','--abort-source-on-error','--default-character-set=utf8mb4')
$OutputEncoding = [System.Text.UTF8Encoding]::new($false)

if ($Paso -eq 'Esquema') {
    $consulta = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME='laboratorio_la_2026';"
    Write-Host 'Comprobación previa: el cliente solicitará la contraseña local sin mostrarla.'
    $resultado = & $cliente @argumentos --skip-column-names --execute=$consulta
    if ($LASTEXITCODE -ne 0) { throw 'No se pudo comprobar la ausencia de la base. No se ejecutó la creación.' }
    if (($resultado -join '').Trim() -ne '0') { throw 'laboratorio_la_2026 ya existe. Se detiene sin borrarla ni modificarla.' }
    $archivo = Join-Path $PSScriptRoot '01_ESQUEMA.sql'
}
elseif ($Paso -eq 'Datos') {
    Write-Host 'Primero debe terminar el asistente --preparar-tres-usuarios en una base nueva.'
    $consulta = [System.IO.File]::ReadAllText((Join-Path $PSScriptRoot '00_PREVERIFICAR_DATOS.sql'))
    $resultado = & $cliente @argumentos --skip-column-names --execute=$consulta
    if ($LASTEXITCODE -ne 0) { throw 'No se pudo comprobar la instalación. No se cargaron datos.' }
    if (($resultado -join '').Trim() -ne 'LISTO_PARA_CARGAR') { throw 'Roles/usuarios no coinciden o ya hay datos. No se cargó ni se reemplazó ningún registro.' }
    $archivo = Join-Path $PSScriptRoot '02_DATOS_DEMO.sql'
}
else {
    $archivo = Join-Path $PSScriptRoot '03_VERIFICAR.sql'
}

Write-Host 'Ejecución local: el cliente volverá a solicitar tu contraseña. No uses --force.'
[System.IO.File]::ReadAllText($archivo) | & $cliente @argumentos
if ($LASTEXITCODE -ne 0) { throw 'MariaDB informó un error: se detuvo el cliente. No continuar al siguiente paso. La carga de datos no confirmada se revierte al cerrar la conexión.' }
Write-Host "Paso $Paso completado. Revisá los resultados antes de continuar."
