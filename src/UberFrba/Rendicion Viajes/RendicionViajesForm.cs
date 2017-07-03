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

        public RendicionViajesForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.formAnterior = _parent;

            objController = ObjetosFormCTRL.Instance;
            camposObligatorios = new List<Control>() { fechaDateTimePicker, datosChoferTB, turnoComboBox };

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
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                //magia.....
                if (MessageBox.Show("Rendición exitosa.", "Rendición de viajes", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    objController.limpiarControles(this);
                    return;
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
            Automovil auto_chofer = AutomovilDAO.Instance.get_automovil_chofer(chofer_seleccionado.id);

            if (auto_chofer == null)
                return;

            List<Turno> turnos = TurnoDAO.Instance.get_turnos_automovil(auto_chofer.id);

            foreach (var item in turnos)
            {
                turnoComboBox.Items.Add(new ObjetosFormCTRL.itemComboBox(item.descripcion, item.id));
            }
        }
    }
}
