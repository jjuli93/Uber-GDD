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

            // y setear en algun lado la row seleccionada para obtener, a traves de 
            // turnoDAO el turno correspondiente
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            objController.limpiarControles(this);
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
            //busca a traves de turnoDAO
        }

        private void verButton_Click(object sender, EventArgs e)
        {
            var detalle = new DetalleTurnoForm(null);

            detalle.Show(this);
            this.Hide();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var modificar = new ModificarTurnoForm(null);

            modificar.Show(this);
            this.Hide();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
