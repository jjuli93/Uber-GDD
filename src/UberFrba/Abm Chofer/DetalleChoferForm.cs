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

namespace UberFrba.Abm_Chofer
{
    public partial class DetalleChoferForm : Form
    {
        public DetalleChoferForm(Chofer _chofer)
        {
            InitializeComponent();

            if (_chofer != null)
                this.cargar_datos_form(_chofer);
            else
            {
                if (MessageBox.Show("La aplicación sufrió un error al querer mostrar los datos de un chofer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    this.Owner.Show();
                    this.Dispose();
                }
            }

            this.FormClosing += DetalleChoferForm_FormClosing;
        }

        private void DetalleChoferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjetosFormCTRL.Instance.cerrar_app_Event(sender, e);
        }

        private void cargar_datos_form(Chofer chofer)
        {
            nombreTextBox.Text = chofer.nombre;
            apeliidoTextBox.Text = chofer.apellido;
            dniTextBox.Text = chofer.dni;
            direccionTextBox.Text = chofer.direccion;
            telefonoTextBox.Text = chofer.telefono.ToString();
            mailTextBox.Text = chofer.mail;

            var objCTRL = ObjetosFormCTRL.Instance;

            objCTRL.cargar_valor_comboBox(dayComboBox, chofer.fecha_nacimiento.Day.ToString());
            objCTRL.cargar_valor_comboBox(monthComboBox, chofer.fecha_nacimiento.Month.ToString());
            objCTRL.cargar_valor_comboBox(yearComboBox, chofer.fecha_nacimiento.Year.ToString());

            habilitadoCheckBox.Checked = chofer.habilitado;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
    }
}
