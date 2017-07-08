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
        private int index_rol_seleccionado = -1;

        public ListadoRolesForm(ABMRolForm _formAnterior)
        {
            InitializeComponent();
            this.CenterToScreen();
            objController = ObjetosFormCTRL.Instance;
            formAnterior = _formAnterior;
            rolesDataGridView.DataSource = RolDAO.Instance.get_roles();

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
            var detalle_form = new DetalleRolForm(RolDAO.Instance.obtenerRol(rolesDataGridView.Rows[index_rol_seleccionado]));

            this.Hide();
            detalle_form.Show(this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var modificar_form = new ModificarRolForm(RolDAO.Instance.obtenerRol(rolesDataGridView.Rows[index_rol_seleccionado]));

            this.Hide();
            modificar_form.Show(this);
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            var id_rol = Convert.ToInt32(rolesDataGridView.Rows[index_rol_seleccionado].Cells[0].Value);
            var nombre_rol = rolesDataGridView.Rows[index_rol_seleccionado].Cells[1].Value.ToString();

            if (MessageBox.Show(string.Format("¿Está seguro de querer eliminar el rol {0}?", nombre_rol), "Eliminar Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (RolDAO.Instance.eliminar_rol(id_rol))
                {
                    MessageBox.Show(string.Format("Se ha eliminado el rol {0}", nombre_rol), "Rol eliminado", MessageBoxButtons.OK);
                    this.reloadTable();
                }
                else
                {
                    MessageBox.Show(string.Format("No se ha podido eliminar el rol {0}", nombre_rol), "Error en Eliminar Rol", MessageBoxButtons.OK);
                }
            }
        }

        private void ListadoRolesForm_Click(object sender, EventArgs e)
        {
            objController.habilitarContenidoPanel(this.rolSeleccionadoPanel, false);
            
            index_rol_seleccionado = -1;
        }

        public void reloadTable()
        {
            this.rolesDataGridView.Refresh();
            this.rolesDataGridView.DataSource = RolDAO.Instance.get_roles();
            rolesDataGridView.ClearSelection();
            index_rol_seleccionado = -1;
            objController.habilitarContenidoPanel(rolSeleccionadoPanel, false);
        }

        private void rolesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (rolesDataGridView.Rows[e.RowIndex].Cells[0] != null)
                {
                    objController.habilitarContenidoPanel(this.rolSeleccionadoPanel, true);

                    index_rol_seleccionado = e.RowIndex;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //throw;
            }
        }
    }
}
