using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using LogoDll;
using Hash;
using Microsoft.Win32;

namespace Projekt
{
    public partial class FormPrijava : Form
    {
        public FormPrijava()
        {
            InitializeComponent();         
        }

        public static string ime = "";
        public static bool is_admin = false;
        public static string jezik = "";

        // Rb.7 spajanje na lokalnu SQL server bazu
        SqlConnection konekcija = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KorisniciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataReader reader;

        private void Form1_Load(object sender, EventArgs e)
        {
            is_admin = false;
            radioButton1.Checked = true;
            textUser.Text = FormRegistracija.username;
            textPass.Text = FormRegistracija.password;
            logoSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            //Rb.30 iz Logo.dll se dohvaća spremljena slika koja služi kao logo na formi za prijavu
            logoSlika.Image = LogoDll.Properties.Resources.logo; 
            this.CenterToScreen();

            //Čitanje iz registra 'SOFTWARE\Prijava' zadnjeg prijavljenog korisnika
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Prijava");
            if (key != null)
            {
                textUser.Text = key.GetValue("LastUsername").ToString();
                key.Close();
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormRegistracija().Show();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textPass.PasswordChar = '\0';
            }
            else textPass.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                jezik = "en";

            }else jezik = "hr";

            //Rb 14. pokreće se novi proces koji služi za provjeravanje podataka za prijavu
            //i čeka odgovor 1 ako je prijava uspješna ili 0 ako su upisani krivi podatci
            string username = textUser.Text;
            string pass = textPass.Text;
           
            Process p = new Process();
            p.StartInfo.FileName = "C:\\Users\\User\\OneDrive - Zagreb University of Applied Science\\Desktop\\Projekt\\Korisnik_Provjera\\bin\\Debug\\net6.0\\Korisnik_provjera.exe";
            p.StartInfo.Arguments = username + " " + pass + " " + jezik;
            p.Start();
            
            
            p.WaitForExit();

            //dobivanje odgvora od pokrenutog proces
            int prijavaUspješna = p.ExitCode;

            if (prijavaUspješna == 1)
            {
                //Rb 7. čitanje podataka iz baze, čitanje imena i da li je korisnik admin koje će
                //služiti za druge stvari u ostalim formama
                cmd = new SqlCommand("SELECT * FROM korisnici where username=@username", konekcija);
                cmd.Parameters.AddWithValue("@username", textUser.Text);

                konekcija.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ime = reader["ime"].ToString();
                    if ((bool)reader["isadmin"])
                    {
                        is_admin = true;
                    }
                }

                //zapisivanje u registar 'SOFTWARE\Prijava' prijavljenog korisnika
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Prijava");
                key.SetValue("LastUsername", textUser.Text);
                key.Close();

                this.Hide();
                new formPocetna().Show();
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void enLanguage()
        {
            label1.Text = "Log in";
            label4.Text = "Username";
            label3.Text = "Password";
            button1.Text = "Log in";
            label2.Text = "Registration";
            checkBox1.Text = "Show password";
            radioButton1.Text = "croatian";
            radioButton2.Text = "english";
        }

        private void croLanguage()
        {
            label1.Text = "Prijava";
            label4.Text = "Korisnicko ime";
            label3.Text = "Lozinka";
            button1.Text = "Prijava";
            label2.Text = "Registracija";
            checkBox1.Text = "Prikazi lozinku";
            radioButton1.Text = "hrvatski";
            radioButton2.Text = "engleski";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            croLanguage();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            enLanguage();
        }

        private void logoSlika_Click(object sender, EventArgs e)
        {

        }
    }
}
