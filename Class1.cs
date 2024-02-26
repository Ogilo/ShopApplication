using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


//Rb.28 U datoteci "klasaArtikl.dll" nalazi se klasa Artikl sa varijablama id, naziv, opis, cijena, kategorija i kolicina te funckije DODAJ, UPDATE i DELETE
//DODAJ - dodavanje / zapisivanje dodanog artikla u datoteku "kosara.xml"
//UPDATE - ažuriranje broja količine odabranog artikla u datoteci "kosara.xml" prilikom klika na gumb "Promjeni" na formi "formKosara"
//DELETE - brisanje odabranog artikla u tablici koja se nalazi na formi "formKosara" prilikom kilka na gumb "Izbriši"

namespace klasaArtikl
{
    public class Artikl
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis_kratki { get; set; }
        public double cijena_e { get; set; }
        public string kategorija { get; set; }
        public int kolicina { get; set; }

        static string path = Directory.GetCurrentDirectory() + "\\Kosara.xml";

        //kreairanje i dodavanje artikla u xml file
        public static void DODAJ(Artikl novArtikl)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode Artikli = doc.SelectSingleNode("/Artikli");

            XmlNode Artikl = doc.CreateElement("Artikl");
            XmlNode Id = doc.CreateElement("Id");
            XmlNode Naziv = doc.CreateElement("Naziv");
            XmlNode Opis_k = doc.CreateElement("Opis_kratki");
            XmlNode Cijena_e = doc.CreateElement("Cijena_e");
            XmlNode Kategorija = doc.CreateElement("Kategorija");
            XmlNode Kolicina = doc.CreateElement("Kolicina");

            Id.InnerText = novArtikl.id.ToString();
            Naziv.InnerText = novArtikl.naziv;
            Opis_k.InnerText = novArtikl.opis_kratki;
            Cijena_e.InnerText = novArtikl.cijena_e.ToString();
            Kategorija.InnerText = novArtikl.kategorija;
            Kolicina.InnerText = novArtikl.kolicina.ToString();

            Artikl.AppendChild(Id);
            Artikl.AppendChild(Naziv);
            Artikl.AppendChild(Opis_k);
            Artikl.AppendChild(Cijena_e);
            Artikl.AppendChild(Kategorija);
            Artikl.AppendChild(Kolicina);
            Artikli.AppendChild(Artikl);
            doc.Save(path);
        }

        //metoda za izmjenu kolicine artikla 
        public static void UPDATE(int id, Artikl novArtikl)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode Artikli = doc.SelectSingleNode("/Artikli");
            XmlNode StariArtikl = doc.SelectSingleNode("/Artikli/Artikl[Id = " + id + "]");
            StariArtikl.ChildNodes.Item(5).InnerText = novArtikl.kolicina.ToString();
            doc.Save(path);
        }

        //metoda za brisanje artikla
        public static void DELETE(int id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement el = (XmlElement)doc.SelectSingleNode("/Artikli/Artikl[Id = " + id + "]");
            if (el != null) el.ParentNode.RemoveChild(el);
            doc.Save(path);
        }
    }
}
