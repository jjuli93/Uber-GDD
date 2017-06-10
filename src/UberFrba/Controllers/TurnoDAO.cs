using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Controllers
{
    class TurnoDAO
    {
        private static readonly TurnoDAO _instance = new TurnoDAO();

        static TurnoDAO() { }
        private TurnoDAO() { }

        public static TurnoDAO Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
