using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Turno
    {
        public Turno(int _id)
        {
            this.id = _id;
            this.habilitado = true;
        }

        public int id { get; private set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public string descripcion { get; set; }
        public float valor_km { get; set; }
        public float precio_base { get; set; }
        public bool habilitado { get; set; }
    }
}
