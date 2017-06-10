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
        private const int CANTIDAD_MAX_INTENTOS = 3;
        private int intentosFallidos = 0;
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
            
                string _password = passTextBox.Text; //ESTO VUELA DESPUES!!!!

                bool existeUser = _username.Equals(userHardcodeado);
                /*
                 * Si existe el usuario en el sistema ya le inicializo
                 * los datos necesarios...ej: habilitado
                 */

                if (existeUser)
                {
                    bool habilitado = true;

                    if (habilitado)
                    {
                        bool verificarPassword = _password.Equals(passHardcodeada);

                        if (verificarPassword)
                        {
                            Usuario usuarioTest = this.crear_usuario_test();
                            //TODO verificar si el usuario tiene 1 solo rol directamente abrir el form de funcionalidades
                            intentosFallidos = 0;
                            SeleccionRolUserForm formSeleccionDeRol = new SeleccionRolUserForm(usuarioTest);
                            formSeleccionDeRol.Show();
                            this.Hide();
                        }
                        else
                        {
                            intentosFallidos++;
                            bool verificoIntentos = intentosFallidos != CANTIDAD_MAX_INTENTOS;

                            if (verificoIntentos)
                            {
                                MessageBox.Show("Contraseña incorrecta, intentos restantes: " + (CANTIDAD_MAX_INTENTOS - intentosFallidos), "Error");
                            }
                            else
                            {
                                MessageBox.Show("Ha superado el numero de intentos de ingreso al sistema. El usuario se ha inhabilitado.", "Error");
                                intentosFallidos = 0; //WARNING: RECONTRA VUELA!!!
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario se encuentra inhabilitado.", "Error");
                    }
                }
                else 
                {
                    MessageBox.Show("El usuario no existe.", "Error");
                }
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

        private Usuario crear_usuario_test()
        {
            Usuario usuarioDeJuguete = new Usuario(-1, userHardcodeado, passHardcodeada);

            Rol rol1 = new Rol(-1);
            rol1.nombre = "Administrador";
            Rol rol2 = new Rol(-2);
            rol2.nombre = "Cliente";

            Funcionalidad f1 = new Funcionalidad(1);
            f1.setNombreDescripcion("ABM_Rol", "Crear, Modificar, Eliminar roles");
            Funcionalidad f2 = new Funcionalidad(2);
            f2.nombre = "ABM_Cliente";
            f2.descripcion = "Crear, Modificar, Eliminar clientes";
            Funcionalidad f3 = new Funcionalidad(3);
            f3.nombre = "ABM_Automovil";
            f3.descripcion = "Crear, Modificar, Eliminar automoviles";
            Funcionalidad f4 = new Funcionalidad(4);
            f4.setNombreDescripcion("ABM_Turno", "Crear, Modificar, Eliminar turnos");
            Funcionalidad f5 = new Funcionalidad(5);
            f5.nombre = "ABM_Chofer";
            f5.descripcion = "Crear, Modificar, Eliminar choferes";
            Funcionalidad f6 = new Funcionalidad(6);
            f6.nombre = "Registro de viaje";
            f6.descripcion = "Funcionalidad que permite registrar un viaje realizado por un chofer";
            Funcionalidad f7 = new Funcionalidad(7);
            f7.setNombreDescripcion("Rendición de Viajes", "Funcionalidad que permite realizar el pago de los viajes que realizó el chofer");
            Funcionalidad f8 = new Funcionalidad(8);
            f8.setNombreDescripcion("Facturacion de Clientes", "Funcionalidad que permite realizar la facturación de todos los viajes que realizó el cliente durante el mes en curso");
            Funcionalidad f9 = new Funcionalidad(9);
            f9.setNombreDescripcion("Listado Estadístico", "Funcionalidad que permite consultar el TOP 5 de cierto objetivo");

            rol1.funcionalidades.Add(f1);
            rol1.funcionalidades.Add(f2);
            rol1.funcionalidades.Add(f3);
            rol1.funcionalidades.Add(f4);
            rol1.funcionalidades.Add(f5);
            rol1.funcionalidades.Add(f6);
            rol1.funcionalidades.Add(f7);
            rol1.funcionalidades.Add(f8);
            rol1.funcionalidades.Add(f9);

            rol2.funcionalidades.Add(f2);

            usuarioDeJuguete.roles.Add(rol1);
            usuarioDeJuguete.roles.Add(rol2);
            
            return usuarioDeJuguete;
        }

    }
}
