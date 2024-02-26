using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using KorisniciDLL;
using RacuniDLL;
using klasaArtikl;
using System.Security.Cryptography;
using System.Globalization;
using System.Resources;
using System.Reflection;
using RestSharp;
using Newtonsoft.Json;

namespace Projekt
{
    public partial class formPocetna : Form
    {
        public int artiklID = 0;
        SqlConnection konekcija = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KorisniciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");                  

        public formPocetna()
        {
            InitializeComponent();
        }       

        //učitavanje kategorija iz baze za prikaz u comboboxu
        private void ComboBoxLoad()
        {
            comboBox1.Items.Clear();
            konekcija.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT kategorija FROM artikli;", konekcija);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            konekcija.Close();
        }

        //Rb.3 sučelje na 2 jezika, engleski i hrvatski koji se bira na formi prijava klikom na radio button i pamti ga u nastavku
        // kako bi druge forme znale koji je jezik odabran

        private void enLanguage()
        {
            label1.Text = "Search by name";
            label4.Text = "Sort by";
            gumbUzlazno.Text = "Ascending";
            gumbSilazno.Text = "Descending";
            label3.Text = "Filter by category";
            gumbUkloniFIlter.Text = "Remove filter";
            textNaziv.Text = "Name";
            textCijena.Text = "Price";
            textOpisKratki.Text = "Short desc";
            textKategorija.Text = "Category";
            buttonDodajKosara.Text = "Add to basket";
            groupBox1.Text = "Quantity";
            button1.Text = "Ask question";
            button2.Text = "Download our catalog";
            label2.Text = "Welcome";
            label5.Text = "Downloading...";
            buttonOdjava.Text = "Log out";
            button4.Text = "Exchange rates";
            gumbDodaj.Text = "Add";
            gumbObrisi.Text = "Delete";
            gumbSpremi.Text = "Save";
            button3.Text = "Send text";
        }

        private void croLanguage()
        {
            label1.Text = "Pretraži po nazivu";
            label4.Text = "Sortiraj po";
            gumbUzlazno.Text = "Uzlazno";
            gumbSilazno.Text = "Silazno";
            label3.Text = "Filter po kategoriji";
            gumbUkloniFIlter.Text = "Ukloni filter";
            textNaziv.Text = "Naziv";
            textCijena.Text = "Cijena";
            textOpisKratki.Text = "Kratki opis";
            textKategorija.Text = "Kategorija";
            buttonDodajKosara.Text = "Dodaj u košaru";
            groupBox1.Text = "Količina";
            button1.Text = "Postavite pitanje";
            button2.Text = "Preuzmi katalog";
            label2.Text = "Dobrodošli";
            label5.Text = "Preuzimanje...";
            buttonOdjava.Text = "Odjava";
            button4.Text = "Srednji tečaj";
            gumbDodaj.Text = "Dodaj";
            gumbObrisi.Text = "Obriši";
            gumbSpremi.Text = "Spremi";
            button3.Text = "Pošalji tekst";
        }

        private void PocetnaLoad()
        {
            button4.Visible = false;
            ComboBoxLoad();
            chat.ScrollBars = ScrollBars.Vertical;

            if (FormPrijava.jezik == "hr") croLanguage();
            else enLanguage();

            //dobivanje imena preko druge forme i da li je korisnik admin koje se dobije čitanjem iz baze prilikom prijavom gdje se sprema u varijablju,
            //čita se iz forme za prijavu kako bi se prikazalo koji korisnik
            //je ulogiran tekstom "Dobrodošli Ozren" i da li je admin
            if (FormPrijava.is_admin)
            {
                label2.Text = label2.Text + " " + FormPrijava.ime + ", vi ste admin";
                AdminEdit();
            }
            else label2.Text = label2.Text + " " + FormPrijava.ime;

            konekcija.Open();

            //čitanje artikla iz baze artikli koji se prikazuju u tablici
            SqlDataAdapter da = new SqlDataAdapter("SELECT id_artikl, naziv,opis_kratki,cijena_e,kategorija FROM artikli", konekcija);
            
            DataSet ds = new DataSet();

            da.Fill(ds, "artikli");
            dataGridView1.DataSource = ds.Tables["artikli"];
            dataGridView1.Columns["id_artikl"].Visible = false;
            dataGridView1.Columns["cijena_kn"].DisplayIndex = 4;
            dataGridView1.AllowUserToAddRows = false;

            izracunCijena_kn();

            konekcija.Close();
        }

        //Rb 8. tablici koristi calculated tip polja izracun cijene u kunama koji se prikazuje u tablici
        //pored orginalne cijene koja je u eurima
        void izracunCijena_kn()
        {
            if (dataGridView1.Rows.Count == 0) return;
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int row_num = row.Index;

                    dataGridView1["cijena_kn", row_num].Value = Convert.ToInt32(dataGridView1.Rows[row_num].Cells[4].Value) * 7.5345;
                }
                this.dataGridView1.CurrentCell.Selected = false;
            }                     
        }

        //postavke admina gdje se prilikom prijave čita stupac u tablici da li je korisnik admin
        private void AdminEdit()
        {
            menuStrip1.Visible = true;
            textNaziv.ReadOnly = false;
            textOpisKratki.ReadOnly = false;
            textCijena.ReadOnly = false;
            textKategorija.ReadOnly = false;
            textOpisDugi.ReadOnly = false;
            gumbSpremi.Visible = true;
            gumbObrisi.Visible = true;
            gumbDodaj.Visible = true;
        }

        private void formPocetna_Load(object sender, EventArgs e)
        {
            // učitavanje zadnjih spremjljenih postavki(visina, širina i lokacija) iz ConfigFIle.ini

            IniFile ini = new IniFile("Settings\\ConfigFile.ini");
            int height = Convert.ToInt32(ini.ReadINI("FormProperties", "Height"));
            int width = Convert.ToInt32(ini.ReadINI("FormProperties", "Width"));
            int locX = Convert.ToInt32(ini.ReadINI("FormProperties", "LocationX"));
            int locY = Convert.ToInt32(ini.ReadINI("FormProperties", "LocationY"));

            this.Left = locX;
            this.Top = locY;
            this.Height = height;
            this.Width = width;
            PocetnaLoad();
            ComboBoxLoad();
            comboBox2.SelectedIndex = 0;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int redak = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[redak].Cells["id_artikl"].Value.ToString());

            if (konekcija.State == ConnectionState.Closed) konekcija.Open();

            //Rb 7. čitanje podataka iz baze
            SqlCommand cmd = new SqlCommand("SELECT id_artikl, slika, opis_dugi, naziv, cijena_e, kategorija, opis_kratki FROM artikli WHERE id_artikl=@id ;", konekcija);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textNaziv.Text = reader["naziv"].ToString();
                textOpisKratki.Text = reader["opis_kratki"].ToString();
                textCijena.Text = reader["cijena_e"].ToString().Replace(",",".");
                textKategorija.Text = reader["kategorija"].ToString();
                textOpisDugi.Text = reader["opis_dugi"].ToString();
            }     
            reader.Close();        

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Rb 9. čitanje blob polja
            if (ds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["slika"]);
                pictureBox1.Image = Image.FromStream(ms);
            }
            konekcija.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void gumbSpremi_Click(object sender, EventArgs e)
        {
            //Rb 7. spremanje promjenjenih podataka odabranog artikla i ažuriranje same baze
            DialogResult dr = MessageBox.Show("Jeste sigurni da želite spremiti promjene?", "Spremi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            int redak = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[redak].Cells["id_artikl"].Value.ToString());

            if (dr == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("UPDATE artikli SET naziv='" + textNaziv.Text + "', opis_kratki='" + textOpisKratki.Text + "', opis_dugi='" + textOpisDugi.Text + "', cijena_e ='" + textCijena.Text + "', kategorija='" + textKategorija.Text + "' WHERE id_artikl=@id;", konekcija);
                cmd.Parameters.AddWithValue("@id", id);
                konekcija.Open();
                cmd.ExecuteNonQuery();
                konekcija.Close();
                PocetnaLoad();
            }
        }

        private void gumbObrisi_Click(object sender, EventArgs e)
        {
            // Rb 7. brisanje odabranog artikla iz baze
            DialogResult dr = MessageBox.Show("Jeste sigurni da želite izrbisati artikl?", "Izbriši", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            int redak = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[redak].Cells["id_artikl"].Value.ToString());

            if (dr == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM artikli WHERE id_artikl = @id;", konekcija);
                cmd.Parameters.AddWithValue("@id", id);
                konekcija.Open();
                cmd.ExecuteNonQuery();
                konekcija.Close();
                PocetnaLoad();
            }
        }

        private void gumbDodaj_Click(object sender, EventArgs e)
        {
            //Rb 7. dodavanje novog artikla u bazu artikli gdje se zapisuju podatci koji su prethodno napisani u odgovarajuća polja
            //i dodavanje slika preko open file dialoga
            // Rb 9. pisanje slike(blob) u bazu
            string path = "";

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "C:\\";
                ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;

                    SqlCommand cmd = new SqlCommand("INSERT into artikli (naziv, opis_kratki, opis_dugi, cijena_e, slika, kategorija) VALUES('" + textNaziv.Text + "','" + textOpisKratki.Text + "','" + textOpisDugi.Text + "','" + textCijena.Text + "', (SELECT * FROM OPENROWSET(BULK N'" + path + "', SINGLE_BLOB) AS IMG),'" + textKategorija.Text + "');", konekcija);
                    konekcija.Open();
                    cmd.ExecuteNonQuery();
                    konekcija.Close();
                }
            }
            PocetnaLoad();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // pretraživanja artikla po nazivu
            konekcija = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KorisniciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            konekcija.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT id_artikl, naziv,opis_kratki, cijena_e, kategorija FROM artikli where naziv like '" + textBox1.Text + "%'", konekcija);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["cijena_kn"].DisplayIndex = 4;

            izracunCijena_kn();
            konekcija.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            konekcija.Open();

            //Rb 8. filtriranje artikala po kategorija koji se čitaju iz tablice
            SqlDataAdapter da = new SqlDataAdapter("SELECT id_artikl, naziv,opis_kratki,cijena_e,kategorija FROM artikli WHERE kategorija LIKE @kategorija", konekcija);
            da.SelectCommand.Parameters.AddWithValue("@kategorija",  comboBox1.Text);

            DataSet ds = new DataSet();

            da.Fill(ds, "artikli");
            dataGridView1.DataSource = ds.Tables["artikli"];
            dataGridView1.Columns["id_artikl"].Visible = false;
            dataGridView1.Columns["cijena_kn"].DisplayIndex = 4;
            dataGridView1.AllowUserToAddRows = false;

            izracunCijena_kn();
            konekcija.Close();
        }

        private void gumbUzlazno_Click(object sender, EventArgs e)
        {
            //Rb 8. sortiranje uzlazno
            dataGridView1.Sort(dataGridView1.Columns[comboBox2.Text], ListSortDirection.Ascending);
            izracunCijena_kn();
        }

        private void gumbSilazno_Click(object sender, EventArgs e)
        {
            //Rb 8. sortiranje silazno
            dataGridView1.Sort(dataGridView1.Columns[comboBox2.Text], ListSortDirection.Descending);
            izracunCijena_kn();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gumbUkloniFIlter_Click(object sender, EventArgs e)
        {
            PocetnaLoad();
        }

        private void formPocetna_FormClosed(object sender, FormClosedEventArgs e)
        {
            // spremanje postavvki u ConfigFile.ini
            var ini = new IniFile("Settings\\ConfigFile.ini");

            ini.WriteINI("FormProperties", "Width", this.Width.ToString());
            ini.WriteINI("FormProperties", "Height", this.Height.ToString());
            ini.WriteINI("FormProperties", "LocationX", this.Location.X.ToString());
            ini.WriteINI("FormProperties", "LocationY", this.Location.Y.ToString());

            System.Windows.Forms.Application.Exit();
        }

        private void buttonDodajKosara_Click(object sender, EventArgs e)
        {           
            int redak = dataGridView1.CurrentCell.RowIndex;      
            var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;

            //Rb.5 pisanje podataka(odabranog artikla) u XML file
            //klasa i metode se nalaze u dinamickoj biblioteci klasaArtikl.dll
            Artikl a = new Artikl();
            a.id = artiklID+1;
            artiklID += 1;
            a.naziv = dataGridView1.Rows[redak].Cells["naziv"].Value.ToString();
            a.opis_kratki = dataGridView1.Rows[redak].Cells["opis_kratki"].Value.ToString();
            a.cijena_e = Convert.ToDouble(dataGridView1.Rows[redak].Cells["cijena_e"].Value);
            a.kategorija = dataGridView1.Rows[redak].Cells["kategorija"].Value.ToString();
            a.kolicina = Convert.ToInt32(checkedButton);

            Artikl.DODAJ(a); 

            Kosara.Text = "(" + artiklID + ")";
        }

        //otvaranje forme kosara
        private void Kosara_Click(object sender, EventArgs e)
        {
            if (artiklID == 0)
            {
                MessageBox.Show("Dodajte artikl u košaru da bi nastavili.");
            }
            else
            {
                this.Hide();
                new formKosara().Show();
            }          
        }


        private const int ServerPort = 8080;
        private const string ServerIp = "192.168.1.73";

        private TcpClient client;
      
        private StreamWriter writer;
        private StreamReader reader;

        private Thread recieveThread;

        private void button1_Click(object sender, EventArgs e)
        {
            // Otvaranje proces koji sluši kao TCP server gdje korisnik može poslati tekst koji je napisao u "chat" 
            Process.Start("C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\TCP_Server\\bin\\Debug\\net6.0\\TCP_Server.exe");

            try
            {
                //Pokretanje TCP servera na klijent strani i spajanje na odabrani port i adresu
                //Pokretanje readera i writera za pisanje i čitanje streamova preko TCP 
                client = new TcpClient();
                client.Connect(ServerIp, ServerPort);
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());

                //pokretanje dretve za primanje streamova preko TCP servera
                //da bi se u istom trenutku mogli obaljaviti ostali zadatci u programu
                recieveThread = new Thread(receiveMessages);
                recieveThread.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Pogreška pri spajanju: " + ex.Message);
            }       
        }
        private void receiveMessages()
        {
            try
            {
                //čitanje streama dobivenog od strane servera i njegovo zapisivanje u "chat"
                while (true)
                {
                    string receivedMessage = reader.ReadLine();
                    if (receivedMessage == null) break;

                    //Sinkronizacija "chata" u korisničkom sučelju(poruka dobive4na od servera)
                    //Bez Invoke metode, dobili bi grešku da se "chatu" pristupa na Threadu u kojem nije napravljen(Cross-Thread operation not valid)
                    Invoke(new Action(() =>
                    {
                        chat.AppendText("Server: " + receivedMessage + Environment.NewLine);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error u primanju poruke: " + ex.Message);
            }
            finally
            {
                //zatvaranje TCP i streama za čitanje i pisanje
                reader.Close();
                writer.Close();
                client.Close();
            }
        }

        private void chat_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void chat_Enter(object sender, EventArgs e)
        {
            
        }      

        private void chat_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void chat_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();   

            string url = "https://raw.githubusercontent.com/Ogilo/NTP/main/4.webp";
            string path = "C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\katalog.jpg";          

            // slanje HTTP get requesta korištenjem GetAsync metode i spremanje odgovora u varijablu response
            using (HttpResponseMessage response = await httpClient.GetAsync(url))
            {                
                long? contentLength = response.Content.Headers.ContentLength;            
                
                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {
                    // različite brzine(buffer) tijeka prijenosa podataka
                    byte[] bufferL = new byte[1026];
                    byte[] bufferM = new byte[4096];
                    byte[] bufferH = new byte[8192];

                    int downloadedBytes = 0;
                    int bytesRead = 0;
                    int prevPerc = 0;

                    int perc = 0;

                    //kreiranje dobivenog kataloga i njegovo spremanje u datoteku koja se nalazi u varijabli "path"
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        // čitanje streama u chunkovima odabranim bufferom
                        while ((bytesRead = await stream.ReadAsync(bufferL, 0, bufferL.Length)) > 0)
                        {
                            //zapisivanje podataka u fileStream
                            await fs.WriteAsync(bufferL, 0, bytesRead);

                            downloadedBytes += bytesRead;

                            double prog = downloadedBytes / (double)contentLength.Value;
                            perc = (int)(prog * 100);

                            if (perc != prevPerc)
                            {
                               prevPerc = perc;
                               // prikaz postotka preuzetog sadržaja preko komponente ProgressBar
                               progressBar1.Value = perc;
                            }                           

                            // sigurno ažuriranje komponente na korisničkom sučelju,
                            //u ovom slučaju teksta koji prikazuje postotka preuzetog sadržaja preko http klijent komponente
                            await Task.Run(() => {
                                label5.Invoke((MethodInvoker)(() => label5.Text = perc + "%"));
                            });
                        }

                    }
                }
            }
            MessageBox.Show("Preuzimanje dovršeno");          
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //Rb.29 Aplikacija koristi 2 DLL dijaloga            
        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            //Korisnici.dll za prikaz svih korisnika
            new KorisniciDLL.Form1().Show();
        }

        private void računiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Racuni.dll za prikaz svih računa
            new RacuniDLL.Form1().Show();
        }

        private void buttonOdjava_Click(object sender, EventArgs e)
        {            
            this.Hide();
            new FormPrijava().Show();
        }

        private void formPocetna_FormClosing(object sender, FormClosingEventArgs e)
        {
            //zatvaranje TCP server i streama za čitanje i pisanje
            if(writer != null) writer.Close();
            if(client != null) client.Close();
            if(reader != null) reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //zapisivanje stringa u stream i slanje serveru
            string message = chat.Lines[chat.Lines.Length - 1];
            writer.WriteLine(message);
            writer.Flush();

            chat.AppendText(Environment.NewLine);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Rb. 20 kreiranje Rest klase za dobivanje srednjih tečajeva ostalih država izvršavanjem GET metodom
            var client = new RestClient("https://api.hnb.hr/tecajn-eur/v3");

            var req = new RestRequest("",Method.Get);

            var response = client.Execute(req);

            //dobiveni odogovr(varijabla response) se deserijalizira u listu objekta tecaj koji se zapisuje u "chat"
            if (response.IsSuccessful)
            {
                var jsonResponse = JsonConvert.DeserializeObject<List<Tecaj>>(response.Content);

                foreach(var tecaj in jsonResponse)
                {
                    chat.AppendText(tecaj.drzava + " " + tecaj.valuta + " " + tecaj.srednji_tecaj + Environment.NewLine);
                }
            }
        }
        
        public class Tecaj
        {
            public string drzava { get; set; }
            public string valuta { get; set; }
            public string srednji_tecaj { get; set; }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //mijenjanje slike(BLOB) klikom na Picturebox1
            string path = "";
            int redak = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[redak].Cells["id_artikl"].Value.ToString());

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "C:\\";
                ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;

                    SqlCommand cmd = new SqlCommand("UPDATE artikli SET slika = (SELECT * FROM OPENROWSET(BULK N'" + path + "', SINGLE_BLOB) AS IMG) WHERE id_artikl = @id;", konekcija);
                    cmd.Parameters.AddWithValue("@id", id);
                    konekcija.Open();
                    cmd.ExecuteNonQuery();
                    konekcija.Close();
                }
            }
            PocetnaLoad();
        }

        private void chat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
