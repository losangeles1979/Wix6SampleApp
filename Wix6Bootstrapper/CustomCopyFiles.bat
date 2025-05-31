:: This is a comment in a batch file (like rem)

:: Create the target directory first
:: (it's OK if it already exists)
mkdir "C:\Users\Public\Documents\Satprac\Harvested"


:: Copy one file to the target directory
copy "C:\Program Files (x86)\Satprac\Harvested\CppProject.ilk" "C:\Users\Public\Documents\Satprac\Harvested\CppProject.ilk" /Y


:: How to copy an entire directory (xcopy)
:: xcopy "C:\TEMP\Textfiles" "C:\Users\Public\Documents\Satprac\Textfiles" /S /Q /Y /I


:: How to remove an existing directory
:: rmdir /S /Q "C:\Temp\MyApp"


:: We can also restart a Windows Service
:: SC STOP "MyService"
:: SC START "MyService"


:: We can also kick off an InstallShield Suite build!
:: "C:\Program Files (x86)\InstallShield\2015 SAB\System\IsCmdBld.exe" -p "C:\TEMP\ISprojects\MyProgramSuite.issuite"


:: Update the registry to simulate an installed 2015 C++ Redistributable.
:: This could be a temporary workaround if an install program requires these registry entries for testing purposes.
:: REG ADD "HKLM\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\14.0\VC\Runtimes\x64" /f /v "Installed" /t REG_DWORD /d 1
:: REG ADD "HKLM\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\14.0\VC\Runtimes\x86" /f /v "Installed" /t REG_DWORD /d 1
