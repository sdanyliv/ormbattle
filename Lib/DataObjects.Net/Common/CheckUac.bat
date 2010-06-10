@echo off
set UacCheckFile=%ProgramFiles%\DataObjects.Net UAC check.tmp
echo UAC check test > "%UacCheckFile%" 2>nul
if not exist "%UacCheckFile%" (
  echo. 
  echo Error: User Account Control is turned on, but this program 
  echo requires Administrator permissions.
  echo. 
  echo You must:
  echo - Either turn off User Account Control: 
  echo   Go to Control Panel\User Accounts and Family Safety\User Accounts,
  echo   open "Change User Account Control settings", set the notification
  echo   level to "Never notify" and reboot the PC.
  echo - Or run the program with Administrator permissions:
  echo   Right-click on the program file or shortcut and select "Run as
  echo   administrator". Alternatively, you can run the process executing
  echo   it by this way - for example, cmd.exe.
  exit 1
) else (
  del /Q "%UacCheckFile%" >nul 2>nul
)
