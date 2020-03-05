using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ornek_1
{
    public partial class FrmPersonel : Form
    {
        private bool kapanma = false;

        private Personel _personel = new Personel();
        public Personel Personel
        {
            get { return _personel; }
            set { _personel = value; }
        }

        private bool Ad_Kontrol()
        {
            if (String.IsNullOrEmpty(txtAd.Text.Trim()))
            {
                // MessageBox.Show("Ad Alanı Boş Geçilemez...");
                errorProvider1.SetError(txtAd, "Adı Alanı Boş Geçilemez!!!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtAd, "");//hata kaldırma
                return true;
            }
        }

        private bool Soyad_Kontrol()
        {
            if (String.IsNullOrEmpty(txtSoyad.Text.Trim()))
            {
                // MessageBox.Show("Ad Alanı Boş Geçilemez...");
                errorProvider1.SetError(txtSoyad, "Soyadı Alanı Boş Geçilemez!!!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtSoyad, "");//hata kaldırma
                return true;
            }
        }

        private bool Maas_Kontrol()
        {
            decimal para = 0;
            if(String.IsNullOrEmpty(txtMaas.Text.Trim()))
            {
                errorProvider1.SetError(txtMaas, "Maaş Alanı Boş Geçilemez!!!");
                return false;
            }
            else if(!decimal.TryParse(txtMaas.Text.Trim(), out para))
            {
                errorProvider1.SetError(txtMaas, "Maaş Alanı Sayısal Olmalıdır!!!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtMaas, "");
                return true;
            }
        }

        private bool GirdiKontrol()
        {
            if (Ad_Kontrol() && Soyad_Kontrol() && Maas_Kontrol())// && Soyad_Kontrol() && Maas_Kontrol())
                return true;
            else 
                return false;
        }

        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            txtAd.Text = this.Personel.Adı;
            txtSoyad.Text = this.Personel.Soyadı;
            txtMaas.Text = this.Personel.Maası.ToString();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (GirdiKontrol())
            {
                this.Personel.Adı = txtAd.Text;
                this.Personel.Soyadı = txtSoyad.Text;
                this.Personel.Maası = Convert.ToDecimal(txtMaas.Text);
                //unutulmamalı...
                kapanma = false;
            }
            else
            {
                kapanma = true;
                //kapamayı İptal et...
            }
        }

        private void FrmPersonel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = kapanma;
        }

        private void txtAd_Leave(object sender, EventArgs e)
        {
            Ad_Kontrol();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            kapanma = false;
        }
    }
}
