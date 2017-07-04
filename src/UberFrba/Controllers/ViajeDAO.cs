using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Modelo;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Windows.Forms;

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

        public bool alta_viaje(Viaje nuevo)
        {
            if (nuevo == null)
                return false;

            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_viaje", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idChofer", nuevo.chofer);
                    cmd.Parameters.AddWithValue("@idAuto", nuevo.automovil);
                    cmd.Parameters.AddWithValue("@idTurno", nuevo.turno);
                    cmd.Parameters.AddWithValue("@idCliente", nuevo.cliente);
                    cmd.Parameters.AddWithValue("@cantKM", nuevo.km_viaje);
                    cmd.Parameters.AddWithValue("@horaIn", nuevo.inicio_date);
                    cmd.Parameters.AddWithValue("@horaFin", nuevo.fin_date);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.Message, "Error en Alta de Turno");
                result = false;
                //throw;
            }

            return result;
        }
    }
}
