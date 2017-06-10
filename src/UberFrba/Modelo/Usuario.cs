using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Usuario
    {
        public int id { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public Byte intentos_login { get; set; }
        public bool habilitado { get; set; }
        public List<Rol> roles;

        public Usuario(int _id, string _username, string _password)
        {
            this.id = _id;
            this.username = _username;
            this.password = _password;
            this.habilitado = true;

            roles = new List<Rol>();
        }
    }
}
