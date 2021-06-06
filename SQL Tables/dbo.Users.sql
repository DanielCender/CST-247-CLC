USE [CST-247-Minesweeper]
GO

/****** Object: Table [dbo].[Users] Script Date: 5/13/2021 9:46:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
    [FirstName] NCHAR (20)    NOT NULL,
    [LastName]  NCHAR (20)    NOT NULL,
    [Gender]    TINYINT       NOT NULL,
    [Age]       INT           NOT NULL,
    [State]     NVARCHAR (20) NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [Username]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

