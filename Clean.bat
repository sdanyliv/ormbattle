@echo off
msbuild /t:Clean
msbuild /t:Clean /p:Configuration=Release 
