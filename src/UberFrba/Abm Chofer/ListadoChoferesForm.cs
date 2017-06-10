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
            ABMAutomovilForm abmAuto = this.Owner as ABMAutomovilForm;

            Chofer driver = new Chofer(-1/*sale del datagridview*/);
            driver.nombre = "asd";
            driver.apellido = "zxc";

            // Los datos que se muestren en el dialogo se sacaran de lo seleccionado de la row
            // recien dentro del if creo el chofer
            if (MessageBox.Show("Está seguro de seleccionar al chofer: <" + driver.nombre + " " + driver.apellido + ">?", "Seleccionar Chofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                abmAuto.setChoferSeleccionado(driver);
                abmAuto.Show();
                this.Dispose();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void verButtonSelected_Click(object sender, EventArgs e)
        {
            DetalleChoferForm detalle_form = new DetalleChoferForm(null);
            this.Hide();
            detalle_form.Show(this);
        }
        //-->End metodos abm exterior

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            objController.limpiarControles(this);
        }

        private void choferesDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            habilitar_botones(true);
        }

        private void habilitar_botones(bool valor)
        {
            var botones = new List<Button>() { seleccionarButton, verButtonSelected, eliminarButton, verButton, modificarButton};

            objController.habilitar_botones(botones, valor);
        }

        //BOTONES DESDE LA ABM DE CHOFERES
        private void verButton_Click(object sender, EventArgs e)
        {
            DetalleChoferForm detalle_form = new DetalleChoferForm(null);
            this.Hide();
            detalle_form.Show(this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            ModificarChoferForm modificar_form = new ModificarChoferForm(null);
            this.Hide();
            modificar_form.Show(this);
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            /*
             * llama al metodo "eliminar_chofer" de la instancia de ChoferDAO
             */
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
        //<-- END botones abm chofer


        private void buscarButton_Click(object sender, EventArgs e)
        {
            /*
             * llama al metodo "buscar_chofer" de la instancia de ChoferDAO
             */
        }
    }
}
