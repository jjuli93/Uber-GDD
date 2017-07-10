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
                Viaje nuevo = get_new_viaje();

                if (ViajeDAO.Instance.alta_viaje(nuevo))
                {
                    if (MessageBox.Show("Registro exitoso.", "Registro de viaje", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        objController.limpiarControles(this);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el viaje", "Error en Registro de Viaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Viaje get_new_viaje()
        {
            Viaje nuevo = new Viaje(0);

            nuevo.automovil = auto_seleccionado.id;
            nuevo.chofer = chofer_seleccionado.id;
            nuevo.cliente = cliente_seleccionado.id;

            if (turnoComboBox.SelectedIndex >= 0)
            {
                nuevo.turno = (turnoComboBox.SelectedItem as ObjetosFormCTRL.itemComboBox).id_item;
            }
            else
                return null;

            nuevo.km_viaje = (float)kmNumericUpDown.Value;
            nuevo.inicio_date = beginDateTimePicker.Value;
            nuevo.fin_date = endDateTimePicker.Value;

            return nuevo;
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

        public void setChoferSeleccionado(Chofer _chofer_seleccionado)
        {
            if (_chofer_seleccionado == null)
                return;
            
            this.chofer_seleccionado = _chofer_seleccionado;
            datosChoferTB.Text = string.Format("{0} {1}", _chofer_seleccionado.nombre, _chofer_seleccionado.apellido);

            seleccionarAutomovil(chofer_seleccionado.id);
        }

        public void seleccionarAutomovil(int id_chofer)
        {
            this.auto_seleccionado = AutomovilDAO.Instance.get_automovil_chofer(id_chofer);

            if (auto_seleccionado != null)
            {
                List<Turno> turnos = TurnoDAO.Instance.get_turnos_automovil(auto_seleccionado.id);
                auto_seleccionado.turnos = turnos;

                foreach (var item in turnos)
                {
                    turnoComboBox.Items.Add(new ObjetosFormCTRL.itemComboBox(item.descripcion, item.id));
                }

                autoTextBox.Text = string.Format("Patente: [{0}]  |  Licencia nro: [{1}]", auto_seleccionado.patente, auto_seleccionado.licencia.ToString());
            }
            else
                MessageBox.Show("No se pudo encontrar el automovil asignado del chofer", "Registro Viaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
