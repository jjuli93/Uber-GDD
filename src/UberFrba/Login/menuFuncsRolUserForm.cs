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

namespace UberFrba.Login
{
    public partial class menuFuncsRolUserForm : Form
    {
        private Funcionalidad funcionalidadSeleccionada = null;
        public Usuario userLogged;
        public Rol rolSelected;
        public SeleccionRolUserForm formAnterior;
        private ObjetosFormCTRL objController;

        public menuFuncsRolUserForm(SeleccionRolUserForm _form, Usuario _user, Rol _rol)
        {
            InitializeComponent();
            this.CenterToScreen();
            objController = ObjetosFormCTRL.Instance;
            this.formAnterior = _form;
            this.userLogged = _user;
            this.rolSelected = _rol;
            this.fillListBox();
            this.AcceptButton = this.seleccionarButton;
            this.FormClosing += menuFuncsRolUserForm_FormClosing;
        }

        private void menuFuncsRolUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void fillListBox()
        {
            foreach (Funcionalidad func in rolSelected.funcionalidades)
            {
                this.funcionalidadesListBox.Items.Add(new ObjetosFormCTRL.itemListBox(func.nombre, func.id));
            }
        }

        /*
         * Captura la funcionalidad seleccionada 
         * y muestra la descripcion dentro del richBox.
         */
        private void funcionalidadesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetosFormCTRL.itemListBox funcSelected = this.funcionalidadesListBox.SelectedItem as ObjetosFormCTRL.itemListBox;

            foreach (Funcionalidad item in this.rolSelected.funcionalidades)
            {
                if ((item.id == funcSelected.id_item) && (item.nombre.Equals(funcSelected.nombre_item)))
                {
                    funcionalidadSeleccionada = item;
                    break;
                }
            }

            if (funcionalidadSeleccionada != null)
            {
                seleccionarButton.Enabled = true;
                descripcionRichTextBox.Text = funcionalidadSeleccionada.descripcion;
            }
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.formAnterior.Show();
            this.Dispose();
        }

        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            Form formFunc = funcionalidadSeleccionada.get_form_funcionalidad(funcionalidadSeleccionada, this);

            if (formFunc != null)
            {
                this.Hide();
                formFunc.Show(this);
            }
            else
            {
                if (MessageBox.Show("Ha ocurrido un error en el programa. Se procede en finalizar.", "Error en seleccion de funcionalidad", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    objController.cerrar_app_Event(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
                }
            }
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }
    }
}
