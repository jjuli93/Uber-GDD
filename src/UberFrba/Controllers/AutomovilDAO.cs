using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using System.Data;
using System.Data.SqlClient;
using UberFrba.Modelo;

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

        public DataTable obtenerAutomoviles(int marca, int modelo, string patente, string chofer)
        {
            DataTable resultados = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_automoviles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idMarca", marca);
                    cmd.Parameters.AddWithValue("@idModelo", modelo);
                    cmd.Parameters.Add("@patente", SqlDbType.VarChar).Value = patente;
                    cmd.Parameters.AddWithValue("@dniChofer", Convert.ToDouble(chofer));

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    resultados.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                //throw;
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

        public bool alta_automovil(Automovil nuevo)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_automovil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idchofer", nuevo.chofer_id);
                    cmd.Parameters.AddWithValue("@idmodelo", nuevo.idmodelo);
                    cmd.Parameters.Add("@patente", SqlDbType.VarChar).Value = nuevo.patente;
                    cmd.Parameters.Add("@licencia", SqlDbType.VarChar).Value = nuevo.licencia.ToString();
                    cmd.Parameters.Add("@rodado", SqlDbType.VarChar).Value = nuevo.rodado;
                    //cmd.Parameters.AddWithValue("@idmarca", nuevo.idmarca);
                    cmd.Parameters.AddWithValue("@idturno", nuevo.idturno);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en alta automovil");
                result = false;
                //throw;
            }

            return result;
        }

        public bool modificacion_automovil(Automovil modificado)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_update_automovil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", modificado.id);
                    cmd.Parameters.AddWithValue("@idchofer", modificado.chofer_id);
                    cmd.Parameters.AddWithValue("@idmodelo", modificado.idmodelo);
                    cmd.Parameters.Add("@patente", SqlDbType.VarChar).Value = modificado.patente;
                    cmd.Parameters.Add("@licencia", SqlDbType.VarChar).Value = modificado.licencia.ToString();
                    cmd.Parameters.Add("@rodado", SqlDbType.VarChar).Value = modificado.rodado;
                    cmd.Parameters.AddWithValue("@habilitado", Convert.ToInt32(modificado.habilitado));
                    cmd.Parameters.AddWithValue("@idturno", modificado.idturno);
                    //cmd.Parameters.AddWithValue("@idmarca", modificado.idmarca);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                result = false;
                //throw;
            }

            return result;
        }

        public bool baja_automovil(int id_auto)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_baja_automovil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idauto", id_auto);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                //throw;
            }

            return result;
        }

        public Automovil obtener_auto_from_row(System.Windows.Forms.DataGridViewRow row)
        {
            Automovil auto = null;
            bool hay_nulo = false;

            foreach (var item in row.Cells)
            {
                if (item == null)
                    hay_nulo = true;
            }

            if (hay_nulo)
                return auto;

            auto = new Automovil(Convert.ToInt32(row.Cells[0].Value), row.Cells[3].Value.ToString());
            auto.idmodelo = Convert.ToInt32(row.Cells[2].Value);
            auto.licencia = Convert.ToInt32(row.Cells[4].Value);
            auto.rodado = row.Cells[5].Value.ToString();
            auto.habilitado = Convert.ToBoolean(row.Cells[6].Value);
            

            return auto;
        }

    }
}
