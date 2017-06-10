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
            objController.setCBFechaNac(dayComboBox, monthComboBox, yearComboBox);
            campos_obligatorios = new List<Control>() 
            { nombreTextBox, apellidoTextBox, dniTextBox, telTextBox, dirTextBox, cpTextBox, dayComboBox, monthComboBox, yearComboBox };
            formAnterior = _parent;

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
                /*
                 * Llama al metodo "crear_cliente" de ClienteDAO
                 */
                MessageBox.Show("Cliente creado");
                limpiar_form();
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
        
    }
}
