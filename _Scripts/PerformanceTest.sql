SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='PerformanceTest')
  drop database [PerformanceTest]
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE [PerformanceTest]
  ON PRIMARY (NAME = N''PerformanceTest'', FILENAME = N''' + @device_directory + N'PerformanceTest.mdf'')
  LOG ON (NAME = N''PerformanceTest_log'',  FILENAME = N''' + @device_directory + N'PerformanceTest.ldf'')')
GO

USE [PerformanceTest]
GO

CREATE TABLE [dbo].[Simplests]
(
[Id] [bigint] NOT NULL,
[Value] [bigint] NOT NULL CONSTRAINT [DF__Simplest__Value__7D78A4E7] DEFAULT ((0))
)
GO

ALTER TABLE [dbo].[Simplests] ADD CONSTRAINT [PK_Simplest] PRIMARY KEY CLUSTERED ([Id])
GO

CREATE TABLE [dbo].[KeyTable]
(
[NextId] [int] NOT NULL
)
GO
INSERT INTO [dbo].[KeyTable] ([NextId]) VALUES (1)
GO