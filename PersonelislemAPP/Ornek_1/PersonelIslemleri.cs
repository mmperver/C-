using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ornek_1
{
    public class PersonelIslemleri
    {
        private const string DOSYA_YOLU = "Personel.xml";

        public List<Personel> Listele()
        {
            List<Personel> personeller = new List<Personel>();

            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(DOSYA_YOLU);
            XmlNode nodePersoneller = dokuman.ChildNodes[1];
            foreach (XmlNode nodePersonel in nodePersoneller.ChildNodes)
            {
                Personel personel = new Personel(nodePersonel.ChildNodes[0].InnerText,
                                                 nodePersonel.ChildNodes[1].InnerText,
                                                 Convert.ToDecimal(nodePersonel.ChildNodes[2].InnerText));
                personeller.Add(personel);
            }
            return personeller;
        }

        public void Ekle(Personel personel)
        {
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(DOSYA_YOLU);
            XmlNode nodePersoneller = dokuman.ChildNodes[1];

            XmlNode nodePersonel = dokuman.CreateNode(XmlNodeType.Element, "Personel", "");
            XmlNode nodeAdı = dokuman.CreateNode(XmlNodeType.Element, "Adı", "");
            XmlNode nodeSoyadı = dokuman.CreateNode(XmlNodeType.Element, "Soyadı", "");
            XmlNode nodeMaası = dokuman.CreateNode(XmlNodeType.Element, "Maası", "");

            nodeAdı.InnerText = personel.Adı;
            nodeSoyadı.InnerText = personel.Soyadı;
            nodeMaası.InnerText = personel.Maası.ToString();

            nodePersonel.AppendChild(nodeAdı);
            nodePersonel.AppendChild(nodeSoyadı);
            nodePersonel.AppendChild(nodeMaası);
            nodePersoneller.AppendChild(nodePersonel);

            dokuman.Save(DOSYA_YOLU);
        }

        public void Sil(int index)
        {
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(DOSYA_YOLU);
            XmlNode nodePersoneller = dokuman.ChildNodes[1];

            XmlNode nodeSil = nodePersoneller.ChildNodes[index];
            nodePersoneller.RemoveChild(nodeSil);

            dokuman.Save(DOSYA_YOLU);
        }

        public void Guncelle(int index, Personel personel)
        {
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(DOSYA_YOLU);
            XmlNode nodePersoneller = dokuman.ChildNodes[1];

            XmlNode nodeGuncelle = nodePersoneller.ChildNodes[index];
            nodeGuncelle.ChildNodes[0].InnerText = personel.Adı;
            nodeGuncelle.ChildNodes[1].InnerText = personel.Soyadı;
            nodeGuncelle.ChildNodes[2].InnerText = personel.Maası.ToString();

            dokuman.Save(DOSYA_YOLU);
        }

        public Personel getPersonel(int index)
        {
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(DOSYA_YOLU);
            XmlNode nodePersoneller = dokuman.ChildNodes[1];

            XmlNode nodeAranan = nodePersoneller.ChildNodes[index];
            
            return new Personel(nodeAranan.ChildNodes[0].InnerText,
                                nodeAranan.ChildNodes[1].InnerText,
                                Convert.ToDecimal(nodeAranan.ChildNodes[2].InnerText));
        }
    }
}
