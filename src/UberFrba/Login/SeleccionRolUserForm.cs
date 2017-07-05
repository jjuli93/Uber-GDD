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
    public partial class SeleccionRolUserForm : Form
    {
        public Usuario userLogged;
        public Rol rolSelected = null;
        private ObjetosFormCTRL objController;

        public SeleccionRolUserForm(Usuario _usuarioLogueado)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.userLogged = _usuarioLogueado;
            objController = ObjetosFormCTRL.Instance;
            this.llenarDatosComboBox();
            RolesComboBox.SelectedIndexChanged += new System.EventHandler(this.RolesComboBox_SelectedIndexChanged);
            this.FormClosing += SeleccionRolUserForm_FormClosing;
            this.ingresarConRolButton.Enabled = false;
            this.AcceptButton = this.ingresarConRolButton;
        }

        private void llenarDatosComboBox()
        {
            foreach (Rol rol in userLogged.roles)
            {
                if (rol.habilitado)
                {
                    RolesComboBox.Items.Add(new ObjetosFormCTRL.itemComboBox(rol.nombre, rol.id));
                }
            }
        }

        private void RolesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetosFormCTRL.itemComboBox rol_seleccionado = RolesComboBox.SelectedItem as ObjetosFormCTRL.itemComboBox;

            foreach (Rol rol in userLogged.roles)
            {
                if ((rol.id == rol_seleccionado.id_item) && (rol.nombre.Equals(rol_seleccionado.nombre_item)))
                {
                    rolSelected = rol;
                    break;
                }
            }

            if (rolSelected != null)
            {
                this.ingresarConRolButton.Enabled = true;
            }
        }

        private void ingresarConRolButton_Click(object sender, EventArgs e)
        {
            if ((userLogged != null) && (rolSelected != null))
            {
                menuFuncsRolUserForm menuFuncionalidades = new menuFuncsRolUserForm(userLogged, rolSelected, false);
                menuFuncionalidades.Show(this);
                this.Hide();
            }
        }

        private void SeleccionRolUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void cerrarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objController.cerrar_sesion();
        }

    }
}
