﻿/*
Deployment script for ContentDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ContentDB"
:setvar DefaultFilePrefix "ContentDB"
:setvar DefaultDataPath "C:\Users\James pc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\James pc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Starting rebuilding table [dbo].[SectionOne]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_SectionOne] (
    [Id]          INT            NOT NULL,
    [cardNumber]  INT            NOT NULL,
    [cardHeading] NVARCHAR (50)  NULL,
    [cardBody]    NVARCHAR (200) NULL,
    [cardButton]  NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[SectionOne])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_SectionOne] ([Id], [cardNumber], [cardBody], [cardButton])
        SELECT   [Id],
                 [cardNumber],
                 [cardBody],
                 [cardButton]
        FROM     [dbo].[SectionOne]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[SectionOne];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_SectionOne]', N'SectionOne';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO
