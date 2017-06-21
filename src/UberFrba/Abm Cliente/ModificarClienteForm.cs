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
        Cliente client_selected;

        public ModificarClienteForm(Cliente _cliente)
        {
            InitializeComponent();
            objController = ObjetosFormCTRL.Instance;
            clienteDAO = ClienteDAO.Instance;

            if (_cliente != null) 
            {
                client_selected = _cliente;
                llenar_datos_form(_cliente);
            }
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
            dniTextBox.Text = cliente.dni.ToString();
            mailTextBox.Text = cliente.mail;
            telTextBox.Text = cliente.telefono.ToString();
            dirTextBox.Text = cliente.direccion;
            cpTextBox.Text = cliente.codigoPostal.ToString();

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
            var campos = new List<Control>() { nombreTextBox, apellidoTextBox, dniTextBox, telTextBox, dirTextBox, cpTextBox, dayComboBox, monthComboBox, yearComboBox };

            if (objController.cumpleCamposObligatorios(campos, errorProvider))
            {
                if (MessageBox.Show("¿Está seguro de querer modificar los datos del cliente?", "Modificar Cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ClienteDAO.Instance.modificar_cliente(client_selected))
                    {
                        MessageBox.Show("Los datos del cliente han sido modificados.", "Modificar Cliente", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar los datos del cliente", "Error en Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
