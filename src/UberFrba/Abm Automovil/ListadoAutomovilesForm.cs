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
        }

        private void ListadoAutomovilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void autosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             * con la instancia de AutomovilDAO, llama su metodo obtener_automovil
             * el metodo deberia recibir el id de la row seleccionada
             * y llama el SP de la BD para obtener el automovil correspondiente
             */

            objController.habilitarContenidoPanel(autoSelectedPanelBtns, true);

            //DESPUES VUELA
            AutomovilSeleccionado = 1;
        }

        //DESPUES VUELA
        private Automovil crear_Auto_test()
        {
            Automovil auto = new Automovil(1, "TKB 999");
            auto.set_Marca_from_String("Chevrolet");
            auto.modelo = "Camaro 2017";
            auto.turno = "Noche";
            auto.chofer_id = 123;
            auto.habilitado = true;

            return auto;
        }

        private void verButton_Click(object sender, EventArgs e)
        {
            var detalle_form = new DetalleAutomovilForm(this.crear_Auto_test(), this);

            this.Hide();
            detalle_form.Show(this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var modificar_form = new ModificarAutomovilForm(this.crear_Auto_test(), this);

            this.Hide();
            modificar_form.Show(this);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.autosDataGridView.DataSource = autoDAO.obtenerAutomoviles(this.obtener_filtros_asList());
        }

        private List<string> obtener_filtros_asList()
        {
            List<string> filtros = new List<string>();

            if (marcaComboBox.SelectedIndex != -1)
                filtros.Add(marcaComboBox.SelectedItem.ToString());

            if (!string.IsNullOrEmpty(patenteTextBox.Text))
                filtros.Add(patenteTextBox.Text);

            if (!string.IsNullOrEmpty(modeloTextBox.Text))
                filtros.Add(modeloTextBox.Text);

            if (!string.IsNullOrEmpty(choferTextBox.Text))
                filtros.Add(choferTextBox.Text);

            return filtros;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            objController.limpiarControles(this);
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            //formAnterior.Show();
            this.Owner.Show();
            this.Dispose();
        }

    }
}
