using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Automovil
    {
        public Automovil(int _id, string _patente)
        {
            this.id = _id;
            this.patente = _patente;
            this.habilitado = true;
        }

        public int id { get; private set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string patente { get; set; }
        public int chofer_id { get; set; }
        public List<Turno> turnos { get; set; }
        public bool habilitado { get; set; }
        public int idmodelo { get; set; }
        public int idmarca { get; set; }
        public int licencia { get; set; }
        public string rodado { get; set; }
        public string nombre_chofer { get; set; }
        public string apellido_chofer { get; set; }

    }
}
