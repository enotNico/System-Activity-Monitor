;------------------------------------------------------------------------------
;   Определяем некоторые константы
;------------------------------------------------------------------------------

; Имя приложения
#define   Name       GetStringFileInfo("..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe", "ProductName")
; Версия приложения
#define   Version    GetStringFileInfo("..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe", "FileVersion")
; Фирма-разработчик
#define   Publisher  GetFileCompany("..\..\..\System Activity Monitor\bin\Release\System Activity Monitor.exe")
; Имя исполняемого модуля
#define   ExeName    "System Activity Monitor.exe"

[Setup]
; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{42C8001E-B924-44A3-86BC-D5753EF3E837}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=..\..\..\Setup
OutputBaseFileName={#Name}_{#Version}

;SetupIconFile=F:\Installed Programs\Artua-Mac-Activity-Monitor.ico

; Параметры сжатия
Compression=lzma
SolidCompression=yes

[Languages]

Name: "english"; MessagesFile: "compiler:Default.isl"; 
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; 


;------------------------------------------------------------------------------
;   Опционально - некоторые задачи, которые надо выполнить при установке
;------------------------------------------------------------------------------
[Tasks]

Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


;------------------------------------------------------------------------------
;   Файлы, которые надо включить в пакет установщика
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
