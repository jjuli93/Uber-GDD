using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using System.Data;
using System.Data.SqlClient;

namespace UberFrba.Controllers
{
    class AutomovilDAO
    {
        private static readonly AutomovilDAO _instance = new AutomovilDAO();

        static AutomovilDAO() { }
        private AutomovilDAO() { }

        public static AutomovilDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public DataTable obtenerAutomoviles(List<string> filtros)
        {
            DataTable resultados = null;

            if (filtros.Count == 0)
            {
                //busca todos *no tiene filtros*
            }
            else
            {
                //busca por filtro
            }

            return resultados;
        }
    }
}
