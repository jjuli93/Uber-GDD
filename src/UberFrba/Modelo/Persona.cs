using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Persona
    {

        public Persona(int _id)
        {
            this.id = _id;
            this.habilitado = true;
        }

        public int id { get; private set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public double dni { get; set; }
        public string mail { get; set; }
        public double telefono { get; set; }
        public string direccion { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public bool habilitado { get; set; }

        public void set_datos_principales(string _nombre, string _apellido, double _dni, DateTime _fechaNac)
        {
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.dni = _dni;
            this.fecha_nacimiento = _fechaNac;
        }

        public void set_datos_secundarios(string _mail, double _telefono, string _direccion)
        {
            this.mail = _mail;
            this.telefono = _telefono;
            this.direccion = _direccion;
        }

    }
}
