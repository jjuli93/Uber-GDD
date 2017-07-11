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
                int id_cliente = Convert.ToInt32(clientesDataGridView.Rows[index_cliente_selecccionado].Cells["ID"].Value);
                
                if (ClienteDAO.Instance.eliminar_cliente(id_cliente))
                {
                    MessageBox.Show("Cliente eliminado", "Eliminar Cliente", MessageBoxButtons.OK);
                    clientesDataGridView.Rows[index_cliente_selecccionado].Cells["Habilitado"].Value = 0;
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el cliente", "Error en Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                index_cliente_selecccionado = -1;
                objController.habilitarContenidoPanel(clienteSeleccionadoPanel, false);
                clientesDataGridView.ClearSelection();
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
            dynamic form = this.Owner;

            if (MessageBox.Show("¿Está seguro de seleccionar al cliente seleccionado?", "Seleccionar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var client = get_selected_client();

                if (client != null)
                { 
                    form.seleccionarCliente(client);
                    this.Owner.Show();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la selección de un cliente.", "Error en cliente seleccionado", MessageBoxButtons.OK);
                }
            }
            else
            {
                index_cliente_selecccionado = -1;
                clientesDataGridView.ClearSelection();
                objController.habilitarContenidoPanel(clienteSeleccionadoPanel, false);
                cancelarButton.Enabled = true;
            }

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

            var nulo = false;

            foreach (DataGridViewCell item in clientesDataGridView.Rows[index_cliente_selecccionado].Cells)
            {
                if (item.Value == null)
                {
                    nulo = true;
                    break;
                }
            }

            if (nulo)
                return null;

            return ClienteDAO.Instance.obtener_cliente_from_row(clientesDataGridView.Rows[index_cliente_selecccionado]);
        }

        private void ListadoClientesForm_Click(object sender, EventArgs e)
        {
            index_cliente_selecccionado = -1;
            clientesDataGridView.ClearSelection();

            objController.habilitarContenidoPanel(clienteSeleccionadoPanel, false);
            cancelarButton.Enabled = true;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            buscar_clientes();
        }

        private void buscar_clientes()
        {
            string nombre_filtro = null;
            string apellido_filtro = null;
            string dni_filtro = null;

            if (!string.IsNullOrEmpty(nameFilterTB.Text))
                nombre_filtro = nameFilterTB.Text;

            if (!string.IsNullOrEmpty(lnameFilterTB.Text))
                apellido_filtro = lnameFilterTB.Text;

            if (!string.IsNullOrEmpty(dniFilterTB.Text))
                dni_filtro = dniFilterTB.Text;


            DataTable resultados = null;

            if (fromABM)
                resultados = ClienteDAO.Instance.get_clientes(nombre_filtro, apellido_filtro, dni_filtro, "NO");
            else
                resultados = ClienteDAO.Instance.get_clientes(nombre_filtro, apellido_filtro, dni_filtro, "SI");

            if (resultados == null)
            {
                MessageBox.Show("Ha ocurrido un error en el buscador", "Error Buscar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resultados.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado clientes con los filtros aplicados", "Buscar Clientes", MessageBoxButtons.OK);
                return;
            }

            clientesDataGridView.DataSource = resultados;
        }

        private void cleanParamsButton_Click(object sender, EventArgs e)
        {
            nameFilterTB.Text = "";
            lnameFilterTB.Text = "";
            dniFilterTB.Text = "";
        }

        private void cleanTableButton_Click(object sender, EventArgs e)
        {
            limpiar_tabla();
        }

        private void limpiar_tabla()
        {
            clientesDataGridView.ClearSelection();
            index_cliente_selecccionado = -1;
            clientesDataGridView.DataSource = null;

            objController.habilitarContenidoPanel(clienteSeleccionadoPanel, false);
            cancelarButton.Enabled = true;
        }

        private void clientesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                objController.habilitarContenidoPanel(this.clienteSeleccionadoPanel, false);
                cancelarButton.Enabled = true;
                return;
            }

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

        public void refresh_table()
        {
            limpiar_tabla();
            buscar_clientes();
            index_cliente_selecccionado = -1;
        }

        private void dniFilterTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }
        
    }
}
