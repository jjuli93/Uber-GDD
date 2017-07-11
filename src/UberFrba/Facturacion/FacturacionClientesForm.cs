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
        private ClienteDAO clienteDAO;
        private List<Control> camposObligatorios;
        private Cliente cliente_seleccionado = null;

        public FacturacionClientesForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            CenterToScreen();
            formAnterior = _parent;

            objController = ObjetosFormCTRL.Instance;
            clienteDAO = ClienteDAO.Instance;

            beginDateTimePicker.Value = Conexion.Instance.getFecha();
            endDateTimePicker.Value = Conexion.Instance.getFecha();

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

        private void facturarButton_Click(object sender, EventArgs e)
        {
            limpiar_form();

            if (cumple_campos())
            {
                var id_factura = clienteDAO.realizarFacturacion(cliente_seleccionado.id, beginDateTimePicker.Value, endDateTimePicker.Value);

                if (id_factura < 0)
                {
                    MessageBox.Show("Ha ocurrido un error al intentar facturar los viajes realizados por el cliente", "Error en Facturación Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (id_factura == 0)
                        MessageBox.Show("No se ha podido facturar al cliente", "Facturación Clientes", MessageBoxButtons.OK);
                    else
                    {
                        set_importe(id_factura);
                        set_viajes(id_factura);
                    }
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

        private void set_viajes(int id_factura)
        {
            DataTable viajes = clienteDAO.obtenerViajes(id_factura);

            if (viajes.Rows.Count <= 0)
                MessageBox.Show("No se han encontrado viajes realizados por el cliente.", "Facturación Clientes", MessageBoxButtons.OK);

            viajesDataGridView.DataSource = viajes;
        }

        private void set_importe(int id_factura)
        {
            double importe = clienteDAO.obtener_importe(id_factura);

            if (importe < 0)
            {
                MessageBox.Show("Ha ocurrido un error al calcular el importe de la facturación", "Facturación Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            importeTextBox.Text = "$ " + importe.ToString();
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

        public void seleccionarCliente(Cliente _cliente_seleccionado)
        {
            this.cliente_seleccionado = _cliente_seleccionado;

            if (_cliente_seleccionado != null)
            {
                objController.borrarMensajeDeError(camposObligatorios, errorProvider);
                datosClienteTB.Text = string.Format("{0} {1}", _cliente_seleccionado.nombre, _cliente_seleccionado.apellido);
            }
            else
            {
                errorProvider.SetError(datosClienteTB, "Error en el cliente seleccionado");
            }
        }

        private bool cumple_campos()
        {
            return objController.cumpleCamposObligatorios(camposObligatorios, errorProvider)
                && (cliente_seleccionado != null);
        }

        private void limpiar_form()
        {
            importeTextBox.Text = string.Empty;
            viajesDataGridView.Rows.Clear();
            viajesDataGridView.DataSource = null;
        }

    }
}
