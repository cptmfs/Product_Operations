using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new AdminForm());
=======
            Application.Run(new YonlendirmeForm());
>>>>>>> 3c7b0965b4a38b6993804db1f3bbb29ec8fbc25d
        }
    }
}
