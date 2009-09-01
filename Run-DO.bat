@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-DO.txt TestRunner.exe "-t:DO,EF,NH"
popd
