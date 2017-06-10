using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Login;

namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadisticoForm : Form
    {
        private menuFuncsRolUserForm formAnterior;

        public ListadoEstadisticoForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _parent;
        }
    }
}
