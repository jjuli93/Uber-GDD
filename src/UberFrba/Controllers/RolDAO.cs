using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Controllers
{
    class RolDAO
    {
        private static readonly RolDAO _instance = new RolDAO();

        static RolDAO() { }
        private RolDAO() { }

        public static RolDAO Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
