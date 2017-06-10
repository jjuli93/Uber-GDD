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
using UberFrba.Controllers;
using UberFrba.Modelo;

namespace UberFrba.Abm_Turno
{
    public partial class ABMTurnoForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private TurnoDAO turnoDAO;
        private List<Control> camposObligatorios;

        public ABMTurnoForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToParent();
            formAnterior = _parent;
            objController = ObjetosFormCTRL.Instance;
            turnoDAO = TurnoDAO.Instance;

            camposObligatorios = new List<Control>() { beginDateTimePicker, endDateTimePicker, descripcionTextBox, kmNumericUpDown, precioNumericUpDown };

            this.FormClosing += ABMTurnoForm_FormClosing;
        }

        private void ABMTurnoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            var buscador = new ListadoTurnosForm();

            this.Hide();
            buscador.Show(this);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                MessageBox.Show("Turno creado", "Nuevo Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Por favor ingrese todos los datos obligatorios", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    objController.borrarMensajeDeError(camposObligatorios, errorProvider);
                    return;
                }
                    
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            objController.borrarMensajeDeError(camposObligatorios, errorProvider);
            objController.limpiarControles(this);
        }

        private void cerrarSesionLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }
    }
}
