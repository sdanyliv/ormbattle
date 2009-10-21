@echo off
pushd "%~dp0"
  call Common\Environment.bat
  call :Start %*
popd
goto :End

:Start
"%MSBuildPath%\MSBuild.exe" /p:Configuration=Release 
goto :End

:End
