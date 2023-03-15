using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    public partial class YonlendirmeForm : Form
    {
        public YonlendirmeForm()
        {
            InitializeComponent();
        }



        private void panel4_Click(object sender, EventArgs e)
        {
            UrunForm urunForm = new UrunForm();
            urunForm.Show();
        }

        private void pnlKategori_Click(object sender, EventArgs e)
        {
           Form1 form1 = new Form1();
            form1.Show();
        }

        private void pnlIstatistik_Click(object sender, EventArgs e)
        {
            IstatistikForm istatistikForm = new IstatistikForm();
            istatistikForm.Show();
        }

        private void pnlGrafik_Click(object sender, EventArgs e)
        {
            GrafiklerForm grafiklerForm = new GrafiklerForm();
            grafiklerForm.Show();
        }

        private void pnlLogin_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
        }
    }
}
