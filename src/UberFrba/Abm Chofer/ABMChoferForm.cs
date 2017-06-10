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
            objController.setCBFechaNac(dayComboBox, monthComboBox, yearComboBox);

            campos_obligatorios = new List<Control>() { nombreTextBox, apeliidoTextBox, dniTextBox, direccionTextBox, mailTextBox, telefonoTextBox, dayComboBox, monthComboBox, yearComboBox };

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
                MessageBox.Show("Cliente creado");
                limpiar_form();
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
    }
}
