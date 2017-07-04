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

namespace UberFrba.Abm_Chofer
{
    public partial class ABMChoferForm : Form
    {
        private ObjetosFormCTRL objController;
        private List<Control> campos_obligatorios;
        private menuFuncsRolUserForm formAnterior;

        public ABMChoferForm(menuFuncsRolUserForm _formMenu)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _formMenu;
            objController = ObjetosFormCTRL.Instance;

            dniTextBox.MaxLength = 8;
            telefonoTextBox.MaxLength = 12;

            campos_obligatorios = new List<Control>() { nombreTextBox, apeliidoTextBox, dniTextBox, direccionTextBox, mailTextBox, telefonoTextBox, fnDateTimePicker };

            this.FormClosing += ABMChoferForm_FormClosing;
        }

        private void ABMChoferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            direccionTextBox.Text = "calle, nro piso, depto. y localidad";
            direccionTextBox.ForeColor = Color.LightGray;
        }

        private void limpiar_form()
        {
            objController.limpiarControles(this);
            objController.borrarMensajeDeError(campos_obligatorios, errorProvider);
        }

        private void ABMChoferForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dirLabel;
            direccionTextBox.GotFocus += new EventHandler(objController.textGotFocus_Direccion);
            direccionTextBox.LostFocus += new EventHandler(objController.textLostFocus_Direccion);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            this.Hide();
            ListadoChoferesForm buscador = new ListadoChoferesForm(this, true);
            buscador.Show(this);
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            objController.borrarMensajeDeError(campos_obligatorios, errorProvider);

            if (!objController.cumpleCamposObligatorios(campos_obligatorios, errorProvider) || objController.direccion_vacia(direccionTextBox, errorProvider))
            {
                MessageBox.Show("Por favor ingrese todos los datos obligatorios");
                return;
            }
            else
            {
                var nuevo = get_nuevo_chofer();

                if (nuevo == null)
                    MessageBox.Show("Verifique los datos ingresados.", "Datos incorrectos", MessageBoxButtons.OK);
                else
                {
                    if (ChoferDAO.Instance.crear_chofer(nuevo))
                    {
                        MessageBox.Show("Cliente creado");
                        limpiar_form();
                    }
                    else
                    {
                        MessageBox.Show("No se podido crear el chofer.", "Error en Alta Chofer", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            this.Owner.Show();
            this.Dispose();
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

        private Chofer get_nuevo_chofer()
        {            
            UInt32 dni = 11111111;
            UInt32 telefono = 1000001;

            if (!UInt32.TryParse(dniTextBox.Text, out dni))
            {
                errorProvider.SetError(dniTextBox, "Formato incorrecto, debe ser solo números.");
                return null;
            }


            if (!UInt32.TryParse(telefonoTextBox.Text, out telefono))
            {
                errorProvider.SetError(telefonoTextBox, "Formato incorrecto, debe ser solo números.");
                return null;
            }

            var nuevo = new Chofer(0);

            nuevo.set_datos_principales(nombreTextBox.Text, apeliidoTextBox.Text, dni, fnDateTimePicker.Value);
            nuevo.set_datos_secundarios(mailTextBox.Text, telefono, direccionTextBox.Text);

            return nuevo;
        }

        private void dniTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }
    }
}
