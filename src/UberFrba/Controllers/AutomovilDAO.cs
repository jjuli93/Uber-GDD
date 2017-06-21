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

        public void setMarcas(ComboBox combo)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_get_marcas", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        combo.Items.Add(new ObjetosFormCTRL.itemComboBox(lector["marca_descripcion"].ToString(), Convert.ToInt32(lector["marca_id"])));
                    }
                }

                lector.Close();
            }
        }

        public void setModelos(ComboBox combo, int id_marca)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_get_modelos_marca", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMarca", id_marca);

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        combo.Items.Add(new ObjetosFormCTRL.itemComboBox(lector["modelo_descripcion"].ToString(), Convert.ToInt32(lector["modelo_id"])));
                    }
                }

                lector.Close();
            }
        }

    }
}
