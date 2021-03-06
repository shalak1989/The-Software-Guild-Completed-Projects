USE [master]
GO
/****** Object:  Database [DVDLibrary]    Script Date: 8/18/2016 2:33:10 PM ******/
CREATE DATABASE [DVDLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVDLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DVDLibrary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVDLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DVDLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DVDLibrary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DVDLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DVDLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DVDLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DVDLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DVDLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DVDLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DVDLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DVDLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DVDLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DVDLibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DVDLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DVDLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DVDLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DVDLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DVDLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DVDLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DVDLibrary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DVDLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [DVDLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DVDLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DVDLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DVDLibrary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DVDLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DVDLibrary]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Borrower](
	[BorrowerId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Borrower] PRIMARY KEY CLUSTERED 
(
	[BorrowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Director]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Director](
	[DirectorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Director] PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DVD]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DVD](
	[DVDId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[MPPARatingId] [nchar](10) NOT NULL,
	[Studio] [varchar](max) NOT NULL,
	[UserRating] [decimal](18, 0) NULL,
	[UserNotes] [varchar](max) NULL,
 CONSTRAINT [PK_DVD] PRIMARY KEY CLUSTERED 
(
	[DVDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DVDActors]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDActors](
	[ActorId] [int] NOT NULL,
	[DVDId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVDBorrowers]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDBorrowers](
	[BorrowerId] [int] NOT NULL,
	[DVDId] [int] NOT NULL,
	[DateCheckedOut] [date] NOT NULL,
	[DateReturned] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVDDirectors]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDDirectors](
	[DVDId] [int] NOT NULL,
	[DirectorId] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (1, N'Will', N'Smith')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (2, N'Bob', N'Saggot')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (3, N'Dwayne', N'Johnson')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (4, N'Liam', N'Neeson')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (5, N'Donald', N'Trump')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (6, N'John', N'Smith')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (7, N'Jason', N'Gerstorff')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (8, N'Eric', N'Wise')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (9, N'Caleb', N'Berry')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (10, N'Loud', N'Fart')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (11, N'Cheeky', N'Asshole')
SET IDENTITY_INSERT [dbo].[Actor] OFF
INSERT [dbo].[Borrower] ([BorrowerId], [FirstName], [LastName]) VALUES (1, N'Creepy', N'Bob')
INSERT [dbo].[Borrower] ([BorrowerId], [FirstName], [LastName]) VALUES (2, N'Crazy', N'Issac')
INSERT [dbo].[Borrower] ([BorrowerId], [FirstName], [LastName]) VALUES (3, N'Dale', N'Smith')
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([DirectorId], [FirstName], [LastName]) VALUES (1, N'Steven', N'Speilberg')
INSERT [dbo].[Director] ([DirectorId], [FirstName], [LastName]) VALUES (2, N'Cole', N'Train')
INSERT [dbo].[Director] ([DirectorId], [FirstName], [LastName]) VALUES (3, N'Danger', N'Taco')
INSERT [dbo].[Director] ([DirectorId], [FirstName], [LastName]) VALUES (4, N'Marshmellow', N'Ghost')
SET IDENTITY_INSERT [dbo].[Director] OFF
SET IDENTITY_INSERT [dbo].[DVD] ON 

INSERT [dbo].[DVD] ([DVDId], [Title], [ReleaseDate], [MPPARatingId], [Studio], [UserRating], [UserNotes]) VALUES (2, N'SQL eats babies', CAST(N'2016-07-12' AS Date), N'R         ', N'LionsGate Studios', CAST(2 AS Decimal(18, 0)), N'Move makes me hungry')
INSERT [dbo].[DVD] ([DVDId], [Title], [ReleaseDate], [MPPARatingId], [Studio], [UserRating], [UserNotes]) VALUES (3, N'Clowns are awesome', CAST(N'2016-07-26' AS Date), N'PG        ', N'It Studios', CAST(5 AS Decimal(18, 0)), N'Clowns have no soul and neither do I #emokid')
INSERT [dbo].[DVD] ([DVDId], [Title], [ReleaseDate], [MPPARatingId], [Studio], [UserRating], [UserNotes]) VALUES (6, N'fail', CAST(N'2016-07-12' AS Date), N'R         ', N'Tester Studio', CAST(5 AS Decimal(18, 0)), N'Movie makes me hangry')
INSERT [dbo].[DVD] ([DVDId], [Title], [ReleaseDate], [MPPARatingId], [Studio], [UserRating], [UserNotes]) VALUES (8, N'title', CAST(N'2016-07-13' AS Date), N'R         ', N'Gib', CAST(4 AS Decimal(18, 0)), N'3')
SET IDENTITY_INSERT [dbo].[DVD] OFF
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (1, 3)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (2, 3)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (3, 3)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (4, 3)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (5, 2)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (6, 2)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (7, 2)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (5, 3)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (8, 3)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (9, 2)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (10, 2)
INSERT [dbo].[DVDActors] ([ActorId], [DVDId]) VALUES (11, 2)
INSERT [dbo].[DVDBorrowers] ([BorrowerId], [DVDId], [DateCheckedOut], [DateReturned]) VALUES (1, 2, CAST(N'2001-08-01' AS Date), CAST(N'2001-09-04' AS Date))
INSERT [dbo].[DVDBorrowers] ([BorrowerId], [DVDId], [DateCheckedOut], [DateReturned]) VALUES (2, 2, CAST(N'2015-10-11' AS Date), CAST(N'2015-10-14' AS Date))
INSERT [dbo].[DVDBorrowers] ([BorrowerId], [DVDId], [DateCheckedOut], [DateReturned]) VALUES (3, 2, CAST(N'2015-12-12' AS Date), CAST(N'2015-12-18' AS Date))
INSERT [dbo].[DVDDirectors] ([DVDId], [DirectorId]) VALUES (2, 4)
INSERT [dbo].[DVDDirectors] ([DVDId], [DirectorId]) VALUES (3, 1)
INSERT [dbo].[DVDDirectors] ([DVDId], [DirectorId]) VALUES (6, 3)
ALTER TABLE [dbo].[DVDActors]  WITH CHECK ADD  CONSTRAINT [FK_DVDActors_Actor] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[DVDActors] CHECK CONSTRAINT [FK_DVDActors_Actor]
GO
ALTER TABLE [dbo].[DVDActors]  WITH CHECK ADD  CONSTRAINT [FK_DVDActors_DVD] FOREIGN KEY([DVDId])
REFERENCES [dbo].[DVD] ([DVDId])
GO
ALTER TABLE [dbo].[DVDActors] CHECK CONSTRAINT [FK_DVDActors_DVD]
GO
ALTER TABLE [dbo].[DVDBorrowers]  WITH CHECK ADD  CONSTRAINT [FK_DVDBorrowers_Borrower] FOREIGN KEY([BorrowerId])
REFERENCES [dbo].[Borrower] ([BorrowerId])
GO
ALTER TABLE [dbo].[DVDBorrowers] CHECK CONSTRAINT [FK_DVDBorrowers_Borrower]
GO
ALTER TABLE [dbo].[DVDBorrowers]  WITH CHECK ADD  CONSTRAINT [FK_DVDBorrowers_DVD] FOREIGN KEY([DVDId])
REFERENCES [dbo].[DVD] ([DVDId])
GO
ALTER TABLE [dbo].[DVDBorrowers] CHECK CONSTRAINT [FK_DVDBorrowers_DVD]
GO
ALTER TABLE [dbo].[DVDDirectors]  WITH CHECK ADD  CONSTRAINT [FK_DVDDirectors_Director] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Director] ([DirectorId])
GO
ALTER TABLE [dbo].[DVDDirectors] CHECK CONSTRAINT [FK_DVDDirectors_Director]
GO
ALTER TABLE [dbo].[DVDDirectors]  WITH CHECK ADD  CONSTRAINT [FK_DVDDirectors_DVD] FOREIGN KEY([DVDId])
REFERENCES [dbo].[DVD] ([DVDId])
GO
ALTER TABLE [dbo].[DVDDirectors] CHECK CONSTRAINT [FK_DVDDirectors_DVD]
GO
/****** Object:  StoredProcedure [dbo].[AddActor]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddActor]
	@FirstName varchar(50),
	@LastName varchar(50)
AS

INSERT INTO [dbo].[Actor]
           (
           [FirstName],
           [LastName])
     VALUES
           (@FirstName,
		   @LastName)

		   select convert(int, scope_identity())
GO
/****** Object:  StoredProcedure [dbo].[AddDirector]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddDirector]
	@FirstName varchar(50),
	@LastName varchar(50)

AS

INSERT INTO [dbo].[Director]
           ([FirstName],
           [LastName])
     VALUES
           (@FirstName,
           @LastName)





GO
/****** Object:  StoredProcedure [dbo].[AddDVD]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddDVD]
	@DVDTitle varchar(max),
	@DVDReleaseDate date,
	@DVDMPPARatingId nchar(10),
	@DVDStudio varchar(max),
	@DVDUserRating decimal,
	@DVDUserNotes varchar(max)

AS


INSERT INTO [dbo].[DVD]
           ([Title],
           [ReleaseDate],
           [MPPARatingId],
           [Studio],
           [UserRating],
           [UserNotes])
	
     VALUES
          (@DVDTitle,
           @DVDReleaseDate,
		   @DVDMPPARatingId,
		   @DVDStudio,
		   @DVDUserRating,
		   @DVDUserNotes)

		select convert(int, scope_identity())


GO
/****** Object:  StoredProcedure [dbo].[DeleteDVD]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteDVD]
	@DVDId int

AS

Delete 
from DVDActors
where DVDId = @DVDId

Delete 
from DVDBorrowers
where DVDId = @DVDId

Delete 
from DVDDirectors
where DVDId = @DVDId


Delete
from DVD
Where DVD.DVDId = @DVDId

GO
/****** Object:  StoredProcedure [dbo].[GetAllDVD]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllDVD]

AS

Select *
From DVD




GO
/****** Object:  StoredProcedure [dbo].[GetDVDActor]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL

CREATE PROCEDURE [dbo].[GetDVDActor]
	@DVDId Int

AS

select *
from DVDActors
join Actor on Actor.ActorId = DVDActors.ActorId
Where DVDActors.DVDId = @DVDId

GO
/****** Object:  StoredProcedure [dbo].[GetDVDBorrower]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDVDBorrower]
	@DvdID int
AS

select *
from DVDBorrowers
join Borrower on Borrower.BorrowerId = DVDBorrowers.BorrowerId
Where DVDBorrowers.DVDId = @DvdID



GO
/****** Object:  StoredProcedure [dbo].[GetDvdById]    Script Date: 8/18/2016 2:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDvdById] 
	@DVDId int

AS
BEGIN



	SELECT *
	from DVD
	Where DVDId = @DVDId
END

GO
USE [master]
GO
ALTER DATABASE [DVDLibrary] SET  READ_WRITE 
GO
