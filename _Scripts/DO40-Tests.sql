SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='DO40-Tests')
  drop database [DO40-Tests]
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE [DO40-Tests]
  ON PRIMARY (NAME = N''DO40-Tests'', FILENAME = N''' + @device_directory + N'DO40-Tests.mdf'')
  LOG ON (NAME = N''DO40-Tests_log'',  FILENAME = N''' + @device_directory + N'DO40-Tests.ldf'')')
go
