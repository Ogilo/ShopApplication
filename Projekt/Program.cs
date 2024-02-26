using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Projekt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //postavljanje mutexa da u isto vrijeme nemože biti otvoreno više istih programa
            bool ugasen;

            var objMutex = new Mutex(true, "Projekt", out ugasen);

            if (!ugasen)
            {
                MessageBox.Show("Projekt je već pokrenut");
                System.Windows.Forms.Application.Exit();
            }else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormPrijava());
            }
            
        }
    }
}
