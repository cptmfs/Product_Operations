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
    public partial class SatislarForm : Form
    {
        public SatislarForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductDb;Integrated Security=True");
        DataSet1TableAdapters.tblSatislarTableAdapter ds = new DataSet1TableAdapters.tblSatislarTableAdapter();

        private void SatislarForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Select * from tblUrunler", connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            cbxUrun.DisplayMember = "UrunAd";
            cbxUrun.ValueMember = "UrunID";
            cbxUrun.DataSource = dt2;
            dgwSatisListe.DataSource = ds.SatisListesi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Execute SatislarListesi", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgwSatisListe.DataSource = dt;
            dgwSatisListe.Columns["Musteri"].Visible = false;
            dgwSatisListe.Columns["Urun"].Visible = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ds.SatisEkle(int.Parse(cbxUrun.SelectedValue.ToString()), int.Parse(txtMusteri.Text), int.Parse(txtAdet.Text), decimal.Parse(txtFiyat.Text), decimal.Parse(txtToplam.Text), DateTime.Parse(mskTarih.Text));

            MessageBox.Show("Satış işlemi başarıyla gerçekleştirildi");
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double adet, fiyat, toplam;
            adet = Convert.ToDouble(txtAdet.Text);
            fiyat = Convert.ToDouble(txtFiyat.Text);
            toplam = adet * fiyat;
            txtToplam.Text = toplam.ToString();
        }

        private void dgwSatisListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSatisID.Text = dgwSatisListe.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbxUrun.SelectedValue = dgwSatisListe.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMusteri.Text = dgwSatisListe.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAdet.Text = dgwSatisListe.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtFiyat.Text = dgwSatisListe.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtToplam.Text = dgwSatisListe.Rows[e.RowIndex].Cells[5].Value.ToString();
            mskTarih.Text= dgwSatisListe.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.SatisGuncelle(int.Parse(cbxUrun.SelectedValue.ToString()),int.Parse(txtMusteri.Text),int.Parse(txtAdet.Text),decimal.Parse(txtFiyat.Text),decimal.Parse(txtToplam.Text),DateTime.Parse(mskTarih.Text),int.Parse(txtSatisID.Text));
            MessageBox.Show("Satış Güncelleme İşleminiz Başarıyla Gerçekleştirildi");
        }
    }
}
