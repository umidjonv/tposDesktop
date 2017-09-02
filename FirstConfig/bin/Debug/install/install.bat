@echo off
echo Installing MySQL Server. Please wait...

msiexec /i "mysql-5.5.23-winx64.msi" /quiet

echo Configuring

"C:\Program Files\MySQL\MySQL Server 5.5\bin\MySQLInstanceConfig.exe" -i -q ServerType=DEVELOPMENT DatabaseType=MIXED ServiceName=MySql Charset=utf8 RootPassword=198923233170 RootCurrentPassword=198923233170


