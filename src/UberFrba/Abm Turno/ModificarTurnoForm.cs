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

namespace UberFrba.Abm_Turno
{
    public partial class ModificarTurnoForm : Form
    {
        Turno turnoSeleccionado;
        ObjetosFormCTRL objController;
        TurnoDAO turnoDAO;

        public ModificarTurnoForm(Turno _turno)
        {
            InitializeComponent();

            if (_turno != null)
            {
                turnoSeleccionado = _turno;
                cargar_datos_form(_turno);
            }
            else
            {
                if (MessageBox.Show("La aplicación sufrió un error al querer mostrar los datos de un turno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    this.Owner.Show();
                    this.Dispose();
                }
            }

            objController = ObjetosFormCTRL.Instance;
            turnoDAO = TurnoDAO.Instance;
            this.FormClosing += ModificarTurnoForm_FormClosing;
        }

        private void ModificarTurnoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void cargar_datos_form(Turno _turno)
        {
            beginDateTimePicker.Value = _turno.hora_inicio;
            endDateTimePicker.Value = _turno.hora_fin;
            descripcionTextBox.Text = _turno.descripcion;
            kmNumericUpDown.Value = (decimal)_turno.valor_km;
            precioNumericUpDown.Value = (decimal)_turno.precio_base;
            habilitarCheckBox.Checked = _turno.habilitado;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            //turnoDAO hace la magia
        }
    }
}
