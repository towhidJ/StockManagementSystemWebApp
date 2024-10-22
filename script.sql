USE [master]
GO
/****** Object:  Database [StockManagementSystem]    Script Date: 3/25/2019 12:29:27 AM ******/
CREATE DATABASE [StockManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagementSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagementSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockManagementSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockManagementSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StockManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockManagementSystem]
GO
/****** Object:  Table [dbo].[CatagoryTB]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatagoryTB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatagoryName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_CatagoryTB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyTB]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyTB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Company_TB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemsTB]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemsTB](
	[CatagoryId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ItemName] [varchar](150) NOT NULL,
	[Reorder] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ItemsTB_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Username] [varchar](150) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockInTB]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockInTB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_StockInTB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockOutTB]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOutTB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Type] [varchar](150) NOT NULL,
	[Date] [date] NOT NULL,
	[Reorder] [int] NOT NULL,
 CONSTRAINT [PK_StockOutTB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[GetItemView]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetItemView]
AS
SELECT        dbo.ItemsTB.CompanyId, dbo.ItemsTB.ItemName, dbo.ItemsTB.Reorder, dbo.StockInTB.ItemId, dbo.StockInTB.Quantity, dbo.StockInTB.Id
FROM            dbo.ItemsTB INNER JOIN
                         dbo.StockInTB ON dbo.ItemsTB.Id = dbo.StockInTB.ItemId

GO
/****** Object:  View [dbo].[ItemView]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemView]
AS
SELECT        dbo.CompanyTB.CompanyName, dbo.ItemsTB.CompanyId, dbo.ItemsTB.ItemName, dbo.ItemsTB.Reorder, dbo.StockInTB.Quantity, dbo.ItemsTB.CatagoryId, dbo.ItemsTB.Id
FROM            dbo.CompanyTB INNER JOIN
                         dbo.ItemsTB ON dbo.CompanyTB.Id = dbo.ItemsTB.CompanyId INNER JOIN
                         dbo.StockInTB ON dbo.ItemsTB.Id = dbo.StockInTB.ItemId

GO
/****** Object:  View [dbo].[SearchView]    Script Date: 3/25/2019 12:29:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SearchView]
AS
SELECT        TOP (100) PERCENT dbo.CompanyTB.CompanyName, dbo.ItemsTB.CompanyId, dbo.ItemsTB.ItemName, dbo.ItemsTB.Reorder, dbo.StockInTB.ItemId, dbo.StockInTB.Quantity AS AvailableQuantity, dbo.StockOutTB.Id, 
                         dbo.StockOutTB.Quantity, dbo.StockOutTB.Type, dbo.StockOutTB.Date, dbo.ItemsTB.CatagoryId, dbo.CatagoryTB.CatagoryName
FROM            dbo.CompanyTB INNER JOIN
                         dbo.ItemsTB ON dbo.CompanyTB.Id = dbo.ItemsTB.CompanyId INNER JOIN
                         dbo.StockInTB ON dbo.ItemsTB.Id = dbo.StockInTB.ItemId INNER JOIN
                         dbo.StockOutTB ON dbo.ItemsTB.Id = dbo.StockOutTB.ItemId INNER JOIN
                         dbo.CatagoryTB ON dbo.ItemsTB.CatagoryId = dbo.CatagoryTB.Id

GO
SET IDENTITY_INSERT [dbo].[CatagoryTB] ON 

INSERT [dbo].[CatagoryTB] ([Id], [CatagoryName]) VALUES (1003, N'Computer Accessories')
INSERT [dbo].[CatagoryTB] ([Id], [CatagoryName]) VALUES (1, N'Food')
INSERT [dbo].[CatagoryTB] ([Id], [CatagoryName]) VALUES (2, N'Mobile')
SET IDENTITY_INSERT [dbo].[CatagoryTB] OFF
SET IDENTITY_INSERT [dbo].[CompanyTB] ON 

INSERT [dbo].[CompanyTB] ([Id], [CompanyName]) VALUES (4008, N'JOYA GROUP')
INSERT [dbo].[CompanyTB] ([Id], [CompanyName]) VALUES (4007, N'PRAN')
INSERT [dbo].[CompanyTB] ([Id], [CompanyName]) VALUES (1, N'RFL')
INSERT [dbo].[CompanyTB] ([Id], [CompanyName]) VALUES (5, N'WALTON')
SET IDENTITY_INSERT [dbo].[CompanyTB] OFF
SET IDENTITY_INSERT [dbo].[ItemsTB] ON 

INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1003, 4008, N'DELL Monitor', 1, 1040)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1003, 4008, N'DELL Mouse', 1, 1041)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1003, 4008, N'hp Mouse', 2, 1042)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1003, 4008, N'hp Keyboard', 2, 1043)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1003, 4008, N'hp Monitor', 2, 1044)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1003, 4008, N'hp Desktop Pc', 2, 1045)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1, 4007, N'Chocklet Cake', 5, 1046)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1, 4007, N'Dry Cake', 4, 1047)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (1, 4007, N'Fruit Cake', 7, 1048)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (2, 5, N'Primo GF', 12, 1049)
INSERT [dbo].[ItemsTB] ([CatagoryId], [CompanyId], [ItemName], [Reorder], [Id]) VALUES (2, 5, N'Primo GH5', 13, 1050)
SET IDENTITY_INSERT [dbo].[ItemsTB] OFF
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'towhid', N'232389')
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'sumon', N'232316')
SET IDENTITY_INSERT [dbo].[StockInTB] ON 

INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1003, 1044, 30)
INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1004, 1045, 6)
INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1005, 1049, 95)
INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1006, 1050, 80)
INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1007, 1046, 250)
INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1008, 1047, 500)
INSERT [dbo].[StockInTB] ([Id], [ItemId], [Quantity]) VALUES (1009, 1048, 300)
SET IDENTITY_INSERT [dbo].[StockInTB] OFF
SET IDENTITY_INSERT [dbo].[StockOutTB] ON 

INSERT [dbo].[StockOutTB] ([Id], [ItemId], [Quantity], [Type], [Date], [Reorder]) VALUES (2002, 1049, 5, N'Sell', CAST(0x733F0B00 AS Date), 12)
SET IDENTITY_INSERT [dbo].[StockOutTB] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UniqueKey_CatagoryTB]    Script Date: 3/25/2019 12:29:27 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UniqueKey_CatagoryTB] ON [dbo].[CatagoryTB]
(
	[CatagoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UniquKey_CompanyTB]    Script Date: 3/25/2019 12:29:27 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UniquKey_CompanyTB] ON [dbo].[CompanyTB]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UniqueKey_ItemsTB]    Script Date: 3/25/2019 12:29:27 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UniqueKey_ItemsTB] ON [dbo].[ItemsTB]
(
	[ItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Unique_Login]    Script Date: 3/25/2019 12:29:27 AM ******/
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [Unique_Login] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemsTB] ADD  CONSTRAINT [DF_ItemsTB_Reorder]  DEFAULT ((0)) FOR [Reorder]
GO
ALTER TABLE [dbo].[StockOutTB] ADD  CONSTRAINT [DF_StockOutTB_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[ItemsTB]  WITH CHECK ADD  CONSTRAINT [FK_ItemsTB_CatagoryTB] FOREIGN KEY([CatagoryId])
REFERENCES [dbo].[CatagoryTB] ([Id])
GO
ALTER TABLE [dbo].[ItemsTB] CHECK CONSTRAINT [FK_ItemsTB_CatagoryTB]
GO
ALTER TABLE [dbo].[ItemsTB]  WITH CHECK ADD  CONSTRAINT [FK_ItemsTB_CompanyTB] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[CompanyTB] ([Id])
GO
ALTER TABLE [dbo].[ItemsTB] CHECK CONSTRAINT [FK_ItemsTB_CompanyTB]
GO
ALTER TABLE [dbo].[StockInTB]  WITH CHECK ADD  CONSTRAINT [FK_StockInTB_ItemsTB] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemsTB] ([Id])
GO
ALTER TABLE [dbo].[StockInTB] CHECK CONSTRAINT [FK_StockInTB_ItemsTB]
GO
ALTER TABLE [dbo].[StockOutTB]  WITH CHECK ADD  CONSTRAINT [FK_StockOutTB_ItemsTB] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemsTB] ([Id])
GO
ALTER TABLE [dbo].[StockOutTB] CHECK CONSTRAINT [FK_StockOutTB_ItemsTB]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ItemsTB"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "StockInTB"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 119
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetItemView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetItemView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CompanyTB"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemsTB"
            Begin Extent = 
               Top = 6
               Left = 457
               Bottom = 136
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "StockInTB"
            Begin Extent = 
               Top = 6
               Left = 665
               Bottom = 119
               Right = 835
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CompanyTB"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemsTB"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 136
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "StockInTB"
            Begin Extent = 
               Top = 6
               Left = 457
               Bottom = 119
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StockOutTB"
            Begin Extent = 
               Top = 6
               Left = 665
               Bottom = 136
               Right = 835
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "CatagoryTB"
            Begin Extent = 
               Top = 6
               Left = 873
               Bottom = 102
               Right = 1043
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SearchView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SearchView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SearchView'
GO
USE [master]
GO
ALTER DATABASE [StockManagementSystem] SET  READ_WRITE 
GO
