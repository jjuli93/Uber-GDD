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
using UberFrba.Login;
using UberFrba.Modelo;

namespace UberFrba.Abm_Cliente
{
    public partial class ABMClienteForm : Form
    {
        private ObjetosFormCTRL objController;
        private List<Control> campos_obligatorios;
        private menuFuncsRolUserForm formAnterior;

        public ABMClienteForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            objController = ObjetosFormCTRL.Instance;
            campos_obligatorios = new List<Control>() 
            { nombreTextBox, apellidoTextBox, dniTextBox, telTextBox, dirTextBox, cpTextBox, fnDateTimePicker };
            formAnterior = _parent;

            dniTextBox.MaxLength = 8;
            telTextBox.MaxLength = 12;

            this.FormClosing += ABMClienteForm_FormClosing;
        }

        private void ABMClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            objController.borrarMensajeDeError(campos_obligatorios, errorProvider1);

            if (!objController.cumpleCamposObligatorios(campos_obligatorios, errorProvider1) || objController.direccion_vacia(dirTextBox, errorProvider1))
            {
                if (MessageBox.Show("Por favor ingrese todos los datos obligatorios", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                    return;
            }
            else
            {
                if (ClienteDAO.Instance.crear_cliente(get_nuevo_cliente()))
                {
                    MessageBox.Show("Cliente creado.", "Alta cliente", MessageBoxButtons.OK);
                    limpiar_form();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el cliente.", "Error en Alta Cliente", MessageBoxButtons.OK);
                }
                
            } 
        }

        private void limpiar_form()
        {
            objController.limpiarControles(this);
            dirTextBox.Text = "calle, nro piso, depto. y localidad";
            dirTextBox.ForeColor = Color.LightGray;
            objController.borrarMensajeDeError(campos_obligatorios, errorProvider1);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
        }

        private void ABMClienteForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dirLabel;
            dirTextBox.GotFocus += new EventHandler(objController.textGotFocus_Direccion);
            dirTextBox.LostFocus += new EventHandler(objController.textLostFocus_Direccion);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            this.Hide();
            var listadoForm = new ListadoClientesForm(this, true);
            listadoForm.Show(this);
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

        private Cliente get_nuevo_cliente()
        {
            UInt32 dni = 11111111;
            UInt32 telefono = 1000001;

            if (!UInt32.TryParse(dniTextBox.Text, out dni))
            {
                errorProvider1.SetError(dniTextBox, "Formato incorrecto, debe ser solo números.");
                return null;
            }


            if (!UInt32.TryParse(telTextBox.Text, out telefono))
            {
                errorProvider1.SetError(telTextBox, "Formato incorrecto, debe ser solo números.");
                return null;
            }

            var nuevo = new Cliente(0);

            nuevo.set_datos_principales(nombreTextBox.Text, apellidoTextBox.Text, dni, fnDateTimePicker.Value);
            nuevo.set_datos_secundarios(mailTextBox.Text, telefono, dirTextBox.Text);
            nuevo.codigoPostal = Convert.ToInt32(cpTextBox.Text);

            return nuevo;
        }

        private void dniTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

        private void telTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

        private void cpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }
        
    }
}
