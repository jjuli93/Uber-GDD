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
    public partial class DetalleTurnoForm : Form
    {
        public DetalleTurnoForm(Turno _turno)
        {
            InitializeComponent();

            if (_turno != null)
            {
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

            this.FormClosing += DetalleTurnoForm_FormClosing;
            beginDateTimePicker.Value = Conexion.Instance.getFecha();
            endDateTimePicker.Value = Conexion.Instance.getFecha();
        }

        private void DetalleTurnoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjetosFormCTRL.Instance.cerrar_app_Event(sender, e);
        }

        private void cargar_datos_form(Turno _turno)
        {
            beginDateTimePicker.Value = Convert.ToDateTime(_turno.hora_inicio);
            endDateTimePicker.Value = Convert.ToDateTime(_turno.hora_fin);
            descripcionTextBox.Text = _turno.descripcion;
            kmNumericUpDown.Value = (decimal)_turno.valor_km; //Convert.ToDecimal(_turno.valor_km)
            precioNumericUpDown.Value = (decimal)_turno.precio_base;
            habilitadoCheckBox.Checked = _turno.habilitado;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
    }
}
