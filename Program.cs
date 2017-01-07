using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
//            MessageBox.Show("Akár ide is rakhattam volna a törlést, de nem igy tettem..."); - Eddig nem jöttem rá, hogy lehet bezáráskor kódot futtatni, pedig ilyen egyszerű...
        }
    }
}
