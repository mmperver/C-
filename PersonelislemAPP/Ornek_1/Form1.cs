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
    public partial class Form1 : Form
    {
        PersonelIslemleri personelIslem = new PersonelIslemleri();

        public Form1()
        {
            InitializeComponent();
        }

        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;
            lstAdı.SelectedIndex = lstSoyadı.SelectedIndex = lstMaas.SelectedIndex = lst.SelectedIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Ayarlar.Default.Baslık;
            this.BackColor = Ayarlar.Default.Renk;

            List<Personel> personeller = personelIslem.Listele();
            foreach (Personel personel in personeller)
            {
                lstAdı.Items.Add(personel.Adı);
                lstSoyadı.Items.Add(personel.Soyadı);
                lstMaas.Items.Add(personel.Maası.ToString("C"));
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmPersonel PersonelFrm = new FrmPersonel();
            if(PersonelFrm.ShowDialog() == DialogResult.OK)
            {
                personelIslem.Ekle(PersonelFrm.Personel);//xml ekleme

                lstAdı.Items.Add(PersonelFrm.Personel.Adı);
                lstSoyadı.Items.Add(PersonelFrm.Personel.Soyadı);
                lstMaas.Items.Add(PersonelFrm.Personel.Maası.ToString("C"));
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int index = lstAdı.SelectedIndex;
            if(index != -1)
            {
                personelIslem.Sil(index);//xmlden sil
                //listboxlardan silineni kaldır...
                lstAdı.Items.RemoveAt(index);
                lstSoyadı.Items.RemoveAt(index);
                lstMaas.Items.RemoveAt(index);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int index = lstAdı.SelectedIndex;
            if(index != -1)
            {
                FrmPersonel personelFrm = new FrmPersonel();
                personelFrm.Personel = personelIslem.getPersonel(index);
                if(personelFrm.ShowDialog() == DialogResult.OK)
                {
                    personelIslem.Guncelle(index, personelFrm.Personel);//xmlde güncelle
                    //listboxlarda güncelle
                    lstAdı.Items.RemoveAt(index);
                    lstSoyadı.Items.RemoveAt(index);
                    lstMaas.Items.RemoveAt(index);

                    lstAdı.Items.Insert(index, personelFrm.Personel.Adı);
                    lstSoyadı.Items.Insert(index, personelFrm.Personel.Soyadı);
                    lstMaas.Items.Insert(index, personelFrm.Personel.Maası.ToString("C"));

                    lstAdı.SelectedIndex = index;
                }
            }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FrmAyarlar AyarlarFrm = new FrmAyarlar();
            if(AyarlarFrm.ShowDialog() == DialogResult.OK)
            {
                this.Text = Ayarlar.Default.Baslık;
                this.BackColor = Ayarlar.Default.Renk;
            }
        }
    }
}
