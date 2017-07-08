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
    public partial class ModificarRolForm : Form
    {
        ObjetosFormCTRL objController;
        Rol rolSeleccionado;

        public ModificarRolForm(Rol _rol)
        {
            InitializeComponent();
            rolSeleccionado = _rol;
            objController = ObjetosFormCTRL.Instance;
            
            this.FormClosing += ModificarRolForm_FormClosing;

            if (_rol != null)
                cargar_datos_form(_rol);
            else
                MessageBox.Show("Ha ocurrido un error al querer mostrar los datos del Rol", "Error en Modificar Rol", MessageBoxButtons.OK);
        }

        private void ModificarRolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objController.cerrar_app_Event(sender, e);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }

        private void cargar_datos_form(Rol rol)
        {
            nombreTextBox.Text = rol.nombre;
            habilitarCheckBox.Checked = rol.habilitado;

            var funcionalidades = FuncionalidadDAO.Instance.get_funcionalidades();

            foreach (Funcionalidad f in funcionalidades)
            {
                chkListBoxFuncs.Items.Add(new ObjetosFormCTRL.itemListBox(f.descripcion, f.id));
            }

            foreach (var f in rol.funcionalidades)
            {
                objController.check_item_by_id(chkListBoxFuncs, f.id, CheckState.Checked);
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            var campos = new List<Control>() { nombreTextBox, chkListBoxFuncs };

            if (objController.cumpleCamposObligatorios(campos, errorProvider))
            {
                if (MessageBox.Show(string.Format("¿Está seguro de querer modificar el rol {0}?", rolSeleccionado.nombre), "Modificar Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (RolDAO.Instance.modificar_rol(rolSeleccionado))
                    {
                        MessageBox.Show(string.Format("Se ha modificado el rol {0}", rolSeleccionado.nombre), "Rol modificado", MessageBoxButtons.OK);
                        objController.borrarMensajeDeError(campos, errorProvider);
                        var listado = (ListadoRolesForm)this.Owner;
                        listado.reloadTable();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("No se ha podido modificar el rol {0}?", rolSeleccionado.nombre), "Error en Modificar Rol", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {
            rolSeleccionado.nombre = nombreTextBox.Text;
        }

        private void habilitarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            rolSeleccionado.habilitado = habilitarCheckBox.Checked;
        }

        private void chkListBoxFuncs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = (ObjetosFormCTRL.itemListBox)chkListBoxFuncs.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                //se agrega una nueva funcionalidad
                if (rolSeleccionado.funcionalidades.All(f => f.id != item.id_item))
                {
                    Funcionalidad nueva = new Funcionalidad(item.id_item);
                    nueva.descripcion = item.nombre_item;
                    nueva.habilitada = true;

                    rolSeleccionado.funcionalidades.Add(nueva);
                }
            }
            else
            {
                //se elimina una funcionalidad
                Funcionalidad fun = rolSeleccionado.funcionalidades.Find(f => f.id == item.id_item);

                if (fun != null)
                {
                    rolSeleccionado.funcionalidades.Remove(fun);
                }
            }
        }

    }
}
