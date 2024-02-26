using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QRCoder;

namespace Projekt
{
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        private void form2_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.EnableExternalImages = true;         
        }

        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            new formPocetna().Show();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
