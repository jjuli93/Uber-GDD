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
    public partial class DetalleAutomovilForm : Form
    {
        Form formAnterior;

        public DetalleAutomovilForm(Automovil _auto, Form _formAnterior)
        {
            InitializeComponent();
            CenterToScreen();
            formAnterior = _formAnterior;

            if (_auto != null)
                this.cargar_datos_form(_auto);

            this.FormClosing += DetalleAutomovilForm_FormClosing;
        }

        private void DetalleAutomovilForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var objController = ObjetosFormCTRL.Instance;

            objController.cerrar_app_Event(sender, e);
        }

        private void cargar_datos_form(Automovil auto)
        {
            marcaTextBox.Text = auto.marca;
            modeloTextBox.Text = auto.modelo;
            patenteTextBox.Text = auto.patente;
            choferTextBox.Text = auto.chofer_id.ToString();
            turnoTextBox.Text = auto.turno;
            licenciaTextBox.Text = auto.licencia.ToString();
            rodadoTextBox.Text = auto.rodado;
            habilitadoCheckBox.Checked = auto.habilitado;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

    }
}
