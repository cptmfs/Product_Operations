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
    public partial class UrunForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D3HGLAO\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True");
        public UrunForm()
        {
            InitializeComponent();
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select * from tblKategori",connection);
            SqlDataAdapter dataAdapter= new SqlDataAdapter(cmd);   
            DataTable dt2 = new DataTable();
            dataAdapter.Fill(dt2);
            cbxKategori.DisplayMember = "Ad";
            cbxKategori.ValueMember = "ID";
            cbxKategori.DataSource = dt2;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand command =new SqlCommand("Select UrunID,UrunAd,Stok,AlisFiyat,SatisFiyat,Kategori,tblKategori.Ad from tblUrunler inner join tblKategori on tblUrunler.Kategori=tblKategori.ID ", connection);
            SqlDataAdapter dat = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dat.Fill(dt);
            dataGridView1.DataSource=dt;
            dataGridView1.Columns["Kategori"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAdı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDownStok.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbxKategori.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into tblUrunler (Urunad,stok,alisfiyat,satisfiyat,kategori )values (@p1,@p2,@p3,@p4,@p5)", connection);
            command.Parameters.AddWithValue("@p1", txtUrunAdı.Text);
            command.Parameters.AddWithValue("@p2", numericUpDownStok.Value);
            command.Parameters.AddWithValue("@p3", txtAlisFiyat.Text);
            command.Parameters.AddWithValue("@p4", txtSatisFiyat.Text);
            command.Parameters.AddWithValue("@p5",cbxKategori.SelectedValue);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün Ekleme İşleminiz Başarılı Şekilde Gerçekleştirildi..");
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command2 = new SqlCommand("delete from tblUrunler where UrunId=@p1",connection);
            command2.Parameters.AddWithValue("@p1",txtUrunId.Text);
            command2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün silme işleminiz başarılı bir şekilde gerçekleşti..");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command3 = new SqlCommand("update tblUrunler set urunAd=@p1,stok=@p2,alisfiyat=@p3,satisfiyat=@p4,kategori=@p5 where urunId=@p6",connection);
            command3.Parameters.AddWithValue("@p1",txtUrunAdı.Text);
            command3.Parameters.AddWithValue("@p2",numericUpDownStok.Value);
            command3.Parameters.AddWithValue("@p3",decimal.Parse(txtAlisFiyat.Text));
            command3.Parameters.AddWithValue("@p4", decimal.Parse(txtSatisFiyat.Text));
            command3.Parameters.AddWithValue("@p5",cbxKategori.SelectedValue);
            command3.Parameters.AddWithValue("@p6",txtUrunId.Text);
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün Güncelleme İşleminiz Başarıyla Gerçekleştirildi.","Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
    }
}
