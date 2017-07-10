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
using UberFrba.Controllers;
using UberFrba.Abm_Chofer;
using UberFrba.Modelo;

namespace UberFrba.Abm_Automovil
{
    public partial class ABMAutomovilForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private List<Control> camposObligatorios;
        public Chofer choferSeleccionado;
        ObjetosFormCTRL.itemComboBox marca_seleccionada = null;
        ObjetosFormCTRL.itemComboBox modelo_seleccionado = null;
        List<Turno> turnos_seleccionados = null;

        public ABMAutomovilForm(menuFuncsRolUserForm _menu)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _menu;
            objController = ObjetosFormCTRL.Instance;
            objController.inicializar_Marcas(this.marcaComboBox);
            camposObligatorios = new List<Control>() { marcaComboBox, modeloComboBox, patenteTextBox, nombreChoferTB, turnosCheckedListBox, licenciaTextBox, rodadoTextBox };
            turnos_seleccionados = new List<Turno>();
            this.setTurnos();

            patenteTextBox.MaxLength = 6;
            licenciaTextBox.MaxLength = 20;

            this.FormClosing += ABMAutomovilForm_FormClosing;
        }

        private void setTurnos()
        {
            List<ObjetosFormCTRL.itemListBox> turnos = TurnoDAO.Instance.get_turnos_asList();

            foreach (var item in turnos)
            {
                turnosCheckedListBox.Items.Add(item);
            }
        }

        private void ABMAutomovilForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void limpiar_form()
        {
            objController.limpiarControles(this);
            objController.borrarMensajeDeError(this.camposObligatorios, errorProvider);
        }

        private void buscarChoferButton_Click(object sender, EventArgs e)
        {
            var buscadorChofer = new ListadoChoferesForm(this, false);
            this.Hide();
            buscadorChofer.ShowDialog(this);
        }

        public void setChoferSeleccionado(Chofer _chofer)
        {
            if (_chofer != null)
            {
                choferSeleccionado = _chofer;
                nombreChoferTB.Text = choferSeleccionado.nombre + " " + choferSeleccionado.apellido;
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                if (AutomovilDAO.Instance.alta_automovil(get_nuevo_automovil()))
                {
                    objController.borrarMensajeDeError(camposObligatorios, errorProvider);
                    this.limpiar_form();
                    MessageBox.Show("Automovil creado");
                }
            }
        }

        private Automovil get_nuevo_automovil()
        {
            Automovil auto = new Automovil(0, patenteTextBox.Text);

            auto.chofer_id = choferSeleccionado.id;
            auto.idmarca = marca_seleccionada.id_item;
            auto.idmodelo = modelo_seleccionado.id_item;
            auto.licencia = Convert.ToInt32(licenciaTextBox.Text);
            auto.rodado = rodadoTextBox.Text;

            set_turnos_nuevo(auto);

            return auto;
        }

        private void set_turnos_nuevo(Automovil auto)
        {
            auto.turnos = new List<Turno>();

            auto.turnos.AddRange(turnos_seleccionados);
            //auto.turnos.Add(new Turno(2));
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void buscarAutoButton_Click(object sender, EventArgs e)
        {
            var buscadorAutos = new ListadoAutomovilesForm(this as Form);
            this.Hide();
            buscadorAutos.Show(this);
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

        private void marcaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (marcaComboBox.SelectedIndex >= 0)
            {
                modeloComboBox.Items.Clear();
                marca_seleccionada = (ObjetosFormCTRL.itemComboBox)marcaComboBox.SelectedItem;

                AutomovilDAO.Instance.setModelos(modeloComboBox, marca_seleccionada.id_item);
            }
        }

        private void licenciaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

        private void modeloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modeloComboBox.SelectedIndex >= 0)
            {
                modelo_seleccionado = (ObjetosFormCTRL.itemComboBox)modeloComboBox.SelectedItem;
            }
        }

        private void turnosCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //TODO crear y agregar turnos seleccionados
        }
    }
}
