using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    public class Cliente : Persona
    {
        public Cliente(int _id) : base(_id) {}

        public string codigoPostal { get; set; }
        
    }
}
