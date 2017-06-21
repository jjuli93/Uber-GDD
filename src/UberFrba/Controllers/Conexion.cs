using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;

namespace UberFrba.Controllers
{
    class Conexion
    {
        private static readonly Conexion _instance = new Conexion();

        static Conexion() { }
        private Conexion() { }

        public static Conexion Instance
        {
            get
            {
                return _instance;
            }
        }

        //private static string connectionString = ConfigurationManager.AppSettings["UberFrba.Properties.Settings.GD1C2017ConnectionString"];
        private static string connectionString = ConfigurationManager.ConnectionStrings["UberFrba.Properties.Settings.GD1C2017ConnectionString"].ConnectionString;


        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
