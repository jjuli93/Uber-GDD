using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Modelo;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace UberFrba.Controllers
{
    class LoginDAO
    {
        private static readonly LoginDAO _instance = new LoginDAO();
        private int intentosLogin = 3;
        private Usuario usuario_logueado = null;

        static LoginDAO() { }
        private LoginDAO() { }

        public static LoginDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public int loguear_usuario(string _username, string _password)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_login_check", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = _username;
                cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = _password;

                SqlParameter returnParameter = cmd.Parameters.Add("@retorno", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                result = (int) cmd.Parameters["@retorno"].Value;
            }

            if (result > 0)
                usuario_logueado = this.obtener_usuario(_username, result);

            return result;
        }

        public Usuario obtener_usuario(string _username, int _id_usuario)
        {            
            Usuario user = new Usuario(_id_usuario, _username, "");

            SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString());
            conn.Open();

            using (SqlCommand sp = new SqlCommand("DDG.sp_get_roles_usuario", conn))
            {
                sp.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@idUsuario", SqlDbType.Decimal);
                param.Value = _id_usuario;
                param.Precision = 10;
                param.Scale = 0;

                sp.Parameters.Add(param);

                SqlDataReader lector2 = sp.ExecuteReader();

                if (lector2.HasRows)
                {
                    while (lector2.Read())
                    {
                        Rol rol = new Rol(Convert.ToInt32(lector2["rol_ID"]));
                        rol.nombre = lector2["rol_nombre"].ToString();
                        rol.habilitado = Convert.ToBoolean(lector2["rol_habilitado"]);
                        user.roles.Add(rol);
                    }
                }

                lector2.Close();
            }

            conn.Close();
            conn.Dispose();

            return user;
        }

        public void obtner_funcionalidades(Rol _rol)
        {
            /*
             * llamo a "sp_get_funcionalidades_rol(_rol.id)" 
             * para obtener las funcionalidades
             * y las seteo en _rol.funcionalidades
             */
        }

        public int get_intentos()
        {
            return this.intentosLogin;
        }

        public Usuario get_usuario_logueado()
        {
            return this.usuario_logueado;
        }
    }
}
