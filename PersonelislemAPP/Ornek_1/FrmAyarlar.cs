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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            txtBaslık.Text = Ayarlar.Default.Baslık;
            txtRenk.Text = Ayarlar.Default.Renk.ToString();
        }

        private void btnRenkSec_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Ayarlar.Default.Renk;
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRenk.Text = colorDialog1.Color.ToString();
                Ayarlar.Default.Renk = colorDialog1.Color;
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            Ayarlar.Default.Baslık = txtBaslık.Text;
            Ayarlar.Default.Save();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Ayarlar.Default.Reload();
        }
    }
}
