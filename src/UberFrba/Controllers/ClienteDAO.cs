using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Controllers
{
    class ClienteDAO
    {
        private static readonly ClienteDAO _instance = new ClienteDAO();

        static ClienteDAO() { }
        private ClienteDAO() { }

        public static ClienteDAO Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
