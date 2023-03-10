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
    public partial class GrafiklerForm : Form
    {
        public GrafiklerForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D3HGLAO\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True");

        private void GrafiklerForm_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select Ad,Count(*) from tblUrunler inner join tblKategori on tblUrunler.Kategori=tblKategori.ID group by Ad",connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(reader[0], reader[1]);
            }
            connection.Close();
            

        }
    }
}
