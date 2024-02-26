namespace Projekt
{
    partial class formKosara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formKosara));
            this.tablicaKosara = new System.Windows.Forms.DataGridView();
            this.gumbPromjeni = new System.Windows.Forms.Button();
            this.gumbIzbrisi = new System.Windows.Forms.Button();
            this.gumbRacun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablicaKosara)).BeginInit();
            this.SuspendLayout();
            // 
            // tablicaKosara
            // 
            this.tablicaKosara.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablicaKosara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.tablicaKosara, "tablicaKosara");
            this.tablicaKosara.Name = "tablicaKosara";
            this.tablicaKosara.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablicaKosara_CellContentClick);
            // 
            // gumbPromjeni
            // 
            resources.ApplyResources(this.gumbPromjeni, "gumbPromjeni");
            this.gumbPromjeni.Name = "gumbPromjeni";
            this.gumbPromjeni.UseVisualStyleBackColor = true;
            this.gumbPromjeni.Click += new System.EventHandler(this.gumbPromjeni_Click);
            // 
            // gumbIzbrisi
            // 
            resources.ApplyResources(this.gumbIzbrisi, "gumbIzbrisi");
            this.gumbIzbrisi.Name = "gumbIzbrisi";
            this.gumbIzbrisi.UseVisualStyleBackColor = true;
            this.gumbIzbrisi.Click += new System.EventHandler(this.gumbIzbrisi_Click);
            // 
            // gumbRacun
            // 
            resources.ApplyResources(this.gumbRacun, "gumbRacun");
            this.gumbRacun.Name = "gumbRacun";
            this.gumbRacun.UseVisualStyleBackColor = true;
            this.gumbRacun.Click += new System.EventHandler(this.gumbRacun_Click);
            // 
            // formKosara
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gumbRacun);
            this.Controls.Add(this.gumbIzbrisi);
            this.Controls.Add(this.gumbPromjeni);
            this.Controls.Add(this.tablicaKosara);
            this.Name = "formKosara";
            this.Load += new System.EventHandler(this.formKosara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablicaKosara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView tablicaKosara;
        public System.Windows.Forms.Button gumbPromjeni;
        public System.Windows.Forms.Button gumbIzbrisi;
        public System.Windows.Forms.Button gumbRacun;
    }
}