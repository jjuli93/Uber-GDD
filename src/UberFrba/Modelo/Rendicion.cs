using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    class Rendicion
    {
        public Rendicion(int _id)
        {
            this.id = _id;
        }

        public int id { get; private set; }
        public DateTime fecha { get; set; }
        public int chofer { get; set; }
        public int turno { get; set; }


        public float calcular_importe()
        {
            return 111;
        }
    }
}
