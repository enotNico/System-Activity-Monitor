
#define   Name       "System Activity Monitor"

#define   Publisher  "Nick Kravch"

#define   ExeName    "System Activity Monitor.exe"

#define Version GetFileVersion("C:\projects\system-activity-monitor-new\System Activity Monitor\bin\Debug\System Activity Monitor.exe")


[Setup]

AppId={{42C8001E-B924-44A3-86BC-D5753EF3E837}

AppName={#Name}
AppVerName={#ExeName} {#Version}
AppVersion={#Version}

DefaultDirName={pf}\{#Name}
DefaultGroupName={#Name}

OutputDir=..\..\..\Setup
OutputBaseFileName=projsetup0.0.1

;SetupIconFile=F:\Installed Programs\Artua-Mac-Activity-Monitor.ico

Compression=lzma
SolidCompression=yes

[Languages]

Name: "english"; MessagesFile: "compiler:Default.isl"; 
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; 

[Tasks]

Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

Source: "C:\projects\system-activity-monitor-new\System Activity Monitor\bin\Debug\System Activity Monitor.exe"; DestDir: "{app}"; Flags: ignoreversion

;Source: "D:\ProjectsVS\Organizer\Organizer\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

;Source: "D:\ProjectsVS\Organizer\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

[Icons]

;Name: "{group}\{{Organizer}"; Filename: "{app}\{{Organizer.exe}"

;Name: "{commondesktop}\{{Organizer}"; Filename: "{app}\{{Organizer.exe}"; Tasks: desktopicon

[Code]

[Run]
