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
using UberFrba.Abm_Chofer;
using UberFrba.Controllers;
using UberFrba.Modelo;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViajesForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private List<Control> camposObligatorios;
        private Chofer chofer_seleccionado;
        private int turno_seleccionado;

        public RendicionViajesForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.formAnterior = _parent;

            objController = ObjetosFormCTRL.Instance;
            camposObligatorios = new List<Control>() { fechaDateTimePicker, datosChoferTB, turnoComboBox };

            fechaDateTimePicker.Value = Conexion.Instance.getFecha();

            this.FormClosing += RendicionViajesForm_FormClosing;
        }

        private void RendicionViajesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void buscarChoferBtn_Click(object sender, EventArgs e)
        {
            var buscador = new ListadoChoferesForm(this, false);

            buscador.Show(this);
            this.Hide();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void realizarPagoBtn_Click(object sender, EventArgs e)
        {
            limpiar_form();
            int id_rendicion = 0;

            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                id_rendicion = ChoferDAO.Instance.realizar_rendicion(chofer_seleccionado.id, fechaDateTimePicker.Value, turno_seleccionado);

                if (id_rendicion > 0)
                {
                    set_importe_rendicion(id_rendicion);
                    set_viajes_rendicion(id_rendicion);
                }
                else
                {
                    MessageBox.Show("No se ha podido realizar la rendicion al chofer seleccionado", "Rendición de viajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show("Por favor ingrese todos los datos obligatorios", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    objController.borrarMensajeDeError(camposObligatorios, errorProvider);
                    return;
                }
            }
        }

        private void set_viajes_rendicion(int id_rendicion)
        {
            DataTable viajes = ChoferDAO.Instance.get_viajes_chofer(id_rendicion);

            if (viajes.Rows.Count <= 0)
            {
                MessageBox.Show("No se han encontrado viajes realizador por el chofer", "Alta de Rendición Chofer", MessageBoxButtons.OK);
                return;
            }             
            
            viajesDataGridView.DataSource = viajes;
        }

        private void set_importe_rendicion(int id_rendicion)
        {
            double importe = ChoferDAO.Instance.get_importe_rendicion(id_rendicion);

            if (importe == -1) 
            {
                MessageBox.Show("Ha ocurrido un error al calcular el importe de la rendición", "Alta de Rendición Chofer", MessageBoxButtons.OK);
                return;
            }

            importeTextBox.Text = "$ " + importe.ToString();
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

        public void setChoferSeleccionado(Chofer _chofer_seleccionado)
        {
            if (_chofer_seleccionado == null)
                return;

            this.chofer_seleccionado = _chofer_seleccionado;
            datosChoferTB.Text = string.Format("{0} {1}", _chofer_seleccionado.nombre, _chofer_seleccionado.apellido);

            set_turnos_chofer();
        }

        private void set_turnos_chofer()
        {
            try
            {
                turnoComboBox.Items.Clear();
            }
            catch (NullReferenceException)
            {
                //throw;
            }

            Automovil auto_chofer = AutomovilDAO.Instance.get_automovil_chofer(chofer_seleccionado.id);

            if (auto_chofer == null)
                return;

            List<Turno> turnos = TurnoDAO.Instance.get_turnos_automovil(auto_chofer.id);

            foreach (var item in turnos)
            {
                turnoComboBox.Items.Add(new ObjetosFormCTRL.itemComboBox(item.descripcion, item.id));
            }
        }

        private void turnoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetosFormCTRL.itemComboBox turno = (ObjetosFormCTRL.itemComboBox)turnoComboBox.SelectedItem;

            if ((turno != null) && (turnoComboBox.SelectedIndex >= 0))
            {
                turno_seleccionado = turno.id_item;
            }
        }

        private void limpiar_form()
        {
            this.viajesDataGridView.Rows.Clear();
            this.viajesDataGridView.DataSource = null;
            importeTextBox.Text = string.Empty;
        }
    }
}
