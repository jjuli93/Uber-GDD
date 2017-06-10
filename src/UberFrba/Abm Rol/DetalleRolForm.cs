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

namespace UberFrba.Abm_Rol
{
    public partial class DetalleRolForm : Form
    {
        public DetalleRolForm()
        {
            InitializeComponent();
            this.FormClosing += DetalleRolForm_FormClosing;
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
    }
}
