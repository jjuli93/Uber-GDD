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

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomovilesForm : Form
    {
        Form formAnterior;
        ObjetosFormCTRL objController;
        int AutomovilSeleccionado = -1;
        AutomovilDAO autoDAO;

        public ListadoAutomovilesForm(Form _formAnterior)
        {
            InitializeComponent();
            CenterToScreen();
            formAnterior = _formAnterior;
            objController = ObjetosFormCTRL.Instance;
            autoDAO = AutomovilDAO.Instance;
            objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
            this.FormClosing += ListadoAutomovilesForm_FormClosing;

            marcaComboBox.SelectedIndex = -1;
            modeloComboBox.SelectedIndex = -1;
            objController.inicializar_Marcas(marcaComboBox);
        }

        private void ListadoAutomovilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void verButton_Click(object sender, EventArgs e)
        {
            var row = autosDataGridView.Rows[AutomovilSeleccionado];

            if (row.Cells[0].Value == null) 
            {
                MessageBox.Show("Seleccione una fila válida de la tabla", "Error", MessageBoxButtons.OK);
                objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
                AutomovilSeleccionado = -1;
                return;
            }

            int id = Convert.ToInt32(row.Cells["auto_id"].Value);

            var auto = autoDAO.obtener_auto_from_row(id);

            var detalle_form = new DetalleAutomovilForm(auto, this);

            objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
            AutomovilSeleccionado = -1;
            this.Hide();
            detalle_form.Show(this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var row = autosDataGridView.Rows[AutomovilSeleccionado];

            if (row.Cells[0].Value == null)
            {
                MessageBox.Show("Seleccione una fila válida de la tabla", "Error", MessageBoxButtons.OK);
                objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
                AutomovilSeleccionado = -1;
                return;
            }

            int id = Convert.ToInt32(row.Cells["auto_id"].Value);

            var auto = autoDAO.obtener_auto_from_row(id);

            var modificar_form = new ModificarAutomovilForm(auto, this);

            objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
            AutomovilSeleccionado = -1;
            this.Hide();
            modificar_form.Show(this);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            buscar_autos();
        }

        private void buscar_autos()
        {
            ObjetosFormCTRL.itemComboBox marca = null;
            ObjetosFormCTRL.itemComboBox modelo = null;
            string patente = null;
            string chofer = null;

            if (marcaComboBox.SelectedIndex != -1)
                marca = (ObjetosFormCTRL.itemComboBox)marcaComboBox.SelectedItem;

            if (modeloComboBox.SelectedIndex != -1)
                modelo = (ObjetosFormCTRL.itemComboBox)modeloComboBox.SelectedItem;

            if (!string.IsNullOrEmpty(patenteTextBox.Text))
                patente = patenteTextBox.Text;

            if (!string.IsNullOrEmpty(choferTextBox.Text))
                chofer = choferTextBox.Text;

            var autos = autoDAO.obtenerAutomoviles(marca, modelo, patente, chofer);

            if (autos.Rows.Count == 0)
                MessageBox.Show("No se han encontrado automóviles", "Buscador Automóviles");

            this.autosDataGridView.DataSource = autos;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            objController.limpiarControles(this);
            objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
            AutomovilSeleccionado = -1;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            //formAnterior.Show();
            this.Owner.Show();
            this.Dispose();
        }

        private void marcaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var marca_index = (ObjetosFormCTRL.itemComboBox)marcaComboBox.SelectedItem;

            modeloComboBox.Items.Clear();
            autoDAO.setModelos(modeloComboBox, marca_index.id_item);
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            var row = autosDataGridView.Rows[AutomovilSeleccionado];

            if (row.Cells[0].Value == null)
            {
                MessageBox.Show("Seleccione una fila válida de la tabla", "Error", MessageBoxButtons.OK);
                objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
                AutomovilSeleccionado = -1;
                return;
            }

            if (MessageBox.Show("¿Está seguro de querer eliminar el automovil seleccionado?", "Eliminar Automovil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (autoDAO.baja_automovil(Convert.ToInt32(row.Cells[0].Value)))
                {
                    MessageBox.Show("Se ha eliminado el automovil selccionado", "Automovil eliminado", MessageBoxButtons.OK);
                    row.Cells["auto_habilitado"].Value = 0;

                    objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
                    AutomovilSeleccionado = -1;
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el automovil selccionado", "Error en Eliminar Automovil", MessageBoxButtons.OK);
                }
            }
        }

        private void autosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AutomovilSeleccionado = e.RowIndex;
            int id_auto = -1;

            try
            {
                id_auto = Convert.ToInt32(autosDataGridView.Rows[e.RowIndex].Cells["auto_id"].Value);

                if (id_auto > 0)
                    objController.habilitarContenidoPanel(autoSelectedPanelBtns, true);
            }
            catch (ArgumentOutOfRangeException)
            {
                
                //throw;
            }

        }

        public void refresh_table()
        {
            buscar_autos();   
            AutomovilSeleccionado = -1;
            autosDataGridView.ClearSelection();
            objController.habilitarContenidoPanel(autoSelectedPanelBtns, false);
        }

        private void choferTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

    }
}
