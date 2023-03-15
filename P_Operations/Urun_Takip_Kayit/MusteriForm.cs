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
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tblMusteriTableAdapter tb = new DataSet1TableAdapters.tblMusteriTableAdapter();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dgwMusteri.DataSource = tb.MusteriListesi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tb.MusteriEkle(txtAd.Text, txtSoyad.Text, txtSehir.Text, decimal.Parse(txtBakiye.Text));
            MessageBox.Show("Müşteri Ekleme İşlemi Başarılılı Bir Şekilde Gerçekleştirildi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            tb.MusteriSil(int.Parse(txtMusteriId.Text));
            MessageBox.Show("Müşteri Silme İşlemi Başarılılı Bir Şekilde Gerçekleştirildi");
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusteriId.Text = dgwMusteri.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSehir.Text = dgwMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dgwMusteri.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            tb.MusteriGuncelle(txtAd.Text,txtSoyad.Text,txtSehir.Text,decimal.Parse(txtBakiye.Text),int.Parse(txtMusteriId.Text));
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (rdbAd.Checked==true)
            {
                dgwMusteri.DataSource=tb.MusteriAraAd(txtAra.Text);
            }
            if (rdbSoyad.Checked==true)
            {
                dgwMusteri.DataSource = tb.MusteriAraSoyad(txtAra.Text);

            }
            if (rdbSehir.Checked==true)
            {
                dgwMusteri.DataSource = tb.MusteriAraSehir(txtAra.Text);

            }
        }
    }
}
