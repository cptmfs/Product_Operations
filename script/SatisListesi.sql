USE [ProductDb]
GO
/****** Object:  StoredProcedure [dbo].[SatisListesi]    Script Date: 10.03.2023 20:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[SatisListesi]
as
Select ID,UrunAd,Adet,Ad+' '+Soyad as 'Ad Soyad',Fiyat,Toplam,Tarih from tblSatislar
inner join tblUrunler on tblSatislar.Urun=tblUrunler.UrunID
inner join tblMusteri on tblSatislar.Musteri=tblMusteri.MusteriID