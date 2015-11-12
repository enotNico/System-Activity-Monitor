;------------------------------------------------------------------------------
;   ���������� ��������� ���������
;------------------------------------------------------------------------------

; ��� ����������
#define   Name       GetStringFileInfo("..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe", "ProductName")
; ������ ����������
#define   Version    GetStringFileInfo("..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe", "FileVersion")
; �����-�����������
#define   Publisher  GetFileCompany("..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe")
; ��� ������������ ������
#define   ExeName    "System Activity Monitor.exe"

[Setup]
; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{42C8001E-B924-44A3-86BC-D5753EF3E837}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=..\..\..\Setup
OutputBaseFileName={#Name}_{#Version}

;SetupIconFile=F:\Installed Programs\Artua-Mac-Activity-Monitor.ico

; ��������� ������
Compression=lzma
SolidCompression=yes

[Languages]

Name: "english"; MessagesFile: "compiler:Default.isl"; 
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; 


;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]

Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


;------------------------------------------------------------------------------
;   �����, ������� ���� �������� � ����� �����������
;------------------------------------------------------------------------------
[Files]

Source: "..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "..\..\..\System Activity Monitor\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

;Source: "D:\ProjectsVS\Organizer\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

[Icons]

;Name: "{group}\{{Organizer}"; Filename: "{app}\{{Organizer.exe}"

;Name: "{commondesktop}\{{Organizer}"; Filename: "{app}\{{Organizer.exe}"; Tasks: desktopicon

[Code]

[Run]
