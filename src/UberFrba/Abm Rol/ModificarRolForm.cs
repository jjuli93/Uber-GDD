using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Controllers;
using UberFrba.Modelo;

namespace UberFrba.Abm_Rol
{
    public partial class ModificarRolForm : Form
    {
        ObjetosFormCTRL objController;
        RolDAO rolDAO;
        Rol rolSeleccionado;

        public ModificarRolForm(Rol _rol)
        {
            InitializeComponent();
            rolSeleccionado = _rol;
            objController = ObjetosFormCTRL.Instance;
            rolDAO = RolDAO.Instance;
            this.FormClosing += ModificarRolForm_FormClosing;
        }

        private void ModificarRolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
    }
}
