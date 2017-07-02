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
using UberFrba.Abm_Chofer;

namespace UberFrba.Abm_Automovil
{
    public partial class ModificarAutomovilForm : Form
    {
        Automovil automovilSeleccionado;
        ObjetosFormCTRL objController;
        AutomovilDAO autoDAO;
        Form formAnterior;
        Chofer chofer_seleccionado;

        public ModificarAutomovilForm(Automovil _auto, Form _formAnterior)
        {
            InitializeComponent();
            CenterToScreen();
            automovilSeleccionado = _auto;
            objController = ObjetosFormCTRL.Instance;
            autoDAO = AutomovilDAO.Instance;
            cargar_datos_form(_auto);
            formAnterior = _formAnterior;
            this.FormClosing += ModificarAutomovilForm_FormClosing;
        }

        private void ModificarAutomovilForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void cargar_datos_form(Automovil auto)
        {
            objController.inicializar_Marcas(this.marcaComboBox);
            objController.cargar_objeto_comboBox(marcaComboBox, auto.idmarca);

            autoDAO.setModelos(modeloComboBox, auto.idmarca);
            objController.cargar_objeto_comboBox(modeloComboBox, auto.idmodelo);

            patenteTextBox.Text = auto.patente;
            nombreChoferTB.Text = auto.chofer_id.ToString();
            cargar_turnos(auto);
            licenciaTextBox.Text = auto.licencia.ToString();
            rodadoTextBox.Text = auto.rodado;
            habilitarCheckBox.Checked = auto.habilitado;
        }

        private void cargar_turnos(Automovil auto)
        {
            List<ObjetosFormCTRL.itemListBox> turnos = TurnoDAO.Instance.get_turnos_asList();

            foreach (var item in turnos)
            {
                turnosCheckedListBox.Items.Add(item);
            }

            checkear_items(auto.turnos);
        }

        private void checkear_items(List<Turno> turnos)
        {
            ObjetosFormCTRL.itemListBox item = null;

            foreach (var turno in turnos)
            {
                for (int i = 0; i <= (turnosCheckedListBox.Items.Count - 1); i++)
                {
                    item = (ObjetosFormCTRL.itemListBox) turnosCheckedListBox.Items[i];

                    if ((item.id_item == turno.id) && (item.nombre_item == turno.descripcion))
                    {
                        turnosCheckedListBox.SetItemCheckState(i, CheckState.Checked);
                        break;
                    }
                }     
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void buscarChoferButton_Click(object sender, EventArgs e)
        {
            var buscador = new ListadoChoferesForm(this, false);
            buscador.Show(this);
            this.Hide();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            List<Control> obligatorios = new List<Control>() { marcaComboBox, modeloComboBox, nombreChoferTB, patenteTextBox, turnosCheckedListBox };

            if (objController.cumpleCamposObligatorios(obligatorios, errorProvider))
            {
                if (MessageBox.Show("¿Está seguro de querer guardar los cambios realizados?", "Modificación Automóvil", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    actualizar_turnos_checkeados();
                    if (!autoDAO.modificacion_automovil(automovilSeleccionado))
                    {
                        MessageBox.Show("[Error] No se han podido guardar los cambios realizados", "Error en Modificación Automovil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void actualizar_turnos_checkeados()
        {
            ObjetosFormCTRL.itemListBox item = null;
            int pos = -1;

            for (int i = 0; i < (turnosCheckedListBox.Items.Count - 1); i++)
            {
                item = (ObjetosFormCTRL.itemListBox)turnosCheckedListBox.Items[i];
                pos = esta_en_lista(item);

                if (turnosCheckedListBox.GetItemChecked(i)) //checked
                {
                    if (pos == -1) //ITS CHECKED BUT NOT IN THE LIST THEN ITS A NEW ONE
                    {
                        Turno nuevo = new Turno(item.id_item);
                        nuevo.descripcion = item.nombre_item;

                        automovilSeleccionado.turnos.Add(nuevo);
                    }
                }
                else //not checked
                {
                    if (pos >= 0) //ITS NOT CHECKED BUT ITS IN THE LIST THEN I MUST REMOVE IT
                    {
                        automovilSeleccionado.turnos.RemoveAt(pos);
                    }
                }
            }
        }

        private int esta_en_lista(ObjetosFormCTRL.itemListBox item) 
        {
            int pos = -1;

            for (int i = 0; i < (automovilSeleccionado.turnos.Count - 1); i++)
            {
                Turno turno = automovilSeleccionado.turnos[i];

                if (turno.id == item.id_item)
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        private void marcaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var marca = (ObjetosFormCTRL.itemComboBox)marcaComboBox.SelectedItem;

            autoDAO.setModelos(modeloComboBox, marca.id_item);

            automovilSeleccionado.marca = marca.nombre_item;
            automovilSeleccionado.idmarca = marca.id_item;
        }

        private void modeloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var modelo = (ObjetosFormCTRL.itemComboBox)modeloComboBox.SelectedItem;

            automovilSeleccionado.idmodelo = modelo.id_item;
            automovilSeleccionado.modelo = modelo.nombre_item;
        }
    }
}
