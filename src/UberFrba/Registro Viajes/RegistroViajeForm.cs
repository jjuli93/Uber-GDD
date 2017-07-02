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
        private Chofer chofer_seleccionado = null;
        private Automovil auto_seleccionado = null;
        private Cliente cliente_seleccionado = null;

        public RegistroViajeForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.formAnterior = _parent;

            objController = ObjetosFormCTRL.Instance;
            TurnoDAO.Instance.set_turnos_CB(turnoComboBox);
            camposObligatorios = new List<Control>() { datosChoferTB, autoTextBox, turnoComboBox, kmNumericUpDown, beginDateTimePicker, endDateTimePicker, datosClienteTB };

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
            if (cumple_campos())
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

        public void seleccionarChofer(Chofer _chofer_seleccionado)
        {
            this.chofer_seleccionado = _chofer_seleccionado;

            if (_chofer_seleccionado != null)
            {
                datosChoferTB.Text = string.Format("{0} {1}", _chofer_seleccionado.nombre, _chofer_seleccionado.apellido);
            }
        }

        public void seleccionarAutomovil(Automovil _auto_seleccionado)
        {
            this.auto_seleccionado = _auto_seleccionado;

            if (_auto_seleccionado != null)
            {
                autoTextBox.Text = string.Format("{0} {1}  -  Patente nro: [{2}]",_auto_seleccionado.marca, _auto_seleccionado.modelo, _auto_seleccionado.patente.ToString());
            }
        }

        public void seleccionarCliente(Cliente _cliente_seleccionado)
        {
            this.cliente_seleccionado = _cliente_seleccionado;

            if (_cliente_seleccionado != null)
            {
                datosClienteTB.Text = string.Format("{0} {1}", _cliente_seleccionado.nombre, _cliente_seleccionado.apellido);
            }
        }

        private bool cumple_campos()
        {
            return objController.cumpleCamposObligatorios(camposObligatorios, errorProvider) 
                && (cliente_seleccionado != null) 
                && (chofer_seleccionado != null) 
                && (auto_seleccionado != null);
        }
    }
}
