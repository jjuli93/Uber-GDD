using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Automovil
    {
        public enum Marca 
        {
            Peugeot,
            Fiat,
            Ford,
            Renault,
            Volkswagen,
            Chevrolet,
            No_Identificada
        }

        public Automovil(int _id, string _patente)
        {
            this.id = _id;
            this.patente = _patente;
        }

        public int id { get; private set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string patente { get; set; }
        public int chofer_id { get; set; }
        public string turno { get; set; }
        public bool habilitado { get; set; }

        public string[] get_Marcas_AsArray()
        {
            return Enum.GetNames(typeof(Marca));
        }

        public void set_Marca_from_String(string _marca)
        {
            var lista_marcas = this.get_Marcas_AsArray();
            var marca_default = Marca.No_Identificada.ToString();
            bool encontro = false;

            foreach (string marca in lista_marcas)
            {
                if (marca.Equals(_marca))
                {
                    this.marca = _marca;
                    encontro = true;
                    break;
                }
            }

            if (!encontro)
                this.marca = marca_default;
        }

    }
}
