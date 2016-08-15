###================================================ CliniQ - Clinic Queue Management System =====================================================###

A. History
This is brand new project of Clinic Queue Management System, will add BPJS webservice support, barcode scanner, local chat client, an queue caller/display, etc.
This apps store patient data in DBMS. The data is used for both doctor and nurses to:
- for nurse, apps is use for calling patient and then "send" it to:
- for doctor, apps will "send" patient from front (nurses desk) to back (examination/doctor room)
- for apothecary, apps used for stored purcase history of drug and other medical stuff (only stored purcase history not manage them).
The original application use timed query to communicate with another client apps, in the future we will develop an tcp/udp chat broadcast to let apps communicate
each other.

B. System Requirement
This application need to be run on system that can run:
- Microsoft Windows 7/8/8.1/10 with minimum .net framework version 4.6 and above 
- This application is currently developed under .deb based Linux distro (Debian 8.X, Ubuntu 14.X and above, LXLE) but it MIGHT run as well on other linux distro
  that run mono 4.x.
- We currently unable to create instalation package, so we still deploy application with manual method, this include place a mandatory .dll files same as deployment
  directory. Later will be covered in System Instalation section. The mandatory .dlls are:
	1. cipher.dll
	2. MySql.Data.dll
	3. mysql_connector.dll
- Later will be explained in DLL's And Other Library Function.

C. System Instalation
This application cannot be installed in conventional way (use installer), instead must be manually deploy use debug generate files. Expert or skilled software technician 
is needed for application deployment. For advance user, application deployment can be dealt with:
- Copy the Debug folder to the directory that suit you.
- Make sure following .dll's are in place:
	1. cipher.dll
	2. MySql.Data.dll
	3. mysql_connector.dll
- Make shortcut to application .exe, in Microsoft Windows: Right click application .exe, select send to > desktop (create shortcut)
  In .deb based distro:
	1. Make shell script file:
	2. Nano application.sh, writedown the following:
		#!/bin/sh
		/usr/bin/mono /home/user/Debug/application.exe
	3. Save file with ctrl+x, y, enter
	4. Create application.desktop file, nano application.desktop and write down the following:
		[Desktop Entry]
		Version=1.0
		Type=Application
		Terminal=true
		Name=Application_name
		Icon=/home/user/icon_folder/icon.svg
		Exec=/home/user/application.sh
		Terminal=false
		Categories=Utility;Application;
	5. Save file with ctrl+x, y, enter
	
D. DLL's And Other Library Functions
This application currently use:
	1. cipher.dll, contain function to encrypt string value. Used to secure connection string and other confidential data.
	2. MySql.Data.dll, the official .dll from dev.mysql.com. Used in mysql_connector.dll and in main application, to connect to mysql server.
	3. mysql_connector.dll, contain function to maintain and manage routine sql transaction.

E. Future Development
We will try to expand this application to next level as it will:
	1. Suport BPJS webservices, to get BPJS Kepesertaan data.
	2. TCP/UDP chat to communicate to other client application, this will eliminate current way to communicate use timed query.
	3. Barcode scanned recognition, to ease nurse job when entry the patient ID.
	4. Advance apothecary function, such as pricing, and stock handling.
	5. It will be version 2 of this application
	
F. License
This application is licensed under the terms of the MIT license