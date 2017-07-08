using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using UberFrba.Modelo;
using UberFrba.Controllers;

namespace UberFrba.Login
{
    public partial class LoginForm : Form
    {
        private List<Control> camposObligatorios;
        ObjetosFormCTRL objController;

        private const string userHardcodeado = "admin";
        private const string passHardcodeada = "w23e";

        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.AcceptButton = IngresarButton;
            camposObligatorios = new List<Control>() { userTextBox, passTextBox };
            objController = ObjetosFormCTRL.Instance;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IngresarButton_Click(object sender, EventArgs e)
        {
            if (objController.cumpleCamposObligatorios(camposObligatorios, errorProvider))
            {
                string _username = userTextBox.Text;
                //Password encriptada con SHA256
                //string _password = passwordToEncript();
                string _password = passTextBox.Text;

                int resultado_login = LoginDAO.Instance.loguear_usuario(_username, _password);

                switch (resultado_login)
                {
                    case -1 : // no existe el user
                        if (MessageBox.Show("El usuario " + _username + " no existe.", "Error en el login", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                            return;
                        break;
                    case -2: //  pass incorrecta
                        if (MessageBox.Show("Usuario o contraseña incorrectos.", "Error en los datos ingresados", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                            return;
                        break;
                    case -3: //  user bloqueado
                        if (MessageBox.Show("El usuario " + _username + " se ha bloqueado.", "Se ha quedado sin intentos de login", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            userTextBox.Text = "";
                            passTextBox.Text = "";
                            return;
                        }
                        break;
                    default: //  login correcto
                        ingresar_usuario();
                        break;
                }
            }
        }

        private void ingresar_usuario()
        {
            Usuario user = LoginDAO.Instance.get_usuario_logueado();

            if (user == null)
                return;

            int cantidad_roles = user.roles.Count;

            if (cantidad_roles <= 0)
            {
                MessageBox.Show("No se han encontrado roles asignados al usuario", "Ingreso de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Form form = null;

                if (cantidad_roles == 1) 
                {
                    var rol = (Rol)user.roles[0];
                    form = new menuFuncsRolUserForm(user, rol, true);
                }
                else 
                {
                    form = new SeleccionRolUserForm(user);
                }

                form.Show(this);
                this.Hide();
            }
        }

        private string passwordToEncript()
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passTextBox.Text));
            string passEncripted = bytesDeHasheoToString(bytesDeHasheo);

            return passEncripted;
        }

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");

            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[1].ToString("X2"));
            }

            return salida.ToString();
        }
    }
}
