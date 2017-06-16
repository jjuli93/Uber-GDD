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
            ModificarClienteForm modificar_form = new ModificarClienteForm(null);

            this.Hide();
            modificar_form.Show(this);           
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {

        }
        // <------ end abm cliente

        private void verButton_Click(object sender, EventArgs e)
        {
            DetalleClienteForm detalle_form = new DetalleClienteForm(null);

            this.Hide();
            detalle_form.Show(this);
        }

        // ------> Botones desde form exterior
        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            /*
             *  # Registro de Viaje
             *  # Facturacion Clientes
             * 
             * formAnterior.seleccionarCliente(cliente_seleccionado)
             */
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
        
    }
}
