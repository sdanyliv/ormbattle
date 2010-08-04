@echo off
pushd "%~dp0"
  call Common\Environment.bat
  call :Start %*
popd
goto :End

:Start
"%MSBuildPath%\MSBuild.exe" /t:Clean /v:m %*
"%MSBuildPath%\MSBuild.exe" /t:Clean /p:Configuration=Release /v:m %*
goto :End

:End
