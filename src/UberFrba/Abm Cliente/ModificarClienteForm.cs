using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Modelo;
using UberFrba.Controllers;

namespace UberFrba.Abm_Cliente
{
    public partial class ModificarClienteForm : Form
    {
        ObjetosFormCTRL objController;
        ClienteDAO clienteDAO;

        public ModificarClienteForm(Cliente _cliente)
        {
            InitializeComponent();
            objController = ObjetosFormCTRL.Instance;
            clienteDAO = ClienteDAO.Instance;

            if (_cliente != null)
                llenar_datos_form(_cliente);
            else
            {
                if (MessageBox.Show("La aplicación sufrió un error al querer modificar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    this.Owner.Show();
                    this.Dispose();
                }
            }

            this.FormClosing += ModificarClienteForm_FormClosing;
        }

        private void ModificarClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void llenar_datos_form(Cliente cliente)
        {
            nombreTextBox.Text = cliente.nombre;
            apellidoTextBox.Text = cliente.apellido;
            dniTextBox.Text = cliente.dni;
            mailTextBox.Text = cliente.mail;
            telTextBox.Text = cliente.telefono.ToString();
            dirTextBox.Text = cliente.direccion;
            cpTextBox.Text = cliente.codigoPostal;

            objController.cargar_valor_comboBox(dayComboBox, cliente.fecha_nacimiento.Day.ToString());
            objController.cargar_valor_comboBox(monthComboBox, cliente.fecha_nacimiento.Month.ToString());
            objController.cargar_valor_comboBox(yearComboBox, cliente.fecha_nacimiento.Year.ToString());

            habilitarCheckBox.Checked = cliente.habilitado;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            /*
             * clienteDAO hace la magia de actualizar los datos
             */
        }
    }
}
