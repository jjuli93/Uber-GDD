﻿using System;
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
using UberFrba.Abm_Chofer;
using UberFrba.Modelo;

namespace UberFrba.Abm_Automovil
{
    public partial class ABMAutomovilForm : Form
    {
        private menuFuncsRolUserForm formAnterior;
        private ObjetosFormCTRL objController;
        private List<Control> camposObligatorios;
        public Chofer choferSeleccionado;

        public ABMAutomovilForm(menuFuncsRolUserForm _menu)
        {
            InitializeComponent();
            this.CenterToScreen();
            formAnterior = _menu;
            objController = ObjetosFormCTRL.Instance;
            objController.inicializar_Marcas(this.marcaComboBox);
            camposObligatorios = new List<Control>() { marcaComboBox, modeloTextBox, patenteTextBox, nombreChoferTB, turnoComboBox };
            objController.setCBTurno(this.turnoComboBox);
            this.FormClosing += ABMAutomovilForm_FormClosing;
        }

        private void ABMAutomovilForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.objController.cerrar_app_Event(sender, e);
        }

        private void limpiar_form()
        {
            objController.limpiarControles(this);
            objController.borrarMensajeDeError(this.camposObligatorios, errorProvider);
        }

        private void buscarChoferButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
            var buscadorChofer = new ListadoChoferesForm(this, false);
            this.Hide();
            buscadorChofer.ShowDialog(this);
        }

        public void setChoferSeleccionado(Chofer _chofer)
        {
            if (_chofer != null)
            {
                choferSeleccionado = _chofer;
                nombreChoferTB.Text = choferSeleccionado.nombre + " " + choferSeleccionado.apellido;
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.limpiar_form();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                objController.borrarMensajeDeError(camposObligatorios, errorProvider);
                this.limpiar_form();
                MessageBox.Show("Automovil creado");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void buscarAutoButton_Click(object sender, EventArgs e)
        {
            var buscadorAutos = new ListadoAutomovilesForm(this as Form);
            this.Hide();
            buscadorAutos.Show(this);
        }

    }
}