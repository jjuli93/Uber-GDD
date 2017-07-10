using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    class Viaje
    {
        public Viaje(int _id)
        {
            this.id = _id;
        }

        public int id { get; private set; }
        public int chofer { get; set; }
        public int automovil { get; set; }
        public int turno { get; set; }
        public float km_viaje { get; set; }
        public DateTime inicio_date { get; set; }
        public DateTime fin_date { get; set; }
        public int cliente { get; set; }
    }
}
