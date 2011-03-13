@echo off
call ..\..\Common\Environment.bat
rem "%MSBuildPath%\MSBuild.exe" /p:Configuration=Debug /v:m
"%MSBuildPath%\MSBuild.exe" /p:Configuration=Release /v:m
