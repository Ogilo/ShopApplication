using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using Hash;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Projekt
{
    public partial class FormRegistracija : Form
    { 
        public FormRegistracija()
        {
            InitializeComponent();  
        }

        private void enLanugage()
        {
            label9.Text = "Generate user";
            label1.Text = "Registration";
            label4.Text = "Name";
            label5.Text = "Surname";
            label7.Text = "Username";
            label2.Text = "Password";
            label3.Text = "Confirm Password";
            label8.Text = "Country";
            checkBox1.Text = "Show password";
            Registracija.Text = "Registration";
        }

        private void croLanguage()
        {
            label9.Text = "Generiraj korisnika";
            label1.Text = "Registracija";
            label4.Text = "Ime";
            label5.Text = "Prezime";
            label7.Text = "Korisnicko ime";
            label2.Text = "Lozinka";
            label3.Text = "Potvrdi lozinku";
            label8.Text = "Država";
            checkBox1.Text = "Prikaži lozinku";
            Registracija.Text = "Registracija";
        }

        public static string username = "";
        public static string password = "";

        class countryName
        {
            public string name { get; set; }
        }

        private void FormRegistracija_Load(object sender, EventArgs e)
        {
            if (FormPrijava.jezik == "en") enLanugage();
            else croLanguage();
            comboBox1.Items.Clear();

            this.CenterToScreen();

            //spajanje na SOAP servis za dobivanje svih mogućih država koji se zapisuju u combobox
            //kaako bi korisnik mogao odabrati državu prilikom registracije  
            CountryService.CountryInfoServiceSoapTypeClient client = new CountryService.CountryInfoServiceSoapTypeClient();
            var res = client.ListOfCountryNamesByName();           

            for(int i = 0; i<res.Length; i++)
            {
                comboBox1.Items.Add(res[i].sName);
            }              
        }

        SqlConnection konekcija = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KorisniciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd = new SqlCommand();

        private void Registracija_Click(object sender, EventArgs e)
        {
            if (textIme.Text == "" || textPrezime.Text == "" || textEmail.Text == "" || textUsername.Text == "" || textLozinka.Text == "")
            {
                MessageBox.Show("Niste unijeli sve potrebne podatke", "Registracija neuspješna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textLozinka.Text == textLozinkaPotvrda.Text)
            {
                //hashiranje lozinke sa slucajnom soli koja je username koja se dodaje na upisanu lozinku
                string saltString = textUsername.Text;
                byte[] salt = Encoding.UTF8.GetBytes(saltString);


                // generiranje random znaka koji služi kao papar
                Random rand = new Random();
                char randChar = (char)rand.Next('a', 'z' + 1);
                string papar = randChar.ToString();

                byte[] hashPassword = Hash.Hash.HashPassword(textLozinka.Text);

                byte[] hashPasswordSaltPepper = Hash.Hash.HashPasswordSaltPepper(Convert.ToBase64String(hashPassword), saltString, papar);              

                //Kreiranje novog korisnika i zapisivanje njegovih podatka u bazu
                cmd.Connection = konekcija;
                cmd.CommandText = "INSERT INTO korisnici(ime,prezime,email,username,userpassword,drzava,sol) VALUES(@name, @Lname, @email, @username, @password, @country, @salt);";
                cmd.Parameters.AddWithValue("@name", textIme.Text);
                cmd.Parameters.AddWithValue("@Lname", textPrezime.Text);
                cmd.Parameters.AddWithValue("@email", textEmail.Text);
                cmd.Parameters.AddWithValue("@username", textUsername.Text);
                cmd.Parameters.AddWithValue("@password", Convert.ToBase64String(hashPasswordSaltPepper));
                cmd.Parameters.AddWithValue("@country", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@salt", Convert.ToBase64String(salt));

                username = textUsername.Text;
                password = textLozinka.Text;

                konekcija.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registracija uspješna!");
                konekcija.Close();
                this.Hide();
                new FormPrijava().Show();             
            }
            else
            {
                MessageBox.Show("Lozinke moraju bit jednake.", "Kriva lozinka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = textLozinka;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textLozinka.PasswordChar = '\0';
            }
            else textLozinka.PasswordChar = '*';
        }

        private void label9_Click(object sender, EventArgs e)
        {
            //spajanje na REST servis "https://randomuser.me/api" kako bi se dobili random podaci korisnika preko metode GET
            //koji se upisuju u polja za registraciju
            var client = new RestClient("https://randomuser.me/api");

            var req = new RestRequest("?inc=name,login,location", Method.Get);

            var response = client.Execute(req);

            if (response.IsSuccessful)
            {               
                var jsonResponse = JsonConvert.DeserializeObject<Response>(response.Content);

                foreach (var result in jsonResponse.Results)
                {
                    textIme.Text = result.name.first;
                    textPrezime.Text = result.name.last;
                    comboBox1.SelectedItem = result.Location.country;
                    textUsername.Text =  result.Login.username;
                    textLozinka.Text = result.Login.password;
                    textEmail.Text = textUsername.Text + "@tvz.hr";
                }                
            }         
        }      

        private void label9_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        public class Response
        {
            public Result[] Results { get; set; }
        }

        public class Result
        {
            public name name { get; set; }
            public Location Location { get; set; }
            public Login Login { get; set; }
        }

        public class name
        {
            public string first { get; set; }
            public string last { get; set; }
        }

        public class Location
        {
            public string country { get; set; }
        }

        public class Login
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textLozinka_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
