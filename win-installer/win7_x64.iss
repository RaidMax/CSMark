; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{64C3B2C6-57C9-4C9A-8FA5-190BAFB6C508}
AppName=CSMark
AppVersion=0.15.0
;AppVerName=CSMark 0.15.0
AppPublisher=AluminiumTech
AppPublisherURL=http://www.github.com/CSMarkBenchmark/CSMark/
AppSupportURL=http://www.github.com/CSMarkBenchmark/CSMark/
AppUpdatesURL=http://www.github.com/CSMarkBenchmark/CSMark/releases/
DefaultDirName={pf}\CSMark
DisableProgramGroupPage=yes
LicenseFile=D:\Documents\GitHub\CSMark\win-installer\License.txt
InfoBeforeFile=D:\Documents\GitHub\CSMark\win-installer\Installer_Welcome.txt
InfoAfterFile=D:\Documents\GitHub\CSMark\win-installer\Installer_End.txt
OutputDir=D:\Documents\GitHub\CSMark\CSMarkRedux\bin\Release\netcoreapp2.0
OutputBaseFilename=CSMark0.15.0_Setup_Win7-x64
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Documents\GitHub\CSMark\CSMarkRedux\bin\Release\netcoreapp2.0\win7-x64\CSMarkRedux.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Documents\GitHub\CSMark\CSMarkRedux\bin\Release\netcoreapp2.0\win7-x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\CSMark"; Filename: "{app}\CSMarkRedux.exe"
Name: "{commondesktop}\CSMark"; Filename: "{app}\CSMarkRedux.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\CSMarkRedux.exe"; Description: "{cm:LaunchProgram,CSMark}"; Flags: nowait postinstall skipifsilent
