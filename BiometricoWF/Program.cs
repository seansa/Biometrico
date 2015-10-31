using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiometricoWF
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

            var _login = new Presentacion.Seguridad.LogIn();

            _login.ShowDialog();

            if (_login.PuedeIngresarAlSistema)
                Application.Run(new Principal());
            else
                Application.Exit();
        }
    }
}
