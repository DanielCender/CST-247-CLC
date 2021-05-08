USE [CST-247-Minesweeper]
GO

/****** Object:  Table [dbo].[Game]    Script Date: 5/8/2021 3:49:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Date] [date] NULL,
	[Difficulty] [nvarchar](10) NULL,
	[Result] [bit] NULL,
	[Time] [time](7) NULL,
	[FlagsRemaining] [int] NULL,
	[Status] [bit] NULL,
	[State] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK__Game__UserId__398D8EEE] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK__Game__UserId__398D8EEE]
GO

