using Blackjack.Vistas;
using DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    static class Program
    {
        public static DBAccess.DBAccess da;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Pg"].ConnectionString;
            Program.da = new PgAccess(connectionString);
            Application.Run(new Principal());
        }
    }
}
