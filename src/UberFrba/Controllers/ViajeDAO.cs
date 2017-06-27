using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Controllers
{
    class ViajeDAO
    {
        private static readonly ViajeDAO _instance = new ViajeDAO();

        static ViajeDAO() { }
        private ViajeDAO() { }

        public static ViajeDAO Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
