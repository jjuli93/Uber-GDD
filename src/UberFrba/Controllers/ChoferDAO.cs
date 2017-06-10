using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Controllers
{
    class ChoferDAO
    {
        private static readonly ChoferDAO _instance = new ChoferDAO();

        static ChoferDAO() { }
        private ChoferDAO() { }

        public static ChoferDAO Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
