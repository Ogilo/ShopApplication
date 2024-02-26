namespace Projekt
{
    partial class formPocetna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPocetna));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cijena_kn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textOpisDugi = new System.Windows.Forms.TextBox();
            this.gumbSpremi = new System.Windows.Forms.Button();
            this.gumbObrisi = new System.Windows.Forms.Button();
            this.textNaziv = new System.Windows.Forms.TextBox();
            this.textOpisKratki = new System.Windows.Forms.TextBox();
            this.textCijena = new System.Windows.Forms.TextBox();
            this.textKategorija = new System.Windows.Forms.TextBox();
            this.gumbDodaj = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gumbUzlazno = new System.Windows.Forms.Button();
            this.gumbSilazno = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gumbUkloniFIlter = new System.Windows.Forms.Button();
            this.buttonDodajKosara = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Kosara = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.računiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOdjava = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cijena_kn});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cijena_kn
            // 
            resources.ApplyResources(this.cijena_kn, "cijena_kn");
            this.cijena_kn.Name = "cijena_kn";
            this.cijena_kn.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textOpisDugi
            // 
            resources.ApplyResources(this.textOpisDugi, "textOpisDugi");
            this.textOpisDugi.Name = "textOpisDugi";
            this.textOpisDugi.ReadOnly = true;
            // 
            // gumbSpremi
            // 
            resources.ApplyResources(this.gumbSpremi, "gumbSpremi");
            this.gumbSpremi.Name = "gumbSpremi";
            this.gumbSpremi.UseVisualStyleBackColor = true;
            this.gumbSpremi.Click += new System.EventHandler(this.gumbSpremi_Click);
            // 
            // gumbObrisi
            // 
            resources.ApplyResources(this.gumbObrisi, "gumbObrisi");
            this.gumbObrisi.Name = "gumbObrisi";
            this.gumbObrisi.UseVisualStyleBackColor = true;
            this.gumbObrisi.Click += new System.EventHandler(this.gumbObrisi_Click);
            // 
            // textNaziv
            // 
            resources.ApplyResources(this.textNaziv, "textNaziv");
            this.textNaziv.Name = "textNaziv";
            this.textNaziv.ReadOnly = true;
            // 
            // textOpisKratki
            // 
            resources.ApplyResources(this.textOpisKratki, "textOpisKratki");
            this.textOpisKratki.Name = "textOpisKratki";
            this.textOpisKratki.ReadOnly = true;
            // 
            // textCijena
            // 
            resources.ApplyResources(this.textCijena, "textCijena");
            this.textCijena.Name = "textCijena";
            this.textCijena.ReadOnly = true;
            // 
            // textKategorija
            // 
            resources.ApplyResources(this.textKategorija, "textKategorija");
            this.textKategorija.Name = "textKategorija";
            this.textKategorija.ReadOnly = true;
            // 
            // gumbDodaj
            // 
            this.gumbDodaj.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.gumbDodaj, "gumbDodaj");
            this.gumbDodaj.Name = "gumbDodaj";
            this.gumbDodaj.UseVisualStyleBackColor = true;
            this.gumbDodaj.Click += new System.EventHandler(this.gumbDodaj_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gumbUzlazno
            // 
            resources.ApplyResources(this.gumbUzlazno, "gumbUzlazno");
            this.gumbUzlazno.Name = "gumbUzlazno";
            this.gumbUzlazno.UseVisualStyleBackColor = true;
            this.gumbUzlazno.Click += new System.EventHandler(this.gumbUzlazno_Click);
            // 
            // gumbSilazno
            // 
            resources.ApplyResources(this.gumbSilazno, "gumbSilazno");
            this.gumbSilazno.Name = "gumbSilazno";
            this.gumbSilazno.UseVisualStyleBackColor = true;
            this.gumbSilazno.Click += new System.EventHandler(this.gumbSilazno_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            resources.GetString("comboBox2.Items"),
            resources.GetString("comboBox2.Items1"),
            resources.GetString("comboBox2.Items2")});
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // gumbUkloniFIlter
            // 
            resources.ApplyResources(this.gumbUkloniFIlter, "gumbUkloniFIlter");
            this.gumbUkloniFIlter.Name = "gumbUkloniFIlter";
            this.gumbUkloniFIlter.UseVisualStyleBackColor = true;
            this.gumbUkloniFIlter.Click += new System.EventHandler(this.gumbUkloniFIlter_Click);
            // 
            // buttonDodajKosara
            // 
            resources.ApplyResources(this.buttonDodajKosara, "buttonDodajKosara");
            this.buttonDodajKosara.Name = "buttonDodajKosara";
            this.buttonDodajKosara.UseVisualStyleBackColor = true;
            this.buttonDodajKosara.Click += new System.EventHandler(this.buttonDodajKosara_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioButton6
            // 
            resources.ApplyResources(this.radioButton6, "radioButton6");
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Kosara
            // 
            this.Kosara.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Kosara, "Kosara");
            this.Kosara.Name = "Kosara";
            this.Kosara.UseVisualStyleBackColor = false;
            this.Kosara.Click += new System.EventHandler(this.Kosara_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.računiToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            resources.ApplyResources(this.korisniciToolStripMenuItem, "korisniciToolStripMenuItem");
            this.korisniciToolStripMenuItem.Click += new System.EventHandler(this.korisniciToolStripMenuItem_Click);
            // 
            // računiToolStripMenuItem
            // 
            this.računiToolStripMenuItem.Name = "računiToolStripMenuItem";
            resources.ApplyResources(this.računiToolStripMenuItem, "računiToolStripMenuItem");
            this.računiToolStripMenuItem.Click += new System.EventHandler(this.računiToolStripMenuItem_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chat
            // 
            this.chat.AllowDrop = true;
            resources.ApplyResources(this.chat, "chat");
            this.chat.Name = "chat";
            this.chat.TextChanged += new System.EventHandler(this.chat_TextChanged);
            this.chat.DragEnter += new System.Windows.Forms.DragEventHandler(this.chat_DragEnter);
            this.chat.Enter += new System.EventHandler(this.chat_Enter);
            this.chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_KeyDown);
            this.chat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chat_KeyPress);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // buttonOdjava
            // 
            resources.ApplyResources(this.buttonOdjava, "buttonOdjava");
            this.buttonOdjava.Name = "buttonOdjava";
            this.buttonOdjava.UseVisualStyleBackColor = true;
            this.buttonOdjava.Click += new System.EventHandler(this.buttonOdjava_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // formPocetna
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonOdjava);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Kosara);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDodajKosara);
            this.Controls.Add(this.gumbUkloniFIlter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gumbSilazno);
            this.Controls.Add(this.gumbUzlazno);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.gumbDodaj);
            this.Controls.Add(this.textKategorija);
            this.Controls.Add(this.textCijena);
            this.Controls.Add(this.textOpisKratki);
            this.Controls.Add(this.textNaziv);
            this.Controls.Add(this.gumbObrisi);
            this.Controls.Add(this.gumbSpremi);
            this.Controls.Add(this.textOpisDugi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formPocetna";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formPocetna_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formPocetna_FormClosed);
            this.Load += new System.EventHandler(this.formPocetna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textOpisDugi;
        private System.Windows.Forms.Button gumbSpremi;
        private System.Windows.Forms.Button gumbObrisi;
        private System.Windows.Forms.TextBox textNaziv;
        private System.Windows.Forms.TextBox textOpisKratki;
        private System.Windows.Forms.TextBox textCijena;
        private System.Windows.Forms.TextBox textKategorija;
        private System.Windows.Forms.Button gumbDodaj;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cijena_kn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button gumbUzlazno;
        private System.Windows.Forms.Button gumbSilazno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button gumbUkloniFIlter;
        private System.Windows.Forms.Button buttonDodajKosara;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button Kosara;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem računiToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOdjava;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}