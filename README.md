# Send-Fax-in-CSharp
This is all about sending Faxes in c# 


# Tasks to do before using the Code
You need to confirm few configurations, which can be found at https://www.codeproject.com/Articles/1159834/Send-Fax-with-fax-modem-in-Csharp, before you start using the code.


# Development Tools
- Visual studio :https://visualstudio.microsoft.com/fr/vs/community/
- Adobe reader:https://download.com.vn/download/adobe-reader-4829
- MS SQL Local db :https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16
- .NET Frame Wowrk 6.0 :https://dotnet.microsoft.com/en-us/download/dotnet/6.0

After install all development tools : you need to  set up development enviroment

# Set up development enviroment:
Prepare :install visual ,install .net 6.0,install adobe reader
1. Git clone :https://github.com/thanhnb1988/faxscan.git
2. Open project by using visual studio :
![open visual studio](images/b1_openvisual.png)
3. Restore nuget package in project :
![open visual studio](images/b2_restore.png)
3. Copy 2 file database FaxConfigDB.mdf and FaxConfigDB.ldf from Database folder  to other place then change connection string in AppConfig :
![open visual studio](images/b31_changeAppConfig.png)
4. Run project :
![open visual studio](images/b4_runproject.png)


# Deploy  enviroment:
Prepare :MS SQL Local db,install .net 6.0,install adobe reader
1. Install .net 6.0, install adobe reader
2. Install MS SQL Local
- Downloal sqldb local 2019 and install :https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16
![open visual studio](images/b5_sqllocaldownload.png)

- Create sql local db instance by comand :
```bash
SqlLocalDB delete  MSSQLLocalDB
SqlLocalDB create  MSSQLLocalDB
SqlLocalDB start  MSSQLLocalDB
```
3 .Instal Adobe Reader and make in default open PDF file
![open visual studio](images/b6_changeAdobeReader.png)
3 .Copy 2 file database FaxConfigDB.mdf and FaxConfigDB.ldf from Database folder  to other place then change connection string in SendFaxApp.dll.config
![open visual studio](images/b6_changeAdobeReader.png)
4 .Change connection string 
![open visual studio](images/b31_changeAppConfig.png)
5. Run project 



