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
            beginDateTimePicker.Value = Convert.ToDateTime(_turno.hora_inicio);
            endDateTimePicker.Value = Convert.ToDateTime(_turno.hora_fin);
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
            var campos = new List<Control>() { beginDateTimePicker, endDateTimePicker, descripcionTextBox, kmNumericUpDown, precioNumericUpDown };

            if (objController.cumpleCamposObligatorios(campos, errorProvider))
            {
                if (MessageBox.Show("¿Está seguro de querer modificar los datos del turno?", "Modificar Turno", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    update_turno();

                    if (turnoDAO.modificar_turno(turnoSeleccionado))
                    {
                        (this.Owner as ListadoTurnosForm).refresh_table();
                        if (MessageBox.Show("Los datos del turno han sido modificados.", "Modificar Turno", MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            this.Owner.Show();
                            this.Dispose();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar los datos del turno", "Error en Modificar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void update_turno()
        {
            turnoSeleccionado.descripcion = descripcionTextBox.Text;
            turnoSeleccionado.hora_inicio = beginDateTimePicker.Value;
            turnoSeleccionado.hora_fin = endDateTimePicker.Value;
            turnoSeleccionado.precio_base = (float)precioNumericUpDown.Value;
            turnoSeleccionado.valor_km = (float)kmNumericUpDown.Value;
            turnoSeleccionado.habilitado = habilitarCheckBox.Checked;
        }
    }
}
