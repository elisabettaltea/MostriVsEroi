USE [master]
GO
/****** Object:  Database [MostriVsEroi]    Script Date: 03/09/2021 14:56:30 ******/
CREATE DATABASE [MostriVsEroi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MostriVsEroi', FILENAME = N'C:\Users\Betta\MostriVsEroi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MostriVsEroi_log', FILENAME = N'C:\Users\Betta\MostriVsEroi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MostriVsEroi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MostriVsEroi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ARITHABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MostriVsEroi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MostriVsEroi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MostriVsEroi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET  MULTI_USER 
GO
ALTER DATABASE [MostriVsEroi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MostriVsEroi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MostriVsEroi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MostriVsEroi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MostriVsEroi] SET QUERY_STORE = OFF
GO
USE [MostriVsEroi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MostriVsEroi]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Tipo] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Armi]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armi](
	[IdArma] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Armi] PRIMARY KEY CLUSTERED 
(
	[IdArma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ArmiConCategorieEroiEMostri]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArmiConCategorieEroiEMostri]
AS
SELECT        dbo.Categorie.Nome AS Categoria, dbo.Armi.Nome AS NomeArma, dbo.Armi.PuntiDanno
FROM            dbo.Armi INNER JOIN
                         dbo.Categorie ON dbo.Armi.IdCategoria = dbo.Categorie.IdCategoria
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroi]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroi](
	[IdEroe] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdLivelloVita] [int] NOT NULL,
	[IdUtente] [int] NOT NULL,
	[PunteggioAccumulato] [int] NOT NULL,
 CONSTRAINT [PK_Eroi] PRIMARY KEY CLUSTERED 
(
	[IdEroe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LivelliVita]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LivelliVita](
	[IdLivelloVita] [int] IDENTITY(1,1) NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_LivelliVita] PRIMARY KEY CLUSTERED 
(
	[IdLivelloVita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UtenteConEroi]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UtenteConEroi]
AS
SELECT        dbo.Utenti.IdUtente, dbo.Utenti.Username, dbo.Eroi.Nome AS NomeEroe, dbo.Categorie.Nome AS Categoria, dbo.Armi.Nome AS NomeArma, dbo.Armi.PuntiDanno, dbo.LivelliVita.Livello, dbo.LivelliVita.PuntiVita, 
                         dbo.Eroi.PunteggioAccumulato
FROM            dbo.Armi INNER JOIN
                         dbo.Categorie ON dbo.Armi.IdCategoria = dbo.Categorie.IdCategoria INNER JOIN
                         dbo.Eroi ON dbo.Armi.IdArma = dbo.Eroi.IdArma AND dbo.Categorie.IdCategoria = dbo.Eroi.IdCategoria INNER JOIN
                         dbo.LivelliVita ON dbo.Eroi.IdLivelloVita = dbo.LivelliVita.IdLivelloVita INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtente = dbo.Utenti.IdUtente
GO
/****** Object:  Table [dbo].[Mostri]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostri](
	[IdMostro] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdLivelloVita] [int] NOT NULL,
 CONSTRAINT [PK_Mostri] PRIMARY KEY CLUSTERED 
(
	[IdMostro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MostriConCaratteristiche]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MostriConCaratteristiche]
AS
SELECT        dbo.Mostri.Nome, dbo.Categorie.Nome AS Categoria, dbo.Armi.Nome AS NomeArma, dbo.Armi.PuntiDanno, dbo.LivelliVita.Livello, dbo.LivelliVita.PuntiVita
FROM            dbo.Armi INNER JOIN
                         dbo.Categorie ON dbo.Armi.IdCategoria = dbo.Categorie.IdCategoria INNER JOIN
                         dbo.Mostri ON dbo.Armi.IdArma = dbo.Mostri.IdArma AND dbo.Categorie.IdCategoria = dbo.Mostri.IdCategoria INNER JOIN
                         dbo.LivelliVita ON dbo.Mostri.IdLivelloVita = dbo.LivelliVita.IdLivelloVita
GO
/****** Object:  View [dbo].[UtenteConEroiClassifica]    Script Date: 03/09/2021 14:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UtenteConEroiClassifica]
AS
SELECT        TOP(10) dbo.Utenti.IdUtente, dbo.Utenti.Username, dbo.Eroi.Nome AS NomeEroe, dbo.Categorie.Nome AS Categoria, dbo.Armi.Nome AS NomeArma, dbo.Armi.PuntiDanno, dbo.LivelliVita.Livello, dbo.LivelliVita.PuntiVita, 
                         dbo.Eroi.PunteggioAccumulato
FROM            dbo.Armi INNER JOIN
                         dbo.Categorie ON dbo.Armi.IdCategoria = dbo.Categorie.IdCategoria INNER JOIN
                         dbo.Eroi ON dbo.Armi.IdArma = dbo.Eroi.IdArma AND dbo.Categorie.IdCategoria = dbo.Eroi.IdCategoria INNER JOIN
                         dbo.LivelliVita ON dbo.Eroi.IdLivelloVita = dbo.LivelliVita.IdLivelloVita INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtente = dbo.Utenti.IdUtente
ORDER BY dbo.LivelliVita.Livello DESC, dbo.LivelliVita.PuntiVita DESC
GO
SET IDENTITY_INSERT [dbo].[Armi] ON 

INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (2, N'Ascia', 8, 1)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (3, N'Mazza', 5, 1)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (4, N'Spada', 10, 1)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (5, N'Spadone', 15, 1)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (6, N'Arco e Frecce', 8, 2)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (7, N'Bacchetta', 5, 2)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (8, N'Bastone Magico', 10, 2)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (9, N'Onda d''urto', 15, 2)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (10, N'Pugnale', 5, 2)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (11, N'Discorso Noioso', 4, 3)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (12, N'Farneticazione', 7, 3)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (13, N'Imprecazione', 5, 3)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (14, N'Magia Nera', 3, 3)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (15, N'Arco', 7, 4)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (16, N'Clava', 5, 4)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (17, N'Spada Rotta', 3, 4)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (18, N'Mazza Chiodata', 10, 4)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (19, N'Alabarda del drago', 30, 5)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (20, N'Divinazione', 15, 5)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (21, N'Fulmine', 10, 5)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (22, N'Fulmine Celeste', 15, 5)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (23, N'Tempesta', 8, 5)
INSERT [dbo].[Armi] ([IdArma], [Nome], [PuntiDanno], [IdCategoria]) VALUES (24, N'Tempesta Oscura', 15, 5)
SET IDENTITY_INSERT [dbo].[Armi] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorie] ON 

INSERT [dbo].[Categorie] ([IdCategoria], [Nome], [Tipo]) VALUES (1, N'Guerriero', N'Eroe')
INSERT [dbo].[Categorie] ([IdCategoria], [Nome], [Tipo]) VALUES (2, N'Mago', N'Eroe')
INSERT [dbo].[Categorie] ([IdCategoria], [Nome], [Tipo]) VALUES (3, N'Cultista', N'Mostro')
INSERT [dbo].[Categorie] ([IdCategoria], [Nome], [Tipo]) VALUES (4, N'Orco', N'Mostro')
INSERT [dbo].[Categorie] ([IdCategoria], [Nome], [Tipo]) VALUES (5, N'Signore del Male', N'Mostro')
SET IDENTITY_INSERT [dbo].[Categorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroi] ON 

INSERT [dbo].[Eroi] ([IdEroe], [Nome], [IdArma], [IdCategoria], [IdLivelloVita], [IdUtente], [PunteggioAccumulato]) VALUES (5006, N'Eroe1', 1, 1, 3, 4004, 40)
INSERT [dbo].[Eroi] ([IdEroe], [Nome], [IdArma], [IdCategoria], [IdLivelloVita], [IdUtente], [PunteggioAccumulato]) VALUES (5008, N'Eroe2', 9, 2, 2, 4004, 10)
INSERT [dbo].[Eroi] ([IdEroe], [Nome], [IdArma], [IdCategoria], [IdLivelloVita], [IdUtente], [PunteggioAccumulato]) VALUES (5009, N'Eroe3', 4, 1, 1, 4005, 10)
INSERT [dbo].[Eroi] ([IdEroe], [Nome], [IdArma], [IdCategoria], [IdLivelloVita], [IdUtente], [PunteggioAccumulato]) VALUES (5010, N'Eroe4', 8, 2, 2, 4005, 20)
SET IDENTITY_INSERT [dbo].[Eroi] OFF
GO
SET IDENTITY_INSERT [dbo].[LivelliVita] ON 

INSERT [dbo].[LivelliVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (1, 1, 20)
INSERT [dbo].[LivelliVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (2, 2, 40)
INSERT [dbo].[LivelliVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (3, 3, 60)
INSERT [dbo].[LivelliVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (4, 4, 80)
INSERT [dbo].[LivelliVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (5, 5, 100)
SET IDENTITY_INSERT [dbo].[LivelliVita] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostri] ON 

INSERT [dbo].[Mostri] ([IdMostro], [Nome], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (5005, N'Mostro1', 21, 5, 1)
INSERT [dbo].[Mostri] ([IdMostro], [Nome], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (5006, N'Mostro2', 17, 4, 2)
INSERT [dbo].[Mostri] ([IdMostro], [Nome], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (5007, N'Mostro3', 12, 3, 1)
INSERT [dbo].[Mostri] ([IdMostro], [Nome], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (5008, N'Mostro4', 23, 5, 2)
SET IDENTITY_INSERT [dbo].[Mostri] OFF
GO
SET IDENTITY_INSERT [dbo].[Utenti] ON 

INSERT [dbo].[Utenti] ([IdUtente], [Username], [Password], [IsAdmin]) VALUES (4004, N'Giocatore1', N'111a', 1)
INSERT [dbo].[Utenti] ([IdUtente], [Username], [Password], [IsAdmin]) VALUES (4005, N'Giocatore2', N'123d', 0)
SET IDENTITY_INSERT [dbo].[Utenti] OFF
GO
ALTER TABLE [dbo].[Armi]  WITH CHECK ADD  CONSTRAINT [FK_Armi_Categorie] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorie] ([IdCategoria])
GO
ALTER TABLE [dbo].[Armi] CHECK CONSTRAINT [FK_Armi_Categorie]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Armi] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Armi] ([IdArma])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Armi]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Categorie] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorie] ([IdCategoria])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Categorie]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_LivelliVita] FOREIGN KEY([IdLivelloVita])
REFERENCES [dbo].[LivelliVita] ([IdLivelloVita])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_LivelliVita]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Utenti] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utenti] ([IdUtente])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Utenti]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_Armi] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Armi] ([IdArma])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_Armi]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_Categorie] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorie] ([IdCategoria])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_Categorie]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_LivelliVita] FOREIGN KEY([IdLivelloVita])
REFERENCES [dbo].[LivelliVita] ([IdLivelloVita])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_LivelliVita]
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
         Begin Table = "Armi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categorie"
            Begin Extent = 
               Top = 6
               Left = 266
               Bottom = 119
               Right = 456
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiConCategorieEroiEMostri'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiConCategorieEroiEMostri'
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
         Begin Table = "Armi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categorie"
            Begin Extent = 
               Top = 156
               Left = 277
               Bottom = 269
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LivelliVita"
            Begin Extent = 
               Top = 92
               Left = 972
               Bottom = 205
               Right = 1162
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Mostri"
            Begin Extent = 
               Top = 19
               Left = 626
               Bottom = 149
               Right = 816
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
      End' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MostriConCaratteristiche'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MostriConCaratteristiche'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MostriConCaratteristiche'
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
         Begin Table = "Eroi"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 136
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Utenti"
            Begin Extent = 
               Top = 146
               Left = 1035
               Bottom = 276
               Right = 1225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Armi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categorie"
            Begin Extent = 
               Top = 185
               Left = 290
               Bottom = 298
               Right = 480
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LivelliVita"
            Begin Extent = 
               Top = 18
               Left = 840
               Bottom = 131
               Right = 1030
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
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtenteConEroi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     Alias = 900
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtenteConEroi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtenteConEroi'
GO
USE [master]
GO
ALTER DATABASE [MostriVsEroi] SET  READ_WRITE 
GO
