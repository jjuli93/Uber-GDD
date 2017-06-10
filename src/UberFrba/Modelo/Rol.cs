using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Rol
    {
        public Rol(int _id)
        {
            this.id = _id;
            funcionalidades = new List<Funcionalidad> {};
            habilitado = true;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool habilitado { get; set; }
        public List<Funcionalidad> funcionalidades;
    }
}
