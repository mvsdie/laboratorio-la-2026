# Instalación independiente en notebook Windows x64

Esta guía instala una base nueva y local. La notebook no necesita acceder a la PC de desarrollo. Todos los registros incluidos son ficticios.

## 1. Requisitos

- Windows x64 compatible con .NET 10; revisar la [documentación de instalación de .NET en Windows](https://learn.microsoft.com/en-us/dotnet/core/install/windows).
- MariaDB 11.4 instalado localmente. La versión de desarrollo utilizada fue 11.4.12. Descargar el instalador x64 del sitio oficial de MariaDB; seguir la [guía oficial MSI](https://mariadb.com/docs/server/server-management/install-and-upgrade-mariadb/installing-mariadb/binary-packages/installing-mariadb-msi-packages-on-windows).
- Puerto 3306 disponible, servicio MariaDB iniciado y credenciales propias de esa instalación.
- Una impresora instalada para previsualizar/imprimir; Microsoft Print to PDF permite generar un archivo sin impresora física.
- Para ejecutar el ZIP self-contained no hace falta instalar el runtime .NET. Para compilar/editar sí se requiere SDK .NET 10 y Visual Studio con Desarrollo de escritorio de .NET.

El instalador de MariaDB solicita la contraseña de administración. Elegirla en la notebook y conservarla localmente; no enviarla ni escribirla en los scripts. No habilitar acceso remoto para esta demostración local. HeidiSQL es opcional.

## 2. Descargar y extraer

Desde GitHub, descargar el código con Code → Download ZIP o usar Git. Para ejecutar sin Visual Studio, descargar el ZIP Windows x64 de Releases cuando esté publicado. Extraer **todos** sus archivos en una carpeta escribible de la cuenta Windows, no ejecutar desde dentro del ZIP ni copiar solo el exe.

Los comandos siguientes se ejecutan desde la carpeta del código que contiene README.md, instalacion y src. En el paquete ejecutable esas herramientas también se incluyen junto a la guía.

Si PowerShell bloquea los scripts descargados, revisar sus contenidos y usar `Unblock-File` sobre los scripts de esta entrega; no desactivar globalmente la política de seguridad del equipo. Si la política local sigue siendo Restricted, ejecutar el script revisado mediante `powershell.exe -NoProfile -ExecutionPolicy Bypass -File ".\instalacion\INSTALAR_BASE_LOCAL.ps1" -Paso Esquema -ClienteMariaDB "C:\Program Files\MariaDB 11.4\bin\mariadb.exe"`. Esta opción se limita a ese proceso; adaptar el archivo y sus parámetros para los demás pasos.

## 3. Crear el esquema vacío

Localizar `mariadb.exe` en la carpeta bin de la instalación de MariaDB de la notebook. El siguiente es un ejemplo de ruta del software, no una dependencia del usuario de la PC original; adaptarlo si el instalador eligió otra ubicación.

```powershell
& '.\instalacion\INSTALAR_BASE_LOCAL.ps1' -Paso Esquema `
  -ClienteMariaDB 'C:\Program Files\MariaDB 11.4\bin\mariadb.exe'
```

Introducir el usuario de administración de MariaDB y su contraseña local cuando el cliente la solicite. La contraseña no se agrega al comando ni a un archivo SQL. Se solicita nuevamente para la ejecución posterior a la comprobación.

El script solo conecta a **127.0.0.1:3306** y comprueba que `laboratorio_la_2026` no exista. Si existe, se detiene: no usa DROP ni elimina bases. Crea las 17 tablas con sus índices/FK/CHECK. Si se interrumpe el DDL, no continuar: revisar la instalación incompleta, sin ejecutar cargas o borrados automáticos.

## 4. Configurar la conexión de la aplicación

Para la publicación ejecutable, indicar la carpeta que contiene LaboratorioLA2026.exe:

```powershell
& '.\instalacion\CONFIGURAR_CONEXION_EJECUTABLE.ps1' `
  -CarpetaAplicacion 'D:\Aplicaciones\LaboratorioLA2026'
```

La ruta anterior es un ejemplo; puede ser cualquier carpeta local elegida al extraer el ZIP. Se escribe `conexion.ini` junto al exe. Si ya existe no se sobrescribe. Usar las credenciales **de MariaDB**, distintas del login de L&A.

Para trabajar con código fuente:

```powershell
& '.\src\CONFIGURAR_CONEXION_LOCAL.ps1'
dotnet build '.\src\LaboratorioLA2026.slnx' -c Debug
```

El archivo queda en `src/.local/`, excluido de Git, y se copia al compilar. No copiar la configuración privada de la PC de desarrollo ni subirla a GitHub.

## 5. Inicializar los tres accesos con contraseñas propias

Ejecutar en la publicación:

```powershell
& 'D:\Aplicaciones\LaboratorioLA2026\LaboratorioLA2026.exe' --preparar-tres-usuarios
```

O, desde el código ya compilado:

```powershell
& '.\src\LaboratorioLA2026\bin\Debug\net10.0-windows\LaboratorioLA2026.exe' --preparar-tres-usuarios
```

El asistente solicita localmente la contraseña para `admin` (ADMIN), `recepcion` (RECEPCIONISTA) y `tecnico` (TECNICO). Elegir claves propias, completar los tres pasos y pulsar Crear las tres. La contraseña no tiene un valor predeterminado en esta instalación. MariaDB guarda hash/salt, no texto plano.

Debe hacerse con roles y usuarios vacíos. El asistente se detiene si ya hay cuentas: no reemplaza accesos existentes. En una instalación nueva crea los IDs 1, 2 y 3 requeridos por las referencias administrativas de los datos de ejemplo. También comprueba acceso/permisos; su comprobación de inactividad desactiva temporalmente solo recepción y la reactiva al terminar. Revisar el resultado final antes de cargar los datos.

Si el informe indica un fallo, detenerse; no volver a crear cuentas ni cargar datos encima. No enviar el archivo de configuración o las contraseñas para resolverlo.

## 6. Cargar los datos actuales de demostración

Con el asistente terminado y las tres cuentas activas:

```powershell
& '.\instalacion\INSTALAR_BASE_LOCAL.ps1' -Paso Datos `
  -ClienteMariaDB 'C:\Program Files\MariaDB 11.4\bin\mariadb.exe'
```

Primero comprueba IDs/nombres/roles y que las otras quince tablas estén vacías. Después importa los datos en una transacción. El cliente se ejecuta en modo batch, sin `--force`, para detenerse ante un error; una transacción no confirmada se revierte al cerrar esa conexión. No ejecutar el archivo por fragmentos ni continuar ignorando errores. [Opciones del cliente MariaDB](https://mariadb.com/docs/server/clients-and-utilities/mariadb-client/mariadb-command-line-client).

Se reproducen los registros actuales y sus relaciones. No se copian las claves, hashes o salts de la PC principal. Los precios y coberturas son demostraciones; ningún pago equivale a dinero real.

La precomprobación rechaza repetir la carga cuando ya existen registros. Los scripts no modifican usuarios ni permisos del servidor MariaDB ni bases ajenas al proyecto.

## 7. Verificar y ejecutar

```powershell
& '.\instalacion\INSTALAR_BASE_LOCAL.ps1' -Paso Verificar `
  -ClienteMariaDB 'C:\Program Files\MariaDB 11.4\bin\mariadb.exe'
```

Comparar las cantidades con `docs/RECUENTOS_DEMOSTRACION.json`: 17 tablas, 3 roles/usuarios, 20 pacientes, 22 análisis, 21 órdenes, 20 muestras, ocho cotizaciones y diecinueve detalles, entre otros. Debe haber 17 PK, 29 FK, 42 CHECK y 10 UNIQUE. Las consultas de huérfanos deben devolver cero; stock y cotizaciones no deben devolver anomalías.

Abrir LaboratorioLA2026.exe sin argumentos. Probar conexión y lectura debe informar 17 tablas y conexión cerrada. Ingresar con las claves elegidas. ADMIN ve todos los módulos, RECEPCIONISTA solo los permitidos y TECNICO conserva la consulta/operaciones técnicas autorizadas.

Para revisar el comprobante, abrir orden 6 → cotización: $9.600 de base, descuento 25%, total particular $7.200, NO PAGADO. Desde Facturación, desmarcar Sin cotización para ver históricos. Probar Vista previa A4 antes de imprimir en papel.

## Problemas frecuentes

| Situación | Revisar |
| --- | --- |
| No conecta | Servicio MariaDB de la notebook, puerto 3306, usuario/clave local y permisos para esta base. |
| No existe la base | Paso Esquema, sin reutilizar una instalación parcial. |
| Asistente dice que existen usuarios | No repetirlo; ingresar con las claves de esa instalación o revisar localmente el estado. |
| Datos no se cargan | Resultado de precomprobación, tres cuentas correctas y ausencia de datos previos. |
| Ejecutable no abre | Windows x64 compatible, ZIP completo extraído y archivos no bloqueados. No mezclar binarios de otras versiones. |
| Vista previa falla | Impresora/driver instalado, por ejemplo Microsoft Print to PDF. |
| Totales de bolsillo pendientes | La referencia no confirma cobertura ni aporte de obra social; revisar modo y datos, no inventar cobertura. |

No es necesario conectarse a la PC original en ninguno de estos pasos. No se incluye todavía un manual de estudio o defensa oral.
