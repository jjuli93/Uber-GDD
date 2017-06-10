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
using UberFrba.Modelo;
using UberFrba.Controllers;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;

namespace UberFrba.Registro_Viajes
{
    public partial class RegistroViajeForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private List<Control> camposObligatorios;

        public RegistroViajeForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.formAnterior = _parent;

            objController = ObjetosFormCTRL.Instance;
            objController.setCBTurno(turnoComboBox);
            camposObligatorios = new List<Control>() { datosChoferTB, autosListBox, turnoComboBox, kmNumericUpDown, beginDateTimePicker, endDateTimePicker, datosClienteTB };

            this.FormClosing += RegistroViajeForm_FormClosing;
        }

        private void RegistroViajeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void buscarChoferBtn_Click(object sender, EventArgs e)
        {
            var buscador = new ListadoChoferesForm(this, false);

            buscador.Show(this);
            this.Hide();
        }

        private void buscarClienteBtn_Click(object sender, EventArgs e)
        {
            var buscador = new ListadoClientesForm(this, false);

            buscador.Show(this);
            this.Hide();
        }

        private void registrarButton_Click(object sender, EventArgs e)
        {
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                //magia.....
                if (MessageBox.Show("Registro exitoso.", "Registro de viaje", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    objController.limpiarControles(this);
                    return;
                }
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

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }
    }
}
