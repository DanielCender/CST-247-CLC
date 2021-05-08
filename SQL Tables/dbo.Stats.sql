USE [CST-247-Minesweeper]
GO

/****** Object:  Table [dbo].[Stats]    Script Date: 5/8/2021 3:50:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Wins] [int] NULL,
	[Losses] [int] NULL,
	[Total] [int] NULL,
	[AverageTime] [time](7) NULL,
	[BestTime] [time](7) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Stats]  WITH CHECK ADD  CONSTRAINT [FK__Stats__UserId__36B12243] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Stats] CHECK CONSTRAINT [FK__Stats__UserId__36B12243]
GO

