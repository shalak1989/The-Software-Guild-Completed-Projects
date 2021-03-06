USE [master]
GO
/****** Object:  Database [Blog]    Script Date: 8/18/2016 1:23:25 PM ******/
CREATE DATABASE [Blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Blog.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Blog_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Blog] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blog] SET  MULTI_USER 
GO
ALTER DATABASE [Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Blog] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Blog]
GO
/****** Object:  Table [dbo].[BlogPost]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BlogPost](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[BlogContent] [varchar](max) NOT NULL,
	[PostDate] [date] NOT NULL,
	[Author] [varchar](max) NOT NULL,
	[IsApproved] [bit] NOT NULL CONSTRAINT [DF_BlogPost_IsApproved]  DEFAULT ((0)),
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BlogTags]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTags](
	[TagId] [int] NOT NULL,
	[BlogId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HashTags]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HashTags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaticPages]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaticPages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[PageTitle] [varchar](max) NOT NULL,
	[PageContent] [varchar](max) NOT NULL,
	[IsEnabled] [bit] NOT NULL CONSTRAINT [DF_StaticPages_IsEnabled]  DEFAULT ((1)),
 CONSTRAINT [PK_StaticPages] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BlogPost] ON 

INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (4, N'Cat is life, cat is purpose', N'<p>Cat is life</p>
<p><strong>CAT IS DEATH</strong></p>
<p><em>My soul will&nbsp;<span style="text-decoration: underline;">FUEL THE HELLFORGE</span></em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul>
<li>I miss nothing</li>
<li>I am nothing</li>
<li>darkness</li>
<li>IMMORTALITY!!!</li>
</ul>', CAST(N'2016-08-08' AS Date), N'2', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (5, N'Another test', N'<p>I want the dragons fire to wash over me and consume my immortal soul</p>', CAST(N'2016-08-08' AS Date), N'2', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (14, N'eadsfvb asderfvb', N'<p>sdeftv sedtfbsedartfb</p>', CAST(N'2016-08-15' AS Date), N'James', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (15, N'dtgfhnu', N'<p>dxfrhyn drtfhyn</p>', CAST(N'2016-08-15' AS Date), N'James', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1010, N'sdzfg', N'<p>fddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd</p>
<p>fddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd</p>
<p>fddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd</p>', CAST(N'2016-08-16' AS Date), N'Caleb', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1011, N'rdftgyrfth', N'<p>sredthbgrr<span style="color: #ff0000;">rrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span>tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>
<p>sred<span style="color: #ffff00;">thbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<span style="font-size: large;">tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span></span><br /><span style="font-size: large;"><span style="color: #ffff00;">sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span>tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<span style="background-color: #339966;">tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span>tttttttt</span><br /><span style="font-size: large;">sredthbgrrrrrrrrrttttttttrtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span><span style="color: #0000ff;"><span style="font-size: large;">ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span>tttttttttttttttttttttttttttttttttttttttttttt</span><br /><span style="color: #0000ff;">sredthbgrrrrrrrrrttttttttrtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</span>ttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>
<p>sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>
<p>sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>
<p>sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>
<p>sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt<br />sredthbgrrrrrrrrrttttttttrtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>
<p>tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</p>', CAST(N'2016-08-16' AS Date), N'Caleb', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1012, N'esrtzdg', N'<p>srtgdfhbrtghbsrtsrthsr</p>', CAST(N'2016-08-17' AS Date), N'tes', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1013, N'edftrsrbsrtb', N'<p>srdgbsrgbsrtbstbs</p>', CAST(N'2016-08-17' AS Date), N'tes', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1014, N'srgtbsrfgb', N'<p>rsgbsrgtybsrthbsr</p>', CAST(N'2016-08-17' AS Date), N'tes', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1016, N'sg sfvg sfg', N'<p>v setwetrvwer</p>', CAST(N'2016-08-17' AS Date), N'Caleb', 1)
INSERT [dbo].[BlogPost] ([BlogId], [Title], [BlogContent], [PostDate], [Author], [IsApproved]) VALUES (1017, N'fffffffffffffffffffffffffffffffffffffffffdddddddddddddddddddddddddddddddddddddddddddddd', N'<p>sdfsdfvbsd</p>', CAST(N'2016-08-18' AS Date), N'Caleb', 1)
SET IDENTITY_INSERT [dbo].[BlogPost] OFF
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (50, 1010)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (50, 1011)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1045, 1012)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1046, 1012)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1047, 1014)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1048, 1014)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1048, 1014)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1050, 1015)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1051, 1015)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1050, 1016)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1051, 1016)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1052, 1017)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (1047, 1012)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (45, 14)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (48, 14)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (49, 14)
INSERT [dbo].[BlogTags] ([TagId], [BlogId]) VALUES (50, 15)
SET IDENTITY_INSERT [dbo].[HashTags] ON 

INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (45, N'#Anytag')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (48, N'#sometag')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (49, N'#Jamestag')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (1045, N'tag1')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (1046, N'tag2')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (1047, N'tag3')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (1048, N'tag4')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (1049, N'tag5')
INSERT [dbo].[HashTags] ([TagId], [TagName]) VALUES (1052, N'')
SET IDENTITY_INSERT [dbo].[HashTags] OFF
SET IDENTITY_INSERT [dbo].[StaticPages] ON 

INSERT [dbo].[StaticPages] ([PageId], [PageTitle], [PageContent], [IsEnabled]) VALUES (1, N'dtfryng', N'<p>dtfrynh&nbsp;<strong>dtyfhn</strong><span style="text-decoration: underline;">dytrfhngb&nbsp;<em>drtyfnhdty</em></span> dtyf<span style="color: #ff0000;">nhdt<span style="color: #3366ff;">yh</span></span><span style="color: #3366ff;">jnd&nbsp;<span style="font-size: xx-large;">srdtg<span style="color: #000000;">hbrfy</span></span></span></p>', 1)
INSERT [dbo].[StaticPages] ([PageId], [PageTitle], [PageContent], [IsEnabled]) VALUES (2, N'tgfdhunjtghyn', N'<p>dtghn dftghyundftguhyn</p>', 1)
INSERT [dbo].[StaticPages] ([PageId], [PageTitle], [PageContent], [IsEnabled]) VALUES (1003, N'tghyfmjhuyrfduhjmnrdtyhundrythnujdmrdytuhj', N'<p>rdttdrfhynmdtrfhumrtdumdrthn</p>', 1)
SET IDENTITY_INSERT [dbo].[StaticPages] OFF
/****** Object:  StoredProcedure [dbo].[AddNewHashtag]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AddNewHashtag]
	@TagName varchar(max)

AS

INSERT INTO [dbo].HashTags
           (TagName)
     VALUES
           (@TagName)

select convert(int, SCOPE_IDENTITY()) as TagId
GO
/****** Object:  StoredProcedure [dbo].[AddNewPost]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AddNewPost]
	@Title varchar(max),
	@BlogContent varchar(max),
	@PostDate date,
	@Author varchar (max)

AS

INSERT INTO [dbo].[BlogPost]
           (Title
           ,BlogContent
           ,[PostDate]
           ,Author)
     VALUES
           (@Title,
           @BlogContent,
		   @PostDate,
		   @Author)

		   select convert(int, SCOPE_IDENTITY()) as BlogId
GO
/****** Object:  StoredProcedure [dbo].[AddNewStaticPage]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AddNewStaticPage]
	@PageTitle varchar(max),
	@PageContent varchar(max)


AS

INSERT INTO [dbo].StaticPages
           (PageTitle, 
		   PageContent)
     VALUES
           (@PageTitle,
		   @PageContent)


GO
/****** Object:  StoredProcedure [dbo].[ApproveBlogPost]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[ApproveBlogPost]
	@BlogId int

AS

update BlogPost
set IsApproved= 1
WHERE BlogId = @BlogId

GO
/****** Object:  StoredProcedure [dbo].[DisableStaticPage]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[DisableStaticPage]
	@PageId int

AS

update StaticPages
set IsEnabled= 0
WHERE PageId = @PageId

GO
/****** Object:  StoredProcedure [dbo].[EnableStaticPage]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[EnableStaticPage]
	@PageId int

AS

update StaticPages
set IsEnabled= 1
WHERE PageId = @PageId

GO
/****** Object:  StoredProcedure [dbo].[GetAllApprovedBlogPosts]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetAllApprovedBlogPosts]

AS

select *
from BlogPost
where IsApproved = 1


GO
/****** Object:  StoredProcedure [dbo].[GetAllBlogPosts]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllBlogPosts]

AS

select *
from BlogPost


GO
/****** Object:  StoredProcedure [dbo].[GetAllHashtags]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllHashtags]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * 
	from HashTags
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllStaticPages]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllStaticPages]

AS

select *
from StaticPages


GO
/****** Object:  StoredProcedure [dbo].[GetBlogsByHashtag]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetBlogsByHashtag]
@TagId int
AS

select *
from BlogPost B
join BlogTags bt on b.BlogId = bt.BlogId
where bt.TagId = @TagId


GO
/****** Object:  StoredProcedure [dbo].[GetCommonTags]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCommonTags]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select top (5) h.TagId, h.TagName
from HashTags h
join BlogTags bt on h.TagId = bt.TagId
group by h.TagId, h.TagName
order by count(TagName) desc

END

GO
/****** Object:  StoredProcedure [dbo].[GetSingleBlogPosts]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSingleBlogPosts]
	-- Add the parameters for the stored procedure here
	@blogId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select * 
from BlogPost
where BlogId = @blogId
END

GO
/****** Object:  StoredProcedure [dbo].[GetTagsPerPost]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetTagsPerPost]
	-- Add the parameters for the stored procedure here
	@BlogId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select H.TagId, h.TagName
	from HashTags H
	join BlogTags BT on H.TagId = BT.TagId
	where BT.BlogId = @BlogId
END

GO
/****** Object:  StoredProcedure [dbo].[GetUnapprovedBlogPosts]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUnapprovedBlogPosts]

AS

select *
from BlogPost
where IsApproved = 0


GO
/****** Object:  StoredProcedure [dbo].[UpdateBlogHashtagCrossTable]    Script Date: 8/18/2016 1:23:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[UpdateBlogHashtagCrossTable]
	-- Add the parameters for the stored procedure here
	@BlogId int
	,@TagId int
		   
AS
BEGIN
insert into BlogTags 
   (BlogId,TagId)
values
   (@BlogId,
   @TagId)
 
END
GO
USE [master]
GO
ALTER DATABASE [Blog] SET  READ_WRITE 
GO
