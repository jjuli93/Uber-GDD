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
using UberFrba.Modelo;

namespace UberFrba.Abm_Cliente
{
    public partial class ListadoClientesForm : Form
    {
        private Form formAnterior;
        private ObjetosFormCTRL objController;
        bool fromABM;
        int index_cliente_selecccionado = -1;

        public ListadoClientesForm(Form _formAnterior, bool _fromABM)
        {
            InitializeComponent();
            this.CenterToScreen();
            verButton.Enabled = false;
            formAnterior = _formAnterior;
            objController = ObjetosFormCTRL.Instance;
            fromABM = _fromABM;

            if (!_fromABM)
            {
                modificarButton.Enabled = false;
                modificarButton.Visible = false;
                eliminarButton.Enabled = false;
                eliminarButton.Visible = false;
                volverButton.Enabled = false;
                volverButton.Visible = false;

                seleccionarButton.Enabled = false;
                seleccionarButton.Visible = true;
                cancelarButton.Enabled = true;
                cancelarButton.Visible = true;
            }
            else
            {
                modificarButton.Enabled = false;
                eliminarButton.Enabled = false;
            }

            this.FormClosing += ListadoClientesForm_FormClosing;
        }

        private void ListadoClientesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void clientesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index_cliente_selecccionado = e.RowIndex;

            verButton.Enabled = true;

            if (fromABM)
            {
                modificarButton.Enabled = true;
                eliminarButton.Enabled = true;
            }
            else
            {
                seleccionarButton.Enabled = true;
                cancelarButton.Enabled = true;
            }
        }

        // ------> Botones desde ABM Cliente
        private void modificarButton_Click(object sender, EventArgs e)
        {
            ModificarClienteForm modificar_form = new ModificarClienteForm(get_selected_client());

            this.Hide();
            modificar_form.Show(this);           
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("¿Está seguro de querer eliminar el cliente seleccionado?", "Eliminar Cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id_cliente = (int)clientesDataGridView.Rows[index_cliente_selecccionado].Cells[0].Value;
                
                if (ClienteDAO.Instance.eliminar_cliente(id_cliente))
                {
                    MessageBox.Show("Cliente eliminado", "Eliminar Cliente", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el cliente", "Error en Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }            
        }
        // <------ end abm cliente

        private void verButton_Click(object sender, EventArgs e)
        {
            DetalleClienteForm detalle_form = new DetalleClienteForm(get_selected_client());

            this.Hide();
            detalle_form.Show(this);
        }

        // ------> Botones desde form exterior
        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            /*
             *  # Registro de Viaje
             *  # Facturacion Clientes
             */
            /*
            var reg = this.Owner as UberFrba.Registro_Viajes.RegistroViajeForm;
            var fact = this.Owner as UberFrba.Facturacion.FacturacionClientesForm;

            if (reg != null)
                reg.seleccionarCliente(get_selected_client());

            if (fact != null)
                fact.seleccionarCliente(get_selected_client());
             * */
            dynamic form = this.Owner;
            form.seleccionarCliente(get_selected_client());
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
        // <------ end form exterior

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private Cliente get_selected_client()
        {
            if (index_cliente_selecccionado == -1)
                return null;

            return ClienteDAO.Instance.obtener_cliente_from_row(clientesDataGridView.Rows[index_cliente_selecccionado]);
        }

        private void ListadoClientesForm_Click(object sender, EventArgs e)
        {
            index_cliente_selecccionado = -1;
            clientesDataGridView.ClearSelection();

            objController.habilitarContenidoPanel(clienteSeleccionadoPanel, false);
        }
        
    }
}
