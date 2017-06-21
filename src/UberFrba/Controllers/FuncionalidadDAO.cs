using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Modelo;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

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
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_get_funcionalidades", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Funcionalidad f = new Funcionalidad(Convert.ToInt32(lector["funcionalidad_ID"]));
                        f.descripcion = lector["funcionalidad_descripcion"].ToString();

                        funcionalidades.Add(f);
                    }
                }

                lector.Close();
            }

            return funcionalidades;
        }

        public List<Funcionalidad> get_funcionalidades_by_Rol(int id_rol)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_get_funcionalidades_rol", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idRol", id_rol);

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Funcionalidad f = new Funcionalidad(Convert.ToInt32(lector["funcionalidad_ID"]));
                        f.descripcion = lector["funcionalidad_descripcion"].ToString();

                        funcionalidades.Add(f);
                    }
                }

                lector.Close();
            }

            return funcionalidades;
        }
    }
}
