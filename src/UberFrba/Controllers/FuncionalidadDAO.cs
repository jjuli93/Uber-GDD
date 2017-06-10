using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Modelo;

namespace UberFrba.Controllers
{
    class FuncionalidadDAO
    {
        private static readonly FuncionalidadDAO _instance = new FuncionalidadDAO();

        static FuncionalidadDAO() { }
        private FuncionalidadDAO() { }

        public static FuncionalidadDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Funcionalidad> get_funcionalidades()
        {
            //Se conecta a la base y le pide todas las funcionalidades del sistema
            return null;
        }
    }
}
