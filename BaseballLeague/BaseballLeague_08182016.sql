USE [master]
GO
/****** Object:  Database [BaseballLeague]    Script Date: 8/18/2016 2:33:57 PM ******/
CREATE DATABASE [BaseballLeague]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseballLeague', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BaseballLeague.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BaseballLeague_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BaseballLeague_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BaseballLeague] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseballLeague].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseballLeague] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseballLeague] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseballLeague] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseballLeague] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseballLeague] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseballLeague] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseballLeague] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseballLeague] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseballLeague] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseballLeague] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseballLeague] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseballLeague] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseballLeague] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseballLeague] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseballLeague] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseballLeague] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BaseballLeague] SET  MULTI_USER 
GO
ALTER DATABASE [BaseballLeague] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseballLeague] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseballLeague] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseballLeague] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BaseballLeague] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BaseballLeague]
GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Leagues](
	[LeagueId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED 
(
	[LeagueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Players]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[JerseyNumber] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[PreviousYearsBattingAverage] [decimal](18, 3) NULL,
	[YearsPlayed] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[LeagueId] [int] NOT NULL,
	[ManagerFirstName] [varchar](50) NOT NULL,
	[ManagerLastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Leagues] ON 

INSERT [dbo].[Leagues] ([LeagueId], [Name]) VALUES (1, N'RedLeage')
INSERT [dbo].[Leagues] ([LeagueId], [Name]) VALUES (2, N'BlueLeague')
SET IDENTITY_INSERT [dbo].[Leagues] OFF
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (8, N'Jim', N'CarryingThisTeam', 20, 7, CAST(9000.000 AS Decimal(18, 3)), 1, 1)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (10, N'Eric', N'VonSlugger', 65, 9, CAST(10000.000 AS Decimal(18, 3)), 2, 1)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (11, N'Katmolim ', N'Oakbelly', 80, 1, CAST(0.100 AS Decimal(18, 3)), 1, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (12, N'Kizmeal ', N'Largeborn', 79, 2, NULL, 3, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (13, N'Khurunri ', N'Boneblade', 65, 3, CAST(0.500 AS Decimal(18, 3)), 6, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (14, N'Brotmout  ', N'Oakenview', 52, 4, CAST(0.800 AS Decimal(18, 3)), 9, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (15, N'Bhamdirlum   ', N'Merrymantle', 32, 5, CAST(0.233 AS Decimal(18, 3)), 6, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (16, N'Glorizmorli   ', N'Platebrow', 21, 6, CAST(0.133 AS Decimal(18, 3)), 2, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (17, N'Mundeag    ', N'Gravelarm', 13, 7, CAST(0.888 AS Decimal(18, 3)), 7, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (18, N'Grogran    ', N'Bricksunder', 6, 8, NULL, 1, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (19, N'Thomas', N'Train', 42, 9, NULL, 20, 2)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (22, N'TestyMcTester', N'Tommy ', 0, 5, CAST(5.000 AS Decimal(18, 3)), 0, 4)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (23, N'Taco', N'Nacho', 123, 1, CAST(1.000 AS Decimal(18, 3)), 0, 4)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (24, N'Tester', N'testtttt', 124124, 9, CAST(9.000 AS Decimal(18, 3)), 0, 3)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (27, N'fasfusahf', N'kjsf99u', 2412, 9, NULL, 0, 3)
INSERT [dbo].[Players] ([PlayerId], [FirstName], [LastName], [JerseyNumber], [PositionId], [PreviousYearsBattingAverage], [YearsPlayed], [TeamId]) VALUES (28, N'JaMES', N'WARE', 232, 7, NULL, 0, 3)
SET IDENTITY_INSERT [dbo].[Players] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (1, N'Pitcher')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (2, N'Catcher')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (3, N'FirstBaseman')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (4, N'SecondBaseman')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (5, N'ThirdBaseman')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (6, N'ShortStop')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (7, N'LeftFielder')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (8, N'CenterFielder')
INSERT [dbo].[Positions] ([PositionId], [PositionName]) VALUES (9, N'RightFielder')
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([TeamId], [Name], [LeagueId], [ManagerFirstName], [ManagerLastName]) VALUES (1, N'SaltySailors', 1, N'Caleb', N'Byrd')
INSERT [dbo].[Teams] ([TeamId], [Name], [LeagueId], [ManagerFirstName], [ManagerLastName]) VALUES (2, N'ValentineBullets', 1, N'Unique', N'Emo')
INSERT [dbo].[Teams] ([TeamId], [Name], [LeagueId], [ManagerFirstName], [ManagerLastName]) VALUES (3, N'Sadness and Despair', 2, N'Agony', N'Pain')
INSERT [dbo].[Teams] ([TeamId], [Name], [LeagueId], [ManagerFirstName], [ManagerLastName]) VALUES (4, N'The Aces', 2, N'Ace', N'Ventura')
SET IDENTITY_INSERT [dbo].[Teams] OFF
ALTER TABLE [dbo].[Leagues]  WITH CHECK ADD  CONSTRAINT [FK_Leagues_Leagues] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[Leagues] ([LeagueId])
GO
ALTER TABLE [dbo].[Leagues] CHECK CONSTRAINT [FK_Leagues_Leagues]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Positions] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Positions]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Leagues] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[Leagues] ([LeagueId])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Leagues]
GO
/****** Object:  StoredProcedure [dbo].[CreatePlayer]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreatePlayer]
	@FirstName varchar(50),
	@LastName varchar(50),
	@JerseyNumber int,
	@PositionId int,
	@PreviousYearsBattingAverage decimal(18,5),
	@YearsPlayed int,
	@TeamId int
	
AS

INSERT INTO [dbo].[Players]
           ([FirstName]
           ,[LastName]
           ,[JerseyNumber]
           ,[PositionId]
           ,[PreviousYearsBattingAverage]
           ,[YearsPlayed]
		   ,[TeamId])

     VALUES
           (@FirstName,
		   @LastName,
		   @JerseyNumber,
		   @PositionId,
		   @PreviousYearsBattingAverage,
		   @YearsPlayed,
		   @TeamId)

		   select convert(int, scope_identity())
GO
/****** Object:  StoredProcedure [dbo].[CreateTeam]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateTeam]
	@Name varchar(max),
	@LeagueId int,
	@ManagerFirstName varchar(50),
	@ManagerLastName varchar(50)
AS

INSERT INTO [dbo].[Teams]
           ([Name],
		   [LeagueId],
		   [ManagerFirstName],
		   [ManagerLastName])
			 

     VALUES
           (@Name,
		   @LeagueId,
		   @ManagerFirstName,
		   @ManagerLastName)

	select convert(int, scope_identity())


GO
/****** Object:  StoredProcedure [dbo].[DeletePlayer]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePlayer]
	@PlayerId int

AS

Delete 
from Players
where PlayerId = @PlayerId
GO
/****** Object:  StoredProcedure [dbo].[GetAllLeagues]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllLeagues]

AS

select *
from Leagues

GO
/****** Object:  StoredProcedure [dbo].[GetAllPlayers]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPlayers]

AS

Select *
From Players
left join Teams on Players.TeamId = Teams.TeamId
left join Positions on Players.PositionId = Positions.PositionId


GO
/****** Object:  StoredProcedure [dbo].[GetAllPositions]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPositions]
	
AS

Select * 
From Positions

GO
/****** Object:  StoredProcedure [dbo].[GetAllTeams]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTeams]

AS

select TeamId, Teams.Name as TeamName, Teams.LeagueId as TeamLeagueId, ManagerFirstName, ManagerLastName, Leagues.LeagueId, Leagues.Name as LeagueName
from Teams
left join Leagues on Leagues.LeagueId = Teams.LeagueId



GO
/****** Object:  StoredProcedure [dbo].[GetIndividualTeam]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetIndividualTeam]
	@TeamId int,
	@Name varchar(max)
AS

select *
from Teams
where Teams.TeamId = @TeamId
	 
	 
GO
/****** Object:  StoredProcedure [dbo].[GetPlayer]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPlayer]
	@PlayerId int
AS

select *
from players
left join Teams on Players.TeamId = Teams.TeamId
left join Positions on Players.PositionId = Positions.PositionId
where Players.PlayerId = @PlayerId
	 

GO
/****** Object:  StoredProcedure [dbo].[GetPositionName]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPositionName]
	@PositionId int
AS

select *
from Positions
where Positions.PositionId = @PositionId
	 
	 
GO
/****** Object:  StoredProcedure [dbo].[TradePlayer]    Script Date: 8/18/2016 2:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TradePlayer]
	@PlayerId int,
	@TeamId int
AS

UPDATE [dbo].[Players]
   SET [TeamId] = @TeamId
 WHERE PlayerId = @PlayerId


GO
USE [master]
GO
ALTER DATABASE [BaseballLeague] SET  READ_WRITE 
GO
