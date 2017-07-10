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

            dniTextBox.MaxLength = 8;
            telefonoTextBox.MaxLength = 12;
        }

        private void cargar_datos_form(Chofer chofer)
        {
            nombreTextBox.Text = chofer.nombre;
            apeliidoTextBox.Text = chofer.apellido;
            dniTextBox.Text = chofer.dni.ToString();
            direccionTextBox.Text = chofer.direccion;
            telefonoTextBox.Text = chofer.telefono.ToString();
            mailTextBox.Text = chofer.mail;
            fnDateTimePicker.Value = chofer.fecha_nacimiento;
            
            habilitarCheckBox.Checked = chofer.habilitado;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            var campos = new List<Control>() { nombreTextBox, apeliidoTextBox, dniTextBox, telefonoTextBox, direccionTextBox, fnDateTimePicker };

            if (objController.cumpleCamposObligatorios(campos, errorProvider))
            {
                if (MessageBox.Show("¿Está seguro de querer modificar los datos del chofer?", "Modificar Chofer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    update_chofer();
                    if (choferDAO.modificar_chofer(chofer_seleccionado))
                    {
                        MessageBox.Show("Los datos del chofer han sido modificados.", "Modificar Chofer", MessageBoxButtons.OK);
                        var father = this.Owner as ListadoChoferesForm;
                        father.refresh_table();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar los datos del chofer", "Error en Modificar Chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dniTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            objController.only_numbers(e);
        }

        private void update_chofer()
        {
            if (chofer_seleccionado == null)
                return;

            chofer_seleccionado.nombre = nombreTextBox.Text;
            chofer_seleccionado.apellido = apeliidoTextBox.Text;
            chofer_seleccionado.dni = Convert.ToUInt32(dniTextBox.Text);
            chofer_seleccionado.fecha_nacimiento = fnDateTimePicker.Value;
            chofer_seleccionado.habilitado = habilitarCheckBox.Checked;
            chofer_seleccionado.telefono = Convert.ToUInt32(telefonoTextBox.Text);
            chofer_seleccionado.direccion = direccionTextBox.Text;
            chofer_seleccionado.mail = mailTextBox.Text;
        }
    }
}
