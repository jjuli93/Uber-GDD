using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Modelo;

namespace UberFrba.Controllers
{
    class LoginDAO
    {
        private static readonly LoginDAO _instance = new LoginDAO();

        static LoginDAO() { }
        private LoginDAO() { }

        public static LoginDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool loguear_usuario(string _username, string _password)
        {
            /*
             * LLAMAR AL SP de la BD: SP_LOGIN_CHECK(_USERNAME, _PASSWORD)
             * Returns:
             * 0 : si no existe el user
             * 1 : pass incorrecta
             * 2 : login correcto
             * 3 : user bloqueado
             */

            return true;
        }

        public Usuario obtener_usuario(string _username)
        {
            /*
             * Llama el SP : "user = get_usuario(_username)"
             * return user
             */

            /*
             * Llama el SP : "sp_get_roles_usuario(_id_user)"
             * por cada row que me devuelve creo un rol y lo agrego a
             * su lista de roles
             */

            return null;
        }

        public void obtner_funcionalidades(Rol _rol)
        {
            /*
             * llamo a "sp_get_funcionalidades_rol(_rol.id)" 
             * para obtener las funcionalidades
             * y las seteo en _rol.funcionalidades
             */
        }
    }
}
