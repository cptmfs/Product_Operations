using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    public partial class IstatistikForm : Form
    {
        public IstatistikForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D3HGLAO\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True");
        private void IstatistikForm_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Count(*) From  tblKategori", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lblKategoriSayısı.Text = reader[0].ToString();
            }
            connection.Close();
            //Toplam Ürün Sayısı
            connection.Open();
            SqlCommand cmd2 = new SqlCommand("Select Count(*) From  tblUrunler", connection);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                lblUrunSayisi.Text = reader2[0].ToString();
            }
            connection.Close();

            //Toplam Beyaz Esya Sayısı
            
            connection.Open();
            SqlCommand cmd3 = new SqlCommand("select Count (*) from tblUrunler where Kategori=1", connection);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                lblBeyazEsya.Text = reader3[0].ToString();
            }
            connection.Close();

            //Toplam Küçük Ev Aletleri Sayısı

            connection.Open();
            SqlCommand cmd4 = new SqlCommand("select Count (*) from tblUrunler where Kategori=3", connection);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                lblKucukEv.Text = reader4[0].ToString();
            }
            connection.Close();


            // En Yüksek Stoklu Ürün..
            connection.Open();
            SqlCommand cmd5 = new SqlCommand("Select * From tblUrunler where Stok=(Select Max(Stok) From tblUrunler)", connection);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            while (reader5.Read())
            {
                lblEnYuksekStok.Text = reader5["UrunAd"].ToString();
            }
            connection.Close();

            // En Düşük Stoklu Ürün..
            connection.Open();
            SqlCommand cmd6 = new SqlCommand("Select * From tblUrunler where Stok=(Select Min(Stok) From tblUrunler)", connection);
            SqlDataReader reader6 = cmd6.ExecuteReader();
            while (reader6.Read())
            {
                lblEnDusukStok.Text = reader6["UrunAd"].ToString();
            }
            connection.Close();

            // Laptopların Satışından Kalan Toplam Kar 
            connection.Open();
            SqlCommand cmd7 = new SqlCommand("select Convert (int,Sum((SatisFiyat-AlisFiyat)*Stok)) from tblUrunler where Kategori = 2 ", connection);
            SqlDataReader reader7 = cmd7.ExecuteReader();
            while (reader7.Read())
            {
                lblLaptop.Text = reader7[0].ToString()+ " ₺";
            }
            connection.Close();

            //Beyaz Eşya Kategorisi Toplam Kar Oranı

            connection.Open();
            SqlCommand cmd8 = new SqlCommand("Select Convert (int,Sum(Stok*(SatisFiyat-AlisFiyat))) from tblUrunler where Kategori = (Select ID from tblKategori where ad = 'Beyaz Eşya')", connection);
            SqlDataReader reader8 = cmd8.ExecuteReader();
            while (reader8.Read())
            {
                lblBeyazEsyaKar.Text = reader8[0].ToString() + " ₺";
            }
            connection.Close();
            

        }
    }
}
