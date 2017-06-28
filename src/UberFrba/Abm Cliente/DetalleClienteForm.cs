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

namespace UberFrba.Abm_Cliente
{
    public partial class DetalleClienteForm : Form
    {
        public DetalleClienteForm(Cliente _cliente)
        {
            InitializeComponent();

            if (_cliente != null)
                llenar_datos_form(_cliente);
            else
            {
                if (MessageBox.Show("La aplicación sufrió un error al querer mostrar los datos de un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    this.Owner.Show();
                    this.Dispose();
                }
            }

            this.FormClosing += DetalleClienteForm_FormClosing;
        }

        private void DetalleClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjetosFormCTRL.Instance.cerrar_app_Event(sender, e);
        }

        private void llenar_datos_form(Cliente cliente)
        {
            var objCTRL = ObjetosFormCTRL.Instance;

            nombreTextBox.Text = cliente.nombre;
            apellidoTextBox.Text = cliente.apellido;
            dniTextBox.Text = cliente.dni.ToString();
            mailTextBox.Text = cliente.mail;
            telTextBox.Text = cliente.telefono.ToString();
            dirTextBox.Text = cliente.direccion;
            cpTextBox.Text = cliente.codigoPostal.ToString();
            fechaNacTextBox.Text = cliente.fecha_nacimiento.ToShortDateString();
            habilitadoCheckBox.Checked = cliente.habilitado;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        
    }
}
