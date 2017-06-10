using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Modelo;
using UberFrba.Controllers;

namespace UberFrba.Abm_Automovil
{
    public partial class ModificarAutomovilForm : Form
    {
        Automovil automovilSeleccionado;
        ObjetosFormCTRL objController;
        AutomovilDAO autoDAO;
        Form formAnterior;

        public ModificarAutomovilForm(Automovil _auto, Form _formAnterior)
        {
            InitializeComponent();
            CenterToScreen();
            automovilSeleccionado = _auto;
            objController = ObjetosFormCTRL.Instance;
            autoDAO = AutomovilDAO.Instance;
            objController.inicializar_Marcas(this.marcaComboBox);
            objController.setCBTurno(this.turnoComboBox);
            cargar_datos_form(_auto);
            formAnterior = _formAnterior;
            this.FormClosing += ModificarAutomovilForm_FormClosing;
        }

        private void ModificarAutomovilForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void cargar_datos_form(Automovil auto)
        {
            objController.cargar_valor_comboBox(marcaComboBox, auto.marca);
            modeloTextBox.Text = auto.modelo;
            patenteTextBox.Text = auto.patente;
            nombreChoferTB.Text = auto.chofer_id.ToString();
            objController.cargar_valor_comboBox(turnoComboBox, auto.turno);
            habilitarCheckBox.Checked = auto.habilitado;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

    }
}
