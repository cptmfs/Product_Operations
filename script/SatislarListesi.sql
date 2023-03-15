USE [ProductDb]
GO
/****** Object:  StoredProcedure [dbo].[SatislarListesi]    Script Date: 10.03.2023 23:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[SatislarListesi]
as
Select ID,Urun,Musteri,Adet,Fiyat,Toplam,Tarih,UrunAd,Ad+' '+Soyad as 'Müsteri Ad Soyad' from tblSatislar
inner join tblUrunler on tblSatislar.Urun=tblUrunler.UrunID
inner join tblMusteri on tblSatislar.Musteri=tblMusteri.MusteriID


