using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Controllers;
using UberFrba.Modelo;

namespace UberFrba.Abm_Rol
{
    public partial class DetalleRolForm : Form
    {
        public DetalleRolForm(Rol _rolSeleccionado)
        {
            InitializeComponent();
            this.FormClosing += DetalleRolForm_FormClosing;

            if (_rolSeleccionado != null)
                cargar_datos_form(_rolSeleccionado);
            else
                MessageBox.Show("Ha ocurrido un error al querer mostrar los datos del Rol", "Error en Detalle Rol", MessageBoxButtons.OK);
        }

        private void DetalleRolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjetosFormCTRL.Instance.cerrar_app_Event(sender, e);
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void cargar_datos_form(Rol rol)
        {
            nombreTextBox.Text = rol.nombre;
            habilitadoCheckBox.Checked = rol.habilitado;

            foreach (var f in rol.funcionalidades)
            {
                funcionalidadesLB.Items.Add(f.descripcion);
            }
        }
    }
}
