using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
//using Newtonsoft.Json;
using Microsoft.Win32;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
using Microsoft.Reporting.WinForms;
using klasaArtikl;

namespace Projekt
{
    public partial class formKosara : Form
    {
        public formKosara()
        {
            InitializeComponent();
        }

        int brRac = 0;

        ReportDataSource rs = new ReportDataSource();
        
        public class Racun
        {
            public string Datum { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public double Cijena { get; set; }
            public string Kategorija { get; set; }
            public int Kolicina { get; set; }
            public double Total { get; set; }         
        }     

        private void LoadXML()
        {
            // Učitavnje XML datoteke

            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + "\\Kosara.xml");

            if(doc.SelectSingleNode("/Artikli/Artikl") != null)
            {
                DataSet ds = new DataSet();
                ds.ReadXml("Kosara.xml");
                tablicaKosara.DataSource = ds.Tables[0];
                tablicaKosara.Columns[0].Visible = false;
                tablicaKosara.Columns[1].ReadOnly = true;
                tablicaKosara.Columns[2].ReadOnly = true;
                tablicaKosara.Columns[3].ReadOnly = true;
                tablicaKosara.Columns[4].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Obrisani su svi artikli, povratak na početnu");
                this.Hide();
                new formPocetna().Show();
            }
        }

        private void enLanguage()
        {
            gumbIzbrisi.Text = "Delete selected";
            gumbPromjeni.Text = "Chnage quantity";
            gumbRacun.Text = "Check receipt";
        }

        private void croLanguage()
        {
            gumbIzbrisi.Text = "Obriši odabrano";
            gumbPromjeni.Text = "Promjeni količinu";
            gumbRacun.Text = "Pogledaj računa";
        }

        private void formKosara_Load(object sender, EventArgs e)
        {
            LoadXML();
            if (FormPrijava.jezik == "hr") croLanguage();
            else enLanguage();
        }

        private void gumbPromjeni_Click(object sender, EventArgs e)
        {
            int rowIndex = tablicaKosara.CurrentCell.RowIndex;
            int id = Convert.ToInt32(tablicaKosara.Rows[rowIndex].Cells[0].Value);
            int kol = Convert.ToInt32(tablicaKosara.CurrentCell.Value);

            Artikl.UPDATE(id, new Artikl() { kolicina = kol }); // uređivanje XML filea po idu
            LoadXML();
        }

        private void gumbIzbrisi_Click(object sender, EventArgs e)
        {
            int rowIndex = tablicaKosara.CurrentCell.RowIndex;
            int id = Convert.ToInt32(tablicaKosara.Rows[rowIndex].Cells[0].Value);

            Artikl.DELETE(id); // brisanje XML filea po idu
            LoadXML();
        }

        public void gumbRacun_Click(object sender, EventArgs e)
        { 
            // podaci koji se šalju u izvještaj(rs)
            List<Racun> list = new List<Racun>();
            list.Clear();

            for (int i = 0; i < tablicaKosara.Rows.Count - 1; i++)
            {
                list.Add(new Racun
                {
                    Naziv = tablicaKosara.Rows[i].Cells[1].Value.ToString(),
                    Opis = tablicaKosara.Rows[i].Cells[2].Value.ToString(),
                    Cijena = double.Parse(tablicaKosara.Rows[i].Cells[3].Value.ToString()),
                    Kategorija = tablicaKosara.Rows[i].Cells[4].Value.ToString(),
                    Kolicina = int.Parse(tablicaKosara.Rows[i].Cells[5].Value.ToString()),
                    Total = double.Parse(tablicaKosara.Rows[i].Cells[3].Value.ToString()) * int.Parse(tablicaKosara.Rows[i].Cells[5].Value.ToString()),
                    Datum = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
                }); 

                rs.Name = "DataSet1";
                rs.Value = list;     
            }

            
            //brisanje .xml filea nakon kreiranja računa
            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + "\\Kosara.xml");
            XmlNodeList nodes = doc.SelectNodes("//Artikl");
            for(int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
            doc.Save(Directory.GetCurrentDirectory() + "\\Kosara.xml");          


            //Rb.4 čitanje registra broja zadnjeg računa kako bi counter mogao nastaviti dalje
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Racun");
            if (key != null)
            {
                brRac = Convert.ToInt32(key.GetValue("LastBillNumber"));
                key.Close();
            }

            
            Racun racun = new Racun();
            string fileName = "Racuni\\Racun_" + brRac + ".json";

            var postavke = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            //Rb.5 pisanje podataka računa u JSON file (Racun_X.json)
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("[");

                foreach (DataGridViewRow row in tablicaKosara.Rows)
                {
                    if (row.IsNewRow) continue;            

                    racun.Naziv = Convert.ToString(row.Cells["Naziv"].Value);
                    racun.Opis = Convert.ToString(row.Cells["Opis_kratki"].Value);
                    racun.Cijena = Convert.ToDouble(row.Cells["Cijena_e"].Value);
                    racun.Kategorija = Convert.ToString(row.Cells["Kategorija"].Value);
                    racun.Kolicina = Convert.ToInt16(row.Cells["Kolicina"].Value);

                    racun.Total = Convert.ToDouble(racun.Cijena * racun.Kolicina);

                    racun.Datum = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                    string jsonString = JsonSerializer.Serialize(racun, postavke);
                    writer.WriteLine(jsonString);
                    if (row.Index == tablicaKosara.Rows.Count - 2) break;
                    else
                    {
                        writer.WriteLine(",");
                    }
                }
                writer.WriteLine("]");
                
                writer.Close();
            }
            

            brRac += 1;

            // spremanje zadnjeg broja računa i datuma računa kada je napravljen u registar SOFTWARE\Racun 
            key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Racun");
            key.SetValue("LastBillNumber", brRac);
            key.SetValue("LastBillDate", racun.Datum);
            key.Close();

            //Rb 10. otvaranje forme u kojoj se naalzi izvještaj
            form2 frm = new form2();
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(rs);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "Projekt.Report.rdlc";

            frm.ShowDialog();
            this.Close();
        }

        private void tablicaKosara_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
