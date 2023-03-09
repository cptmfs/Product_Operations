using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urun_Takip_Kayit
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D3HGLAO\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tblKategori", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgw.DataSource = table;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd2 = new SqlCommand("insert into tblKategori (Ad) values (@prm1)", connection);
            cmd2.Parameters.AddWithValue("@prm1", tbxKategori.Text);
            cmd2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde eklendi..");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd3 = new SqlCommand("delete from tblKategori where Id=@prm2", connection);
            cmd3.Parameters.AddWithValue("@prm2", tbxID.Text);
            cmd3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori silme işleminiz başarılı bir şekilde gerçekleştirildi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd4 = new SqlCommand("update tblKategori set Ad=@prm1 where Id=@prm2", connection);
            cmd4.Parameters.AddWithValue("@prm1", tbxKategori.Text);
            cmd4.Parameters.AddWithValue("@prm2", tbxID.Text);
            cmd4.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori güncelleme işleminiz başarılı bir şekilde gerçekleştirildi.");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select  * from tblKategori where Ad=@prm1", connection);
            cmd5.Parameters.AddWithValue("@prm1", tbxKategori.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd5);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgw.DataSource = table;
        }
    }
}
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDb;Integrated Security=True