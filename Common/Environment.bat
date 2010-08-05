@echo off
pushd "%~dp0"
  if not "%EnvironmentReady%"=="" goto :End
  call :Start %*
popd
goto :End

:Start
rem Windows XP+ 64-bit mode detection
if not "%PROCESSOR_ARCHITEW6432%"=="" set Is64Bit=true
rem Windows 7 64-bit mode detection
if not "%ProgramW6432%"=="" (
  if "%ProgramFiles%"=="%ProgramW6432%" set Is64Bit=true
)
rem Conditional variables
set CommonFiles=%CommonProgramFiles%
if "%Is64Bit%"=="true" set Wow6432Key=Wow6432Node\
if "%Is64Bit%"=="true" set CommonFiles=%CommonProgramFiles(x86)%

rem Tool paths (manual)

rem Tool paths (automatic)
call :SetRegPath MSBuildPath "HKLM\SOFTWARE\%Wow6432Key%Microsoft\MSBuild\ToolsVersions\4.0" /v MSBuildToolsPath 2>nul
call :DotPath MSBuildPath

rem Visual Studio 2008 & .NET paths (automatic)
call :SetRegPath DevEnv2008Path "HKLM\SOFTWARE\%Wow6432Key%Microsoft\VisualStudio\9.0" /v InstallDir 2>nul
call :DotPath DevEnv2008Path
call :SetRegPath DevEnv2010Path "HKLM\SOFTWARE\%Wow6432Key%Microsoft\VisualStudio\10.0" /v InstallDir 2>nul
call :DotPath DevEnv2010Path
set TextTransformPath=%CommonFiles%\Microsoft Shared\TextTemplating\10.0
set DotNetFramework20Path=%SystemRoot%\Microsoft.NET\Framework\v2.0.50727 
set DotNetFramework35Path=%SystemRoot%\Microsoft.NET\Framework\v3.5
set DotNetFramework40Path=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
call :SetRegPath DotNetSdk20Path "HKLM\SOFTWARE\%Wow6432Key%Microsoft\.NETFramework" /v sdkInstallRootv2.0 2>nul
call :DotPath DotNetSdk20Path

rem This allows to override the envorinment for a particular PC\User\Domain
set LocalEnvironment1=Environment.%COMPUTERNAME%.bat
set LocalEnvironment2=Environment.%COMPUTERNAME%-%USERNAME%@%USERDOMAIN%.bat
if exist "%LocalEnvironment1%" call "%LocalEnvironment1%"
if exist "%LocalEnvironment2%" call "%LocalEnvironment2%"

set EnvironmentReady=true
echo Environment is ready.
goto :End

:SetRegPath
for /F "skip=2 tokens=3* eol=" %%i in ('reg query %2 %3 %4 %5 %6 %7 %8 %9') do (
  if not "%%j"=="" set %1=%%i %%j
  if "%%j"=="" set %1=%%i
)
goto :End

:SetRegCmdPath
call :SetRegPath _Tmp_Cmd_ %2 %3 %4 %5 %6 %7 %8 %9
call :SetCmdPath %1 %_Tmp_Cmd_%
set _Tmp_Cmd_=
goto :End

:SetRegSrvPath
call :SetRegPath _Tmp_Cmd_ %2 %3 %4 %5 %6 %7 %8 %9
call :SetCmdPath %1 "%_Tmp_Cmd_%"
set _Tmp_Cmd_=
goto :End

:SetCmdPath
set %1=%~d2%~p2
goto :End

:DotPath
set Error=1
call :InnerDotPath %1 2>nul
if "%Error%"=="1" echo Can't detect %1. Most likely the tool is not installed.
goto :End

:InnerDotPath
for /F "tokens=2* delims== eol=" %%i in ('set %1') do (
  if not "%%j"=="" set %1=%%i=%%j.
  if "%%j"=="" set %1=%%i.
  set Error=0
)
goto :End

:End
