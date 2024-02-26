using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace RacuniDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ucitaj()
        {
            //punjenje tablice datotekama .json
            DirectoryInfo dInfo = new DirectoryInfo("C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\Projekt\\bin\\Debug\\Racuni");

            FileInfo[] files = dInfo.GetFiles("*.json");

            DataTable dt = new DataTable();
            dt.Columns.Add("Broj računa");


            foreach (FileInfo file in files)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(file.Name);
            }
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucitaj();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int redak = dataGridView1.CurrentCell.RowIndex;
            string str = dataGridView1.Rows[redak].Cells["Broj računa"].Value.ToString();

            //čitanje json datoteke
            string json = File.ReadAllText("C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\Projekt\\bin\\Debug\\Racuni\\" + str);
            
            richTextBox1.Text = json;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int redak = dataGridView1.CurrentCell.RowIndex;
            string str = dataGridView1.Rows[redak].Cells["Broj računa"].Value.ToString();

            string json = File.ReadAllText("C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\Projekt\\bin\\Debug\\Racuni\\" + str);

            //uređivanje količine i spremanje u datoteku
            var racunList = JsonConvert.DeserializeObject<List<Racun>>(json);

            foreach (var artikl in racunList)
            {
                artikl.Kolicina += Convert.ToInt16(textBox1.Text);
                MessageBox.Show("Artikl " + artikl.Naziv + "je promjenio količinu za " + textBox1.Text);
            }

            string updatedJson = JsonConvert.SerializeObject(racunList, Formatting.Indented);

            File.WriteAllText("C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\Projekt\\bin\\Debug\\Racuni\\" + str, updatedJson);
            ucitaj();
        }        

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

        private void button2_Click(object sender, EventArgs e)
        {
            int redak = dataGridView1.CurrentCell.RowIndex;
            string str = dataGridView1.Rows[redak].Cells["Broj računa"].Value.ToString();

            //Rb.5 brisnje JSON filea
            File.Delete("C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\Projekt\\bin\\Debug\\Racuni\\" + str);

            ucitaj();
        }
    }
}
