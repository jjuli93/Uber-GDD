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

        public ABMRolForm(menuFuncsRolUserForm _menu)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _menu;
            objController = ObjetosFormCTRL.Instance;
            camposObligatorios = new List<Control>() { nombreTextBox, chkListBoxFuncs };
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
            //FuncionalidadDAO funcController = FuncionalidadDAO.Instance;

            //List<Funcionalidad> listaFuncionalidades = funcController.get_funcionalidades();

            chkListBoxFuncs.Items.Add("F_1");
            chkListBoxFuncs.Items.Add("F_2");
            chkListBoxFuncs.Items.Add("F_3");
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
                MessageBox.Show("Rol creado");
                this.limpiar_form();
            }
            else
            {
                MessageBox.Show("Por favor ingrese los datos requeridos");
            }
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

       
    }
}
