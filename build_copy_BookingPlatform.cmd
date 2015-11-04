@ECHO OFF

PUSHD %~dp0

:dnvminstall
SETLOCAL EnableDelayedExpansion 
where dnvm
IF %ERRORLEVEL% neq 0 (
    @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"
        SET PATH=!PATH!;!userprofile!\.dnx\bin
            SET DNX_HOME=!USERPROFILE!\.dnx
                GOTO install
                )

:install
CALL dnvm install 1.0.0-beta8 -r CoreCLR
CALL dnvm install 1.0.0-beta8 -r CLR
CALL dnvm use 1.0.0-beta8 -r CoreCLR

:restore
CALL dnu restore src\Domain
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu restore src\Infra
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu restore src\Test.Domain
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu restore src\Test.Infra
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu restore src\WebApi
IF %errorlevel% neq 0 EXIT /b %errorlevel%

:pack
SETLOCAL ENABLEEXTENSIONS
IF ERRORLEVEL 1 ECHO Unable to enable extensions
IF DEFINED APPVEYOR_BUILD_NUMBER (SET DNX_BUILD_VERSION=%APPVEYOR_BUILD_NUMBER%) ELSE (SET DNX_BUILD_VERSION=1)
ECHO DNX_BUILD_VERSION=%DNX_BUILD_VERSION%

CALL dnu pack src\Domain --configuration Release --out artifacts\packages
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu pack src\Infra --configuration Release --out artifacts\packages
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu publish src\Test.Domain --out artifacts\endUserPortal --runtime active
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu publish src\Test.Infra --out artifacts\endUserPortal --runtime active
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnu publish src\WebApi --out artifacts\endUserPortal --runtime active
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL 7z a endUserPortal.zip %APPVEYOR_BUILD_FOLDER%\artifacts\endUserPortal\*
IF %errorlevel% neq 0 EXIT /b %errorlevel%

:test
CALL dnvm use 1.0.0-beta8 -r CoreCLR

CALL dnx src\Test.Domain test -xml .\xunit-results.xml
IF %errorlevel% neq 0 EXIT /b %errorlevel%

CALL dnvm use 1.0.0-beta8 -r CoreCLR

CALL dnx src\Test.Infra test -xml .\xunit-results-core.xml
IF %errorlevel% neq 0 EXIT /b %errorlevel%

POPD