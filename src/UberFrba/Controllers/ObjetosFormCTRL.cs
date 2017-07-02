using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using UberFrba.Modelo;
using System.ComponentModel;
using UberFrba.Login;

namespace UberFrba.Controllers
{
    class ObjetosFormCTRL
    {
        private static readonly ObjetosFormCTRL _instance = new ObjetosFormCTRL();

        static ObjetosFormCTRL() { }
        private ObjetosFormCTRL() { }

        public static ObjetosFormCTRL Instance
        {
            get
            {
                return _instance;
            }
        }

        public class itemComboBox
        {
            public string nombre_item { get; set; }
            public int id_item { get; set; }

            public itemComboBox(string _nombre, int _id)
            {
                nombre_item = _nombre;
                id_item = _id;
            }

            public override string ToString()
            {
                return nombre_item;
            }
        }

        public class itemListBox : itemComboBox
        {
            public itemListBox(string _nombre, int _id) : base(_nombre, _id) { }
        }

        /*
         * Llena el contenido de los comboBox para la fecha de nacimiento
         */
     
        public void cargar_valor_comboBox(ComboBox combo, string valor)
        {
            bool pudo_setear = false;

            foreach (var item in combo.Items)
            {
                if (item.ToString() == valor)
                {
                    combo.SelectedIndex = combo.Items.IndexOf(item);
                    pudo_setear = true;
                }
            }

            if (!pudo_setear)
            {
                combo.SelectedIndex = -1;
                combo.Text = "Not found";
                combo.BackColor = Color.Red;
            }
        }

        public void cargar_objeto_comboBox(ComboBox combo, int id_item)
        {
            bool pudo_setear = false;

            foreach (itemComboBox item in combo.Items)
            {
                if (item.id_item == id_item)
                {
                    combo.SelectedIndex = combo.Items.IndexOf(item);
                    pudo_setear = true;
                    break;
                }
            }

            if (!pudo_setear)
            {
                combo.SelectedIndex = -1;
                combo.Text = "Not found";
                combo.BackColor = Color.Red;
            }
        }

        public void habilitarContenidoPanel(Panel _panel, bool habilitar)
        {
            foreach (Control objCtrl in _panel.Controls)
            {
                objCtrl.Enabled = habilitar;
            }
        }

        public bool cumpleCamposObligatorios(List<Control> campos, ErrorProvider e)
        {
            return campos.All(c => campo_cumple(c, e));
        }

        public bool esCampoVacio(Control campo, ErrorProvider e)
        {
            if (string.IsNullOrEmpty(campo.Text))
            {
                campo.Focus();
                e.SetError(campo, "Ingrese los datos requeridos");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool campo_cumple(Control c, ErrorProvider e)
        {
            bool cumple = true;

            var tbox = c as TextBox;
            var chkList = c as CheckedListBox;
            var combo = c as ComboBox;
            var numUpDown = c as NumericUpDown;

            if (tbox != null)
                cumple = !this.esCampoVacio(tbox, e);

            if (chkList != null)
            {
                cumple = chkList.SelectedItems.Count > 0;

                if (!cumple)
                {
                    chkList.Focus();
                    e.SetError(chkList, "Seleccione por lo menos un item");
                }
            }

            if (combo != null)
                cumple = !this.esCampoVacio(combo, e);

            if (numUpDown != null)
            {
                cumple = numUpDown.Value > 0;

                if (!cumple)
                {
                    numUpDown.Focus();
                    e.SetError(numUpDown, "Ingrese un monto o cantidad");
                }
            }

            return cumple;
        }

        public void borrarMensajeDeError(List<Control> campos, ErrorProvider errorProv)
        {
            foreach (var c in campos)
            {
                errorProv.SetError(c, "");
            }
        }

        public void limpiarControles(Control father)
        {
            foreach (Control c in father.Controls)
            {
                var tbox = c as TextBox;
                var combo = c as ComboBox;
                var table = c as DataGridView;
                var calen = c as DateTimePicker;
                var check = c as CheckBox;
                var chkList = c as CheckedListBox;

                if (tbox != null)
                {
                    tbox.Text = string.Empty;
                }

                if (combo != null)
                {
                    combo.SelectedIndex = -1;
                }

                if (table != null)
                {
                    table.Rows.Clear();
                    table.Refresh();
                }

                if (calen != null)
                {
                    // TODO: clear datetimepicker
                }

                if (check != null)
                {
                    check.Checked = false;
                }

                if (chkList != null)
                {
                    chkList.SelectedItems.Clear();
                    chkList.SelectedIndices.Clear();
                    this.descheckearItems(chkList);
                }

                this.limpiarControles(c);
            }
        }

        public void descheckearItems(CheckedListBox items)
        {
            foreach (int i in items.CheckedIndices) {
                items.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        public void showDefaultComboBox(ComboBox combo, string desc)
        {
            if (combo.SelectedIndex < 0)
            {
                combo.Text = desc;
            }
        }

        public void textGotFocus_Direccion(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == "calle, nro piso, depto. y localidad")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void textLostFocus_Direccion(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == "")
            {
                tb.Text = "calle, nro piso, depto. y localidad";
                tb.ForeColor = Color.LightGray;
            }
        }

        public void form_Closing(object sender, EventArgs e)
        {
            /*
             * DICOTOMIA: 
             * Al hacer click de "X" cierro la app o 
             * solo la ventana actual?
             */

            Application.Exit();
            //or
            //Form form = (Form)sender;
            //form.Close();
        }

        public bool direccion_vacia(TextBox tb, ErrorProvider err)
        {
            bool resp = false;

            if ((string.IsNullOrEmpty(tb.Text)) || (tb.Text.Equals("calle, nro piso, depto. y localidad")))
            {
                resp = true;
                err.SetError(tb, "Ingrese los datos requeridos");
            }

            return resp;
        }

        public void inicializar_Marcas(ComboBox combo)
        {
            AutomovilDAO.Instance.setMarcas(combo);
        }

        public void habilitar_botones(List<Button> botones, bool valorHab)
        {
            foreach (var boton in botones)
            {
                (boton as Button).Enabled = valorHab;
            }
        }

        public void cerrar_app_Event(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("¿Está ud. seguro de querer salir de UberFRBA?", "Salir de UberFRBA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Environment.Exit(0);
                    Application.Exit();
                }    
            }
        }

        public void cerrar_sesion()
        {
            if (MessageBox.Show("¿Está ud. seguro de querer salir de UberFRBA?", "Salir de UberFRBA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        public void mostrar_mensajeDeError(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public void check_item_by_id(CheckedListBox list, int id, CheckState state)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                var item = (ObjetosFormCTRL.itemListBox)list.Items[i];

                if (item.id_item == id)
                    list.SetItemCheckState(i, state);
            }
        }
    }
}
