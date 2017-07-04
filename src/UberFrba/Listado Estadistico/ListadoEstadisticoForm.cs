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

namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadisticoForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        
        public List<Control> campos_obligatorios;

        public ListadoEstadisticoForm(menuFuncsRolUserForm _parent)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _parent;

            yearNumericUpDown.Maximum = DateTime.Now.Year;

            campos_obligatorios = new List<Control>() { yearNumericUpDown, trimestreComboBox, tiposListadoListBox };

            TopDAO.Instance.fill_consultas_on_ListBox(tiposListadoListBox);
            TopDAO.Instance.fill_trimestres(trimestreComboBox);

            this.FormClosing += ListadoEstadisticoForm_FormClosing;
        }

        private void ListadoEstadisticoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjetosFormCTRL.Instance.cerrar_app_Event(sender, e);
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ObjetosFormCTRL.Instance.cerrar_sesion();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            ObjetosFormCTRL.Instance.limpiarControles(this);
            tiposListadoListBox.ClearSelected();
            ObjetosFormCTRL.Instance.borrarMensajeDeError(campos_obligatorios, errorProvider);
        }

        private void consultarButton_Click(object sender, EventArgs e)
        {
            ObjetosFormCTRL.Instance.borrarMensajeDeError(campos_obligatorios, errorProvider);

            if (ObjetosFormCTRL.Instance.cumpleCamposObligatorios(campos_obligatorios, errorProvider))
            {
                int year = (int) yearNumericUpDown.Value;
                int trimestre = ((ObjetosFormCTRL.itemComboBox) trimestreComboBox.SelectedItem).id_item;
                int tipo_id = ((ObjetosFormCTRL.itemComboBox) tiposListadoListBox.SelectedItem).id_item;

                DataTable consulta = TopDAO.Instance.consultar_top(year, trimestre, tipo_id);
                listadoDataGridView.DataSource = consulta;

                if (consulta.Rows.Count == 0) {
                    MessageBox.Show("No se han encontrado resultados para la consulta realizada", "Listado Estadistico", MessageBoxButtons.OK);
                }
            }
        }

    }
}
