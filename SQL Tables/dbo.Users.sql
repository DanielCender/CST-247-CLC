USE [CST-247-Minesweeper]
GO

/****** Object: Table [dbo].[Users] Script Date: 4/28/2021 3:46:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NCHAR (20)    NOT NULL,
    [LastName]  NCHAR (20)    NOT NULL,
    [Gender]    BIT           NOT NULL,
    [Age]       TINYINT       NOT NULL,
    [State]     NCHAR (20)    NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [Username]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL
);


