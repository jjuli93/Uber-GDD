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
using UberFrba.Abm_Cliente;
using UberFrba.Modelo;
using UberFrba.Controllers;

namespace UberFrba.Facturacion
{
    public partial class FacturacionClientesForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private int id_cliente;
        private ClienteDAO clienteDAO;
        private List<Control> camposObligatorios;

        public FacturacionClientesForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            CenterToScreen();
            formAnterior = _parent;

            id_cliente = -1;
            objController = ObjetosFormCTRL.Instance;
            clienteDAO = ClienteDAO.Instance;
            camposObligatorios = new List<Control>() { beginDateTimePicker, endDateTimePicker, datosClienteTB };

            this.FormClosing += FacturacionClientesForm_FormClosing;
        }

        private void FacturacionClientesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void buscarClienteBtn_Click(object sender, EventArgs e)
        {
            var buscador_cliente = new ListadoClientesForm(this, false);

            buscador_cliente.Show(this);
            this.Hide();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        public void seleccionarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                this.id_cliente = cliente.id;
                datosClienteTB.Text = "[" + "]  " + cliente.nombre + " " + cliente.apellido;
            }
            else
            {
                if (MessageBox.Show("Error en el cliente seleccionado, por favor vuelva a buscar uno.", "Error en el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    return;
            }
            
        }

        private void facturarButton_Click(object sender, EventArgs e)
        {
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider) && (id_cliente != -1))
            {
                //fumo porro y meto caño (?
                // importeTextBox = clienteDAO.realizarFacturacion(id_cliente);
                // viajesDataGridView <- clienteDAO.obtenerViajes(id_cliente);
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

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }
    }
}
