USE [master]
GO
/****** Object:  Database [ROUTE_MANAGEMENT]    Script Date: 01/01/2023 18:20:45 ******/
CREATE DATABASE [ROUTE_MANAGEMENT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ROUTE_MANAGEMENT', FILENAME = N'D:\DBMS\Microsoft SQL Server\2019\Express\MSSQL15.SQLEXPRESS\MSSQL\DATA\ROUTE_MANAGEMENT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ROUTE_MANAGEMENT_log', FILENAME = N'D:\DBMS\Microsoft SQL Server\2019\Express\MSSQL15.SQLEXPRESS\MSSQL\DATA\ROUTE_MANAGEMENT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ROUTE_MANAGEMENT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ARITHABORT OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET  MULTI_USER 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET QUERY_STORE = OFF
GO
USE [ROUTE_MANAGEMENT]
GO
/****** Object:  Table [dbo].[Bus]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bus](
	[BusID] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlates] [nvarchar](200) NOT NULL,
	[BusNumber] [nvarchar](200) NOT NULL,
	[SumSeats] [int] NOT NULL,
	[Status] [nvarchar](200) NOT NULL,
	[BusTypeID] [int] NOT NULL,
	[RoutesID] [int] NOT NULL,
 CONSTRAINT [PK_Bus] PRIMARY KEY CLUSTERED 
(
	[BusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusRoutes]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusRoutes](
	[BusRouteID] [int] IDENTITY(1,1) NOT NULL,
	[RouteNumber] [nvarchar](200) NOT NULL,
	[RouteName] [nvarchar](200) NOT NULL,
	[ResponsibleUnitID] [int] NOT NULL,
	[OperationType] [nvarchar](200) NOT NULL,
	[OperationTime] [nvarchar](200) NOT NULL,
	[Fare] [int] NOT NULL,
	[BusesAmount] [nvarchar](550) NULL,
	[BusesTime] [nvarchar](550) NOT NULL,
	[BusesSpace] [nvarchar](550) NOT NULL,
 CONSTRAINT [PK_BusRoutes] PRIMARY KEY CLUSTERED 
(
	[BusRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusStop]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusStop](
	[BusStopID] [int] IDENTITY(1,1) NOT NULL,
	[BusStopName] [nvarchar](200) NOT NULL,
	[BusStopDescription] [nvarchar](200) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Street] [nvarchar](200) NOT NULL,
	[Wards] [nvarchar](200) NULL,
	[District] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_BusStop] PRIMARY KEY CLUSTERED 
(
	[BusStopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusType]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusType](
	[BusTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CarMaker] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_BusType] PRIMARY KEY CLUSTERED 
(
	[BusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Path] [nvarchar](1000) NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[DocumentTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[DocumentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[DriverID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[IDCard] [nvarchar](200) NOT NULL,
	[Sex] [bit] NOT NULL,
	[DayOfBirth] [datetime] NOT NULL,
	[HomeTown] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver_Bus]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver_Bus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DriverID] [int] NOT NULL,
	[BusID] [int] NOT NULL,
	[DepartureDay] [datetime] NULL,
 CONSTRAINT [PK_Driver_Bus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HandlingViolations]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HandlingViolations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ResponsibleUnitID] [int] NOT NULL,
	[ProcessingTime] [datetime] NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_HandlingViolations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Information]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Information](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[DateSubmitted] [datetime] NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Information] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MENU]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MENU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Link] [nvarchar](1000) NOT NULL,
	[Icon] [nvarchar](200) NOT NULL,
	[Mota] [nvarchar](100) NOT NULL,
	[TypeMenuID] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POSTS]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[NgayDang] [datetime] NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[Rank] [int] NULL,
	[Comments] [nvarchar](1000) NULL,
	[NumberOfReviews] [int] NOT NULL,
	[NumberOfResponse] [int] NOT NULL,
	[CoverImage] [nvarchar](1000) NULL,
	[Link] [nvarchar](200) NULL,
	[TypePostsID] [int] NOT NULL,
 CONSTRAINT [PK_POSTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reflect]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reflect](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReflectTypeID] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[VideoOrPicture] [nvarchar](1000) NOT NULL,
	[Status] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Reflect] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReflectType]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReflectType](
	[ReflectTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ReflectType] PRIMARY KEY CLUSTERED 
(
	[ReflectTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResponsibleUnit]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResponsibleUnit](
	[ResponsibleUnitID] [int] IDENTITY(1,1) NOT NULL,
	[ReponsibleUnitName] [nvarchar](200) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
 CONSTRAINT [PK_ReponsibleUnit] PRIMARY KEY CLUSTERED 
(
	[ResponsibleUnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[RouteID] [int] IDENTITY(1,1) NOT NULL,
	[BusRoutesID] [int] NOT NULL,
	[StartPositionID] [int] NOT NULL,
	[EndPositionID] [int] NOT NULL,
	[RouteName] [nvarchar](200) NOT NULL,
	[RouteAmount] [int] NOT NULL,
	[RouteTime] [time](7) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[ApplicableDate] [date] NOT NULL,
	[OperationDate] [date] NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[RouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RouteID] [int] NOT NULL,
	[NumberRoutes] [nvarchar](200) NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
 CONSTRAINT [PK_Routes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stop_Route]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stop_Route](
	[StopRouteID] [int] IDENTITY(1,1) NOT NULL,
	[RouteID] [int] NOT NULL,
	[EndPositionID] [int] NOT NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_Stop_Route] PRIMARY KEY CLUSTERED 
(
	[StopRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePosts]    Script Date: 01/01/2023 18:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePosts](
	[TypePostsID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_TypePosts] PRIMARY KEY CLUSTERED 
(
	[TypePostsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusRoutes] ON 

INSERT [dbo].[BusRoutes] ([BusRouteID], [RouteNumber], [RouteName], [ResponsibleUnitID], [OperationType], [OperationTime], [Fare], [BusesAmount], [BusesTime], [BusesSpace]) VALUES (1, N'04', N'Đà Lạt - Bảo Lộc', 111111111, N'Phổ thông - Có trợ giá', N'Oct 27 2022 11:24PM', 111111, N'13', N'Oct 27 2022 11:24PM', N'Oct 27 2022 11:24PM')
SET IDENTITY_INSERT [dbo].[BusRoutes] OFF
GO
SET IDENTITY_INSERT [dbo].[BusStop] ON 

INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (1, N'Bến xe Mai Anh Đào', N'207', 11.975417137145996, 108.44132232666016, N'Mai Anh Đào', N'Phường 8', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (2, N'Đường Phù Đổng Thiên Vương', N'207', 11.964024543762207, 108.44316864013672, N'Phù Đổng Thiên Vương', N'Phường 8', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (3, N'Đường Đinh Tiên Hoàng', N'2-4', 11.950879096984863, 108.44252777099609, N'Đinh Tiên Hoàng', N'Phường 2', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (4, N'Đường Nguyễn Thái Học', N'2-4', 11.954458236694336, 108.42924499511719, N'Nguyễn Thái Học ', N'Phường 2', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (5, N'Khu Hoà Bình', N'04', 11.943378448486328, 108.43611145019531, N'Khu Hoà Bình', N'Phường 1', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (6, N'Đường Lê Đại Hành ', N'04', 11.938432693481445, 108.43773651123047, N'Lê Đại Hành ', N'Phường 4', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (7, N'Đường Trần Phú', N'8', 11.936535835266113, 108.43519592285156, N'Trần Phú', N'Phường 4', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (8, N'Đường 3/4', N'10', 11.932949066162109, 108.44582366943359, N'3/4', N'Phường 3', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (9, N'Bến xe Đức Trọng', N'735', 11.726317405700684, 108.36949157714844, N'Quốc lộ 20', N'Liên Nghĩa', N'Đức Trọng')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (10, N'Ngã 3 Thác Pongour', N'10', 11.66586971282959, 108.31431579589844, N'3/4', N'Phường 3', N'Đà Lạt')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (11, N'Ngã 3 Tà Hine - Ninh Gia', N'735', 11.632132530212402, 108.3046875, N'Quốc lộ 20', N'Ninh Gia', N'Đức Trọng')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (12, N'Chợ Tam Bố', N'735', 11.620465278625488, 108.21987152099609, N'Quốc lộ 20', N'Tam Bố', N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (13, N'Nhà Thờ Giáo Xứ Phú Hiệp', N'735', 11.631122589111328, 108.18253326416016, N'Quốc lộ 20', N'Gia Hiệp', N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (14, N'UBND Xã Đinh Lạc', N'735', 11.611682891845703, 108.11559295654297, N'Quốc lộ 20', N'Đinh lạc', N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (15, N'Nhà Thờ Giáo Xứ Di Linh', N'735', 11.577342987060547, 108.07547760009766, N'Quốc lộ 20', NULL, N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (16, N'Ubnd Xã Liên Đầm', N'735', 11.574456214904785, 108.02285766601563, N'Quốc lộ 20', N'Liên Đầm', N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (17, N'BẾN XE ĐINH TRANG HÒA', N'735', 11.547731399536133, 107.96451568603516, N'Quốc lộ 20', N'ĐINH TRANG HÒA', N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (18, N'BẾN XE ĐINH TRANG HÒA', N'735', 11.538104057312012, 107.94732666015625, N'Quốc lộ 20', N'ĐINH TRANG HÒA', N'Di Linh')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (19, N'Cơ Sở Massage Long Hải', N'735', 11.52996826171875, 107.83915710449219, N'Quốc lộ 20', N'Lộc Nga', N'Bảo Lộc')
INSERT [dbo].[BusStop] ([BusStopID], [BusStopName], [BusStopDescription], [Latitude], [Longitude], [Street], [Wards], [District]) VALUES (20, N'Bến xe Bảo lộc', N'58', 11.543214797973633, 107.80159759521484, N'Quốc lộ 20', N'Loc Son', N'Bảo Lộc')
SET IDENTITY_INSERT [dbo].[BusStop] OFF
GO
SET IDENTITY_INSERT [dbo].[Route] ON 

INSERT [dbo].[Route] ([RouteID], [BusRoutesID], [StartPositionID], [EndPositionID], [RouteName], [RouteAmount], [RouteTime], [StartTime], [EndTime], [ApplicableDate], [OperationDate]) VALUES (1, 1, 1, 20, N'Đà Lạt - Bảo Lộc:Bến xe Mai Anh Đào-Bến xe Bảo lộc', 0, CAST(N'00:45:00' AS Time), CAST(N'2022-10-24T00:00:00.000' AS DateTime), CAST(N'2022-10-31T00:00:00.000' AS DateTime), CAST(N'2022-07-19' AS Date), CAST(N'2022-10-27' AS Date))
INSERT [dbo].[Route] ([RouteID], [BusRoutesID], [StartPositionID], [EndPositionID], [RouteName], [RouteAmount], [RouteTime], [StartTime], [EndTime], [ApplicableDate], [OperationDate]) VALUES (2, 1, 20, 1, N'Đà Lạt - Bảo Lộc:Bến xe Bảo lộc-Bến xe Mai Anh Đào', 0, CAST(N'00:42:00' AS Time), CAST(N'2022-10-24T00:00:00.000' AS DateTime), CAST(N'2022-10-31T00:00:00.000' AS DateTime), CAST(N'2022-07-19' AS Date), CAST(N'2022-10-27' AS Date))
SET IDENTITY_INSERT [dbo].[Route] OFF
GO
SET IDENTITY_INSERT [dbo].[Stop_Route] ON 

INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (2, 2, 20, 1)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (3, 1, 2, 2)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (4, 2, 19, 2)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (5, 1, 3, 3)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (6, 2, 18, 3)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (7, 1, 4, 4)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (8, 2, 17, 4)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (9, 1, 5, 5)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (10, 2, 16, 5)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (11, 1, 6, 6)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (12, 2, 15, 6)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (13, 1, 7, 7)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (14, 2, 14, 7)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (15, 1, 8, 8)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (16, 2, 13, 8)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (17, 1, 9, 9)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (18, 2, 12, 9)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (19, 1, 10, 10)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (20, 2, 11, 10)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (21, 1, 11, 11)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (22, 2, 10, 11)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (23, 1, 12, 12)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (24, 2, 9, 12)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (25, 1, 13, 13)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (26, 2, 8, 13)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (27, 1, 14, 14)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (28, 2, 7, 14)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (29, 1, 15, 15)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (30, 2, 6, 15)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (31, 1, 16, 16)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (32, 2, 5, 16)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (33, 1, 17, 17)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (34, 2, 4, 17)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (35, 1, 18, 18)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (36, 2, 3, 18)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (37, 1, 19, 19)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (38, 2, 2, 19)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (39, 1, 20, 20)
INSERT [dbo].[Stop_Route] ([StopRouteID], [RouteID], [EndPositionID], [Order]) VALUES (40, 2, 1, 20)
SET IDENTITY_INSERT [dbo].[Stop_Route] OFF
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_BusRoutes] FOREIGN KEY([BusRoutesID])
REFERENCES [dbo].[BusRoutes] ([BusRouteID])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_BusRoutes]
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_BusStop] FOREIGN KEY([StartPositionID])
REFERENCES [dbo].[BusStop] ([BusStopID])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_BusStop]
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_BusStop1] FOREIGN KEY([EndPositionID])
REFERENCES [dbo].[BusStop] ([BusStopID])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_BusStop1]
GO
ALTER TABLE [dbo].[Stop_Route]  WITH CHECK ADD  CONSTRAINT [FK_Stop_Route_BusStop] FOREIGN KEY([EndPositionID])
REFERENCES [dbo].[BusStop] ([BusStopID])
GO
ALTER TABLE [dbo].[Stop_Route] CHECK CONSTRAINT [FK_Stop_Route_BusStop]
GO
ALTER TABLE [dbo].[Stop_Route]  WITH CHECK ADD  CONSTRAINT [FK_Stop_Route_Route] FOREIGN KEY([RouteID])
REFERENCES [dbo].[Route] ([RouteID])
GO
ALTER TABLE [dbo].[Stop_Route] CHECK CONSTRAINT [FK_Stop_Route_Route]
GO
USE [master]
GO
ALTER DATABASE [ROUTE_MANAGEMENT] SET  READ_WRITE 
GO


SET IDENTITY_INSERT [dbo].[DocumentType] ON
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (1, N'Tờ Trình')
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (2, N'Triển Khai')
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (3, N'Hợp đồng')
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (4, N'Kế hoạch')
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (5, N'Quy chế')
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (6, N'Nghị quyết')
INSERT [dbo].[DocumentType] ([DocumentTypeID],[Name]) VALUES (7, N'Thông báo')
SET IDENTITY_INSERT [dbo].[DocumentType] OFF

SET IDENTITY_INSERT [dbo].[Document] ON
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (1, N'PLM/3',N'thunha.pdf',N'Triển khai toà lâu đài tình ái',2)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (2, N'115 - TB/9o',N'113 TB TRUNG TÂM (TRIỂN KHAI THÍ ĐIỂM KẾT QUẢ THỦ TỤC HÀNH CHÍNH TRONG NGÀY).pdf',N'Thông báo về việc công ty đã sang trang mới',7)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (3, N'OLK/8',N'Thong_bao_so_20_TB_TW_ngay_08_9_2022.pdf',N'Kế hoạch ngàn năm văn vở',4)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (4, N'PL/89',N'Thong_bao_so_20_TB_TW_ngay_08_9_2022.pdf',N'Hợp đồng 10 năm đi làm',3)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (5, N'Pok/983',N'thunha.pdf',N'Triển khai toà lâu đài tình ái',2)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (6, N'NQ/920',N'quyet-dinh-1855-qd-ubnd-uy-ban-nhan-dan-tinh-binh-thuan.pdf',N'Chuyên đề nhà nước',5)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (7, N'855-QD',N'CS_TLBD_Chuyende9.pdf',N'Quyết định uỷ ban nhân dân tỉnh',6)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (8, N'789/TT_QLĐH',N'113 TB TRUNG TÂM (TRIỂN KHAI THÍ ĐIỂM KẾT QUẢ THỦ TỤC HÀNH CHÍNH TRONG NGÀY).pdf',N'Cập nhật lại thủ tục hành chính theo Nghị định 10/2020/NĐ-CP',7)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (9, N'113 TB-TT',N'590-TB-UBND.pdf',N'Quy chế trong công ty',5)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (10, N'PLO 116',N'Thong_bao_so_20_TB_TW_ngay_08_9_2022.pdf',N'Kế hoạch xây dựng cung thiếu nhi',4)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (11, N'PLO 117',N'113 TB TRUNG TÂM (TRIỂN KHAI THÍ ĐIỂM KẾT QUẢ THỦ TỤC HÀNH CHÍNH TRONG NGÀY).pdf',N'Quy chế trong công ty',5)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (12, N'NQ-3/3',N'Thong_bao_so_20_TB_TW_ngay_08_9_2022.pdf',N'Thong_bao_so_20_TB_TW_ngay_08_9_2022.pdf',7)
INSERT [dbo].[Document] ([ID],[Title],[Path],[Content],[DocumentTypeID]) VALUES (13, N'P0/LL',N'Thong_bao_so_20_TB_TW_ngay_08_9_2022.pdf',N'Nghị quyết từ nay tôi sống độc lập',6)

SET IDENTITY_INSERT [dbo].[Document] OFF
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Type] FOREIGN KEY([DocumentTypeID])
REFERENCES [dbo].[DocumentType] ([DocumentTypeID])
GO


SELECT * FROM Document

insert into dbo.ResponsibleUnit values (N'Xe khách Sài Gòn',0885656268)
insert into dbo.ResponsibleUnit values (N'Xe khách Phương Trang',0885656141)
insert into dbo.ResponsibleUnit values (N'Xe khách Thành Bưởi',0885655612)
insert into dbo.ResponsibleUnit values (N'Xe khách Anh Tuyên',0885655178)
select *
from dbo.ResponsibleUnit

insert into dbo.HandlingViolations values (N'Hành vi vượt ẩu',1,'11/13/2021',N'http://buyttphcm.com.vn/Portals/0/X%E1%')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 8/2019',2,'11/19/2019',N'http://buyttphcm.com.vn/Portals/0/X%E1%BB%AD%20ph%1')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 9/2019 ',3,'12/13/2019',N'http://buyttphcm.com.vn/Po')
insert into dbo.HandlingViolations values (N'Hành vi vượt ẩu',1,'11/13/2021',N'http://buyttphcm.com.vn/Portals/0/X%E1%')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 8/2019',2,'11/19/2019',N'http://buyttphcm.com.vn/Portals/0/X%E1%BB%AD%20ph%1')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 9/2019 ',3,'12/13/2019',N'http://buyttphcm.com.vn/Po')
insert into dbo.HandlingViolations values (N'Hành vi vượt ẩu',1,'11/13/2021',N'http://buyttphcm.com.vn/Portals/0/X%E1%')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 8/2019',2,'11/19/2019',N'http://buyttphcm.com.vn/Portals/0/X%E1%BB%AD%20ph%1')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 9/2019 ',3,'12/13/2019',N'http://buyttphcm.com.vn/Po')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 9/2019 ',3,'12/13/2019',N'http://buyttphcm.com.vn/Po')
insert into dbo.HandlingViolations values (N'Hành vi vượt ẩu',1,'11/13/2021',N'http://buyttphcm.com.vn/Portals/0/X%E1%')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 8/2019',2,'11/19/2019',N'http://buyttphcm.com.vn/Portals/0/X%E1%BB%AD%20ph%1')
insert into dbo.HandlingViolations values (N'Xử lý vi phạm tháng 9/2019 ',3,'12/13/2019',N'http://buyttphcm.com.vn/Po')


insert into dbo.ReflectType values (N'Chất lượng vi phạm xe buýt')
insert into dbo.ReflectType values (N'Hạ tầng bến bãi xe buýt')
insert into dbo.ReflectType values (N'Lộ trình thời gian hoạt động tuyến')
insert into dbo.ReflectType values (N'Gương người tốt việc tốt khen thưởng')
insert into dbo.ReflectType values (N'Chê Trách')
insert into dbo.ReflectType values (N'Khen Thưởng')
insert into dbo.ReflectType values (N'Vi phạm an toàn giao thông')
insert into dbo.ReflectType values (N'Vi phạm an toàn đường bộ')
insert into dbo.ReflectType values (N'Khen thưởng tuyên dương')
insert into dbo.ReflectType values (N'Vi phạm bến đậu')
insert into dbo.ReflectType values (N'khen thưởng 11')

insert into dbo.Reflect values (1,'chất lượng vi phạm xe buýt đang có chuyeefu hướng đi lên','emxinbotay0711@gmail.com','Phan Quốc Huy','0904941277','Tôi rất mong các cơ quan đơn nghành vào cuộc khắc phục ngay ','../images/08854f5c83695a370378.jpg','Đã Xử Lý')
insert into dbo.Reflect values(2,N'Hạ tầng xuống cấp nghiêm trọng',N'phanquochuy2001na@gmail.com',N'Phan Quốc Huy',N'0904941277',N'rất mong các cơ quan đoàn thể vào cuộc giải quyết',N'../images/image_67517953.JPG',N'Đã Xử Lý')
insert into dbo.Reflect values (1,'chất lượng vi phạm xe buýt đang có hướng đi lên','emxinbotay0711@gmail.com',N'Phan Quốc Huy','0904941277',N'Tôi rất mong các cơ quan đơn nghành vào cuộc khắc phục ngay ','../images/08854f5c83695a370378.jpg',N'Đã Xử Lý')
insert into dbo.Reflect values(2,N'Hạ tầng xuống cấp nghiêm trọng hơn',N'phanquochuy2001na@gmail.com',N'Phan Quốc Huy',N'0904941277',N'rất mong các cơ quan đoàn thể vào cuộc giải quyết',N'../images/image_67517953.JPG',N'Đã Xử Lý')
insert into dbo.Reflect values (1,N'chất lượng vi phạm xe buýt đang rất phức tạp','emxinbotay0711@gmail.com',N'Phan Quốc Huy','0904941277',N'Tôi rất mong các cơ quan đơn nghành vào cuộc khắc phục ngay ','../images/08854f5c83695a370378.jpg',N'Đã Xử Lý')
insert into dbo.Reflect values(2,N'Hạ tầng xuống cấp trầm trọng',N'phanquochuy2001na@gmail.com',N'Phan Quốc Huy',N'0904941277',N'rất mong các cơ quan đoàn thể vào cuộc giải quyết',N'../images/image_67517953.JPG',N'Đã Xử Lý')
insert into dbo.Reflect values (1,N'chất lượng vi phạm xe buýt nhiều hơn tháng trước','emxinbotay0711@gmail.com',N'Phan Quốc Huy','0904941277',N'Tôi rất mong các cơ quan đơn nghành vào cuộc khắc phục ngay ','../images/08854f5c83695a370378.jpg','Đã Xử Lý')
insert into dbo.Reflect values(2,N'Hạ tầng xuống cấp trong năm nay',N'phanquochuy2001na@gmail.com',N'Phan Quốc Huy',N'0904941277',N'rất mong các cơ quan đoàn thể vào cuộc giải quyết',N'../images/image_67517953.JPG',N'Đã Xử Lý')