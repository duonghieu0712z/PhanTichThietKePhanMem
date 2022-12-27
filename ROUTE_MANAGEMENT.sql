USE [ROUTE_MANAGEMENT]
GO
/****** Object:  Table [dbo].[Bus]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[BusRoutes]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[BusStop]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[BusType]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Document]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[DocumentType]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Driver]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Driver_Bus]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[HandlingViolations]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Information]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[MENU]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[POSTS]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Reflect]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[ReflectType]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[ResponsibleUnit]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Route]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Routes]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[Stop_Route]    Script Date: 12/27/2022 4:27:02 PM ******/
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
/****** Object:  Table [dbo].[TypePosts]    Script Date: 12/27/2022 4:27:02 PM ******/
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
