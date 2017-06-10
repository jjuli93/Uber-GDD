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
    public partial class ListadoRolesForm : Form
    {
        private ABMRolForm formAnterior;
        private ObjetosFormCTRL objController;
        private Rol rolSeleccionado;

        public ListadoRolesForm(ABMRolForm _formAnterior)
        {
            InitializeComponent();
            this.CenterToScreen();
            objController = ObjetosFormCTRL.Instance;
            formAnterior = _formAnterior;

            this.FormClosing += ListadoRolesForm_FormClosing;
        }

        private void ListadoRolesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void atrasButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void verButton_Click(object sender, EventArgs e)
        {
            var detalle_form = new DetalleRolForm();

            this.Hide();
            detalle_form.Show(this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var modificar_form = new ModificarRolForm(null);

            this.Hide();
            modificar_form.Show(this);
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            //rolDAO.eliminarRol(rolSeleccionado);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            objController.habilitarContenidoPanel(this.rolSeleccionadoPanel, true);
            //seteo el rol seleccionado
            //rolSeleccionado = rolDAO.obtenerRol(rolesDataGridView.SelectedRows);
        }
    }
}
