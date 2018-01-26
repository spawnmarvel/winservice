#Template for windows service

Put the install.bat and uinstall.bat in the same folder as .exe file:
WindowsServiceTemplate.exe

###install:
REM echo off
REM Install the application as a windows service

REM Service Name
set service_name=WindowsServiceTemplate

REM Service location
set path=%~dp0
set file=WindowsServiceTemplate.exe

REM Path to Sc.exe tool (Service Controller)
set sc_path=%windir%\system32
set fullPath=%path%%file%

REM CREATE the service WITHOUT DEPENDANT
%sc_path%\sc.exe create "%service_name%" binPath= "%fullPath%" start= auto

:EOF
pause
exit

###uinstall:

echo off
REM UnInstall the application as a windows service
set service_name=WindowsServiceTemplate
set sc_path=%windir%\system32
%sc_path%\sc.exe stop "%service_name%"
%sc_path%\sc.exe delete "%service_name%"

pause
exit