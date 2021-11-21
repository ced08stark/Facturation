using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturation.BO;

namespace Facturation
{
    static class Program
    {

        
        public static List<Product> CurrentProducts { get; set; }
        public static Client CurrentClient { get; set; }
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            form.Show();
            Application.Run();
        }
    }
}
