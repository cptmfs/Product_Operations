USE [master]
GO
/****** Object:  Database [ProductDb]    Script Date: 8.03.2023 23:11:05 ******/
CREATE DATABASE [ProductDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductDb', FILENAME = N'C:\Users\Kaptan\ProductDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductDb_log', FILENAME = N'C:\Users\Kaptan\ProductDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductDb] SET  MULTI_USER 
GO
ALTER DATABASE [ProductDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProductDb] SET QUERY_STORE = OFF
GO
USE [ProductDb]
GO
/****** Object:  Table [dbo].[tblKategori]    Script Date: 8.03.2023 23:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKategori](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
 CONSTRAINT [PK_tblKategori] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUrunler]    Script Date: 8.03.2023 23:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUrunler](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAd] [varchar](30) NULL,
	[Stok] [smallint] NULL,
	[AlisFiyat] [decimal](18, 2) NULL,
	[SatisFiyat] [decimal](18, 2) NULL,
	[Kategori] [int] NULL,
 CONSTRAINT [PK_tblUrunler] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblKategori] ON 

INSERT [dbo].[tblKategori] ([ID], [Ad]) VALUES (1, N'Beyaz Esya')
INSERT [dbo].[tblKategori] ([ID], [Ad]) VALUES (2, N'Bilgisayar')
INSERT [dbo].[tblKategori] ([ID], [Ad]) VALUES (3, N'Küçük Ev Aletleri')
INSERT [dbo].[tblKategori] ([ID], [Ad]) VALUES (5, N'Telefon ve Tablet')
SET IDENTITY_INSERT [dbo].[tblKategori] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUrunler] ON 

INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (1, N'Çamasir Makinesi', 50, CAST(11000.00 AS Decimal(18, 2)), CAST(14000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (2, N'Bulasik Makinesi', 30, CAST(9000.00 AS Decimal(18, 2)), CAST(12500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (3, N'Thinkpad T470', 20, CAST(17500.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (4, N'Latitude E5830', 15, CAST(14500.00 AS Decimal(18, 2)), CAST(17500.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (5, N'Ütü', 50, CAST(1900.00 AS Decimal(18, 2)), CAST(2200.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (6, N'Su isitici', 100, CAST(550.00 AS Decimal(18, 2)), CAST(750.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (7, N'Buz Dolabi', 15, CAST(18000.00 AS Decimal(18, 2)), CAST(23000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tblUrunler] ([UrunID], [UrunAd], [Stok], [AlisFiyat], [SatisFiyat], [Kategori]) VALUES (8, N'Avize', 250, CAST(900.00 AS Decimal(18, 2)), CAST(1300.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[tblUrunler] OFF
GO
ALTER TABLE [dbo].[tblUrunler]  WITH CHECK ADD  CONSTRAINT [FK_tblUrunler_tblKategori] FOREIGN KEY([Kategori])
REFERENCES [dbo].[tblKategori] ([ID])
GO
ALTER TABLE [dbo].[tblUrunler] CHECK CONSTRAINT [FK_tblUrunler_tblKategori]
GO
USE [master]
GO
ALTER DATABASE [ProductDb] SET  READ_WRITE 
GO
