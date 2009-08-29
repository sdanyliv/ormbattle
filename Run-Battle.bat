@echo off
pushd TestRunner\bin\Release
  start /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe -t:EF,LS,NH,OA,SS
popd
