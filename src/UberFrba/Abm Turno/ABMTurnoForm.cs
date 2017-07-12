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
using UberFrba.Modelo;

namespace UberFrba.Abm_Turno
{
    public partial class ABMTurnoForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private TurnoDAO turnoDAO;
        private List<Control> camposObligatorios;

        public ABMTurnoForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToParent();
            formAnterior = _parent;
            objController = ObjetosFormCTRL.Instance;
            turnoDAO = TurnoDAO.Instance;
            kmNumericUpDown.Maximum = turnoDAO.get_max_value();
            precioNumericUpDown.Maximum = turnoDAO.get_max_value();

            camposObligatorios = new List<Control>() { beginDateTimePicker, endDateTimePicker, descripcionTextBox, kmNumericUpDown, precioNumericUpDown };

            this.FormClosing += ABMTurnoForm_FormClosing;
            beginDateTimePicker.Value = Conexion.Instance.getFecha();
            endDateTimePicker.Value = Conexion.Instance.getFecha();
        }

        private void ABMTurnoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            var buscador = new ListadoTurnosForm();

            this.Hide();
            buscador.Show(this);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            objController.borrarMensajeDeError(camposObligatorios, errorProvider);

            if (cumple_campos())
            {
                if (turnoDAO.crear_turno(crear_nuevo_turno()))
                {
                    MessageBox.Show("Turno creado", "Nuevo Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar_form();
                }
                else
                {
                    MessageBox.Show("No se ha podido crear el turno", "Alta Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese todos los datos obligatorios", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private Turno crear_nuevo_turno()
        {
            Turno nuevo = new Turno(0);

            nuevo.descripcion = descripcionTextBox.Text;
            nuevo.hora_inicio = beginDateTimePicker.Value;
            nuevo.hora_fin = endDateTimePicker.Value;
            nuevo.valor_km = precioNumericUpDown.Value;
            nuevo.precio_base = kmNumericUpDown.Value;

            return nuevo;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            limpiar_form();
        }

        private void limpiar_form()
        {
            objController.borrarMensajeDeError(camposObligatorios, errorProvider);
            objController.limpiarControles(this);
        }

        private void cerrarSesionLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

        private bool cumple_campos()
        {
            if (!objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
                return false;

            if (precioNumericUpDown.Value >= precioNumericUpDown.Maximum) 
            {
                precioNumericUpDown.Value = 0;
                errorProvider.SetError(precioNumericUpDown, "Valor máximo permitido: " + turnoDAO.get_max_value().ToString() + ".99");
                return false;
            }

            if (kmNumericUpDown.Value >= precioNumericUpDown.Maximum)
            {
                kmNumericUpDown.Value = 0;
                errorProvider.SetError(kmNumericUpDown, "Valor máximo permitido: " + turnoDAO.get_max_value().ToString() + ".99");
                return false;
            }

            return true;
        }
    }
}
