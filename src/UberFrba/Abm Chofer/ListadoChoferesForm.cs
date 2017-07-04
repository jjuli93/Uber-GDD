using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Modelo;
using UberFrba.Controllers;

namespace UberFrba.Abm_Chofer
{
    public partial class ListadoChoferesForm : Form
    {
        private Form formAnterior;
        private ObjetosFormCTRL objController;
        private int chofer_index = -1;

        public ListadoChoferesForm(Form _formAnterior, bool _fromABM)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _formAnterior;
            objController = ObjetosFormCTRL.Instance;
            this.FormClosing += ListadoChoferesForm_FormClosing;

            if (!_fromABM)
            {
                itemSelectedPanel.Visible = false;
                itemSelectedPanel.Enabled = false;
                choferSelectedPanel.Visible = true;
                choferSelectedPanel.Enabled = true;
                volverButton.Visible = false;
            }
        }

        private void ListadoChoferesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        //Metodos de los botones de aparecen cuando se busca un chofer desde una abm exterior
        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            dynamic abm = this.Owner;

            if (MessageBox.Show("¿Está seguro de seleccionar al chofer seleccionado?", "Seleccionar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var driver = ChoferDAO.Instance.obtener_cliente_from_row(choferesDataGridView.Rows[chofer_index]);

                if (driver != null)
                {
                    abm.setChoferSeleccionado(driver);
                    this.Owner.Show();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la selección de un chofer.", "Error en chofer seleccionado", MessageBoxButtons.OK);
                }
            }
            else
            {
                chofer_index = -1;
                choferesDataGridView.ClearSelection();
                habilitar_botones(false);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void verButtonSelected_Click(object sender, EventArgs e)
        {
            DetalleChoferForm detalle_form = new DetalleChoferForm(ChoferDAO.Instance.obtener_cliente_from_row(choferesDataGridView.Rows[chofer_index]));
            this.Hide();
            detalle_form.Show(this);
        }
        //-->End metodos abm exterior

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            objController.limpiarControles(this);
        }

        private void habilitar_botones(bool valor)
        {
            var botones = new List<Button>() { seleccionarButton, verButtonSelected, eliminarButton, verButton, modificarButton};

            objController.habilitar_botones(botones, valor);
        }

        //BOTONES DESDE LA ABM DE CHOFERES
        private void verButton_Click(object sender, EventArgs e)
        {
            DetalleChoferForm detalle_form = new DetalleChoferForm(ChoferDAO.Instance.obtener_cliente_from_row(choferesDataGridView.Rows[chofer_index]));
            this.Hide();
            detalle_form.Show(this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            ModificarChoferForm modificar_form = new ModificarChoferForm(ChoferDAO.Instance.obtener_cliente_from_row(choferesDataGridView.Rows[chofer_index]));
            this.Hide();
            modificar_form.Show(this);
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de querer eliminar el chofer seleccionado", "Baja Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(choferesDataGridView.Rows[chofer_index].Cells[0].Value);

                if (ChoferDAO.Instance.eliminar_chofer(id))
                {
                    MessageBox.Show("Chofer eliminado", "Baja Chofer", MessageBoxButtons.OK);
                    choferesDataGridView.Rows[chofer_index].Cells["chofer_habilitado"].Value = 0;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar elminar el chofer seleccionado", "Error Baja Chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            chofer_index = -1;
            choferesDataGridView.ClearSelection();
            habilitar_botones(false);
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
        //<-- END botones abm chofer


        private void buscarButton_Click(object sender, EventArgs e)
        {
            string nombre_filtro = null;
            string apellido_filtro = null;
            string dni_filtro = null;

            if (!string.IsNullOrEmpty(nombreTextBox.Text))
                nombre_filtro = nombreTextBox.Text;

            if (!string.IsNullOrEmpty(apellidoTextBox.Text))
                apellido_filtro = apellidoTextBox.Text;

            if (!string.IsNullOrEmpty(dniTextBox.Text))
                dni_filtro = dniTextBox.Text;

            DataTable resultados = ChoferDAO.Instance.get_choferes(nombre_filtro, apellido_filtro, dni_filtro);

            if (resultados != null)
                choferesDataGridView.DataSource = resultados;
            else
                MessageBox.Show("Ha ocurrido un error en la busqueda de choferes", "Buscador de choferes", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void choferesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (choferesDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                habilitar_botones(true);
                chofer_index = e.RowIndex;
            }
        }

        
    }
}
