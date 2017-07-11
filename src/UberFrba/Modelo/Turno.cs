using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Controllers;

namespace UberFrba.Modelo
{
    public class Turno
    {
        public Turno(int _id)
        {
            this.id = _id;
            this.habilitado = true;
            this.hora_fin = Conexion.Instance.getFecha();
            this.hora_inicio = Conexion.Instance.getFecha();
        }

        public int id { get; private set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public string descripcion { get; set; }
        public double valor_km { get; set; }
        public double precio_base { get; set; }
        public bool habilitado { get; set; }
    }
}
