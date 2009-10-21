@echo off
pushd "%~dp0"
  call :Start %*
popd
goto :End

:Start
rem Tool paths (manual)
set HtmlHelp1SDKPath=%ProgramFiles%\Microsoft Help 1.0 SDK
set HtmlHelp2SDKPath=%ProgramFiles%\Microsoft Help 2.0 SDK 2008
set SandcastlePath=%ProgramFiles%\Sandcastle

rem Tool paths (automatic)
call :SetRegPath MSBuildPath "HKLM\SOFTWARE\Microsoft\MSBuild\ToolsVersions\3.5" /v MSBuildToolsPath 2>nul
call :DotPath MSBuildPath
rem call :SetRegPath PostSharpPath "HKLM\SOFTWARE\postsharp.org\PostSharp 1.0" /v Location 2>nul
rem call :DotPath PostSharpPath
rem call :SetRegCmdPath SandcastleBuilderPath "HKLM\SOFTWARE\Classes\Sandcastle Help File Builder Project\shell\open\command" /ve 2>nul
rem call :DotPath SandcastleBuilderPath
set SandcastleBuilderPath=%SHFBROOT%.
rem call :SetRegPath InnoSetupPath "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Inno Setup 5_is1" /v "InstallLocation" 2>nul
rem call :DotPath InnoSetupPath
rem call :SetRegSrvPath TortoiseSVNPath "HKLM\SOFTWARE\Classes\CLSID\{30351346-7B7D-4FCC-81B4-1E394CA267EB}\InProcServer32" /ve 2>nul
rem call :DotPath TortoiseSVNPath
rem set SubWCRevPath=%TortoiseSVNPath%\SubWCRev.exe
rem set WixPath=%WIX%bin

rem Visual Studio 2008 & .NET paths (automatic)
call :SetRegPath DevEnv2008Path "HKLM\SOFTWARE\Microsoft\VisualStudio\9.0" /v InstallDir 2>nul
call :DotPath DevEnv2008Path
set TextTransformPath=%ProgramFiles%\Common Files\Microsoft Shared\TextTemplating\1.2
set DotNetFramework20Path=%SystemRoot%\Microsoft.NET\Framework\v2.0.50727 
set DotNetFramework35Path=%SystemRoot%\Microsoft.NET\Framework\v3.5

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
