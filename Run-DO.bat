@echo off
rem call Build.bat
pushd TestRunner\bin\Release
  start /HIGH cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe -t:DO,EF,NH
popd
