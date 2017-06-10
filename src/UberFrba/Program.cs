using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Login;

using UberFrba.Abm_Cliente;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Automovil;

namespace UberFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //Application.Run(new ABMClienteForm());
            //Application.Run(new ABMChoferForm(null));
            //Application.Run(new ABMRolForm(null));
            //Application.Run(new ABMAutomovilForm(null));
        }
    }
}
