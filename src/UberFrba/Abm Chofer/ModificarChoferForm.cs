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
    public partial class ModificarChoferForm : Form
    {
        ObjetosFormCTRL objController;
        ChoferDAO choferDAO;
        Chofer chofer_seleccionado;

        public ModificarChoferForm(Chofer _chofer)
        {
            InitializeComponent();
            objController = ObjetosFormCTRL.Instance;
            choferDAO = ChoferDAO.Instance;

            if (_chofer != null)
            {
                chofer_seleccionado = _chofer;
                this.cargar_datos_form(_chofer);
            }
            else
            {
                if (MessageBox.Show("La aplicación sufrió un error al querer modificar un chofer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                    this.Owner.Show();
                    this.Dispose();
            }
        }

        private void cargar_datos_form(Chofer chofer)
        {
            nombreTextBox.Text = chofer.nombre;
            apeliidoTextBox.Text = chofer.apellido;
            dniTextBox.Text = chofer.dni;
            direccionTextBox.Text = chofer.direccion;
            telefonoTextBox.Text = chofer.telefono.ToString();
            mailTextBox.Text = chofer.mail;

            objController.cargar_valor_comboBox(this.dayComboBox, chofer.fecha_nacimiento.Day.ToString());
            objController.cargar_valor_comboBox(this.monthComboBox, chofer.fecha_nacimiento.Month.ToString());
            objController.cargar_valor_comboBox(this.yearComboBox, chofer.fecha_nacimiento.Year.ToString());

            habilitarCheckBox.Checked = chofer.habilitado;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
    }
}
