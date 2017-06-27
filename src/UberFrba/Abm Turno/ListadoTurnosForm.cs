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

namespace UberFrba.Abm_Turno
{
    public partial class ListadoTurnosForm : Form
    {
        ObjetosFormCTRL objController;
        TurnoDAO turnoDAO;
        int turno_index = -1;

        public ListadoTurnosForm()
        {
            InitializeComponent();
            objController = ObjetosFormCTRL.Instance;
            turnoDAO = TurnoDAO.Instance;

            this.FormClosing += ListadoTurnosForm_FormClosing;
        }

        private void ListadoTurnosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void turnosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            objController.habilitarContenidoPanel(turnoSeleccionadoPanel, true);
            turno_index = e.RowIndex;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            limpiar_form();
        }

        private void limpiar_form()
        {
            objController.limpiarControles(this);
            turnosDataGridView.Rows.Clear();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string descripcion_filtro = null;

            if (!string.IsNullOrEmpty(descripcionTextBox.Text))
                descripcion_filtro = descripcionTextBox.Text;

            DataTable resultados = turnoDAO.search_turnos(descripcion_filtro);

            if (resultados != null)
                turnosDataGridView.DataSource = resultados;
            else
                MessageBox.Show("Ha ocurrido un error en el buscador de turnos.", "Buscar Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void verButton_Click(object sender, EventArgs e)
        {
            var detalle = new DetalleTurnoForm(turnoDAO.obtener_turno_from_row(turnosDataGridView.Rows[turno_index]));

            detalle.Show(this);
            this.Hide();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var modificar = new ModificarTurnoForm(turnoDAO.obtener_turno_from_row(turnosDataGridView.Rows[turno_index]));

            modificar.Show(this);
            this.Hide();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de querer eliminar el turno seleccionado", "Baja Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(turnosDataGridView.Rows[turno_index].Cells[0].Value);

                if (turnoDAO.baja_turno(id))
                {
                    MessageBox.Show("Turno eliminado", "Baja Turno", MessageBoxButtons.OK);
                    turnosDataGridView.Rows[turno_index].Cells["turno_habilitado"].Value = 0;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar elminar el turno seleccionado", "Error Baja Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            turno_index = -1;
            turnosDataGridView.ClearSelection();
            objController.habilitarContenidoPanel(turnoSeleccionadoPanel, false);
        }


    }
}
