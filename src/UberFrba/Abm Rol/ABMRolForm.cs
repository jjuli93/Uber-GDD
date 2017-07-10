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

namespace UberFrba.Abm_Rol
{
    public partial class ABMRolForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private List<Control> camposObligatorios;
        private List<ObjetosFormCTRL.itemListBox> funcionalidades_seleccionadas;

        public ABMRolForm(menuFuncsRolUserForm _menu)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _menu;
            objController = ObjetosFormCTRL.Instance;
            camposObligatorios = new List<Control>() { nombreTextBox, chkListBoxFuncs };
            funcionalidades_seleccionadas = new List<ObjetosFormCTRL.itemListBox>();
            chkListBoxFuncs.Items.Clear();
            this.inicializarFuncionalidades();

            this.FormClosing += ABMRolForm_FormClosing;
        }

        private void ABMRolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
        }

        private void limpiar_form()
        {
            this.objController.limpiarControles(this);
        }

        private void inicializarFuncionalidades()
        {
            var funcionalidades = FuncionalidadDAO.Instance.get_funcionalidades();

            foreach (Funcionalidad func in funcionalidades)
            {
                this.chkListBoxFuncs.Items.Add(new ObjetosFormCTRL.itemListBox(func.descripcion, func.id));
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            this.Hide();
            ListadoRolesForm buscadorRoles = new ListadoRolesForm(this);
            buscadorRoles.Show(this);
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            objController.borrarMensajeDeError(camposObligatorios, errorProvider);

            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                if (RolDAO.Instance.crear_rol(nombreTextBox.Text, funcionalidades_seleccionadas))
                {
                    MessageBox.Show("Rol creado", "Nuevo Rol");
                    this.limpiar_form();
                }
                else
                {
                    MessageBox.Show("No se ha podido crear el Rol", "Error en Nuevo Rol");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese los datos requeridos");
            }
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            this.Owner.Show();
            this.Dispose();
        }

        private void chkListBoxFuncs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = (ObjetosFormCTRL.itemListBox)chkListBoxFuncs.Items[e.Index];

            if (e.CurrentValue != CheckState.Checked)
            {
                funcionalidades_seleccionadas.Add(item);
            }
            else
            {
                funcionalidades_seleccionadas.Remove(item);
            }
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

       
    }
}
