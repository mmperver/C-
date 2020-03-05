using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_1
{
    public class Personel
    {
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public decimal Maası { get; set; }

        public Personel()
        {
            this.Adı = "";
            this.Soyadı = "";
            this.Maası = 0;
        }

        public Personel(string ad, string soyad, decimal maas)
        {
            this.Adı = ad;
            this.Soyadı = soyad;
            this.Maası = maas;
        }
    }
}
