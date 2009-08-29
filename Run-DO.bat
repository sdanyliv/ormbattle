@echo off
pushd TestRunner\bin\Release
  start /HIGH cmd /C ..\..\..\Redirect.bat ..\..\..\Output-DO.txt TestRunner.exe -t:DO,EF,NH
popd
