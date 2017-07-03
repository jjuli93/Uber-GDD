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

        public DataTable obtenerAutomoviles(ObjetosFormCTRL.itemComboBox marca, ObjetosFormCTRL.itemComboBox modelo, string patente, string chofer)
        {
            DataTable resultados = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_automoviles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (marca != null)
                        cmd.Parameters.AddWithValue("@idMarca", marca.id_item);
                    else
                        cmd.Parameters.AddWithValue("@idMarca", DBNull.Value);

                    if (modelo != null)
                        cmd.Parameters.AddWithValue("@idmodelo", modelo.id_item);
                    else
                        cmd.Parameters.AddWithValue("@idmodelo", DBNull.Value);

                    if (patente != null)
                        cmd.Parameters.Add("@patente", SqlDbType.VarChar).Value = patente;
                    else
                        cmd.Parameters.AddWithValue("@patente", DBNull.Value);

                    if (chofer != null)
                        cmd.Parameters.AddWithValue("@dniChofer", Convert.ToUInt32(chofer));
                    else
                        cmd.Parameters.AddWithValue("@dniChofer", DBNull.Value);


                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    resultados.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException e)
            {
                System.Console.Out.Write(e.Message);
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

                    var table = new DataTable();

                    table.Columns.Add("id", typeof(int));

                    foreach (var item in nuevo.turnos)
                    {
                        table.Rows.Add(item.id);
                    }

                    var plist = new SqlParameter("@listaTurnos", SqlDbType.Structured);
                    plist.TypeName = "listaIDs";
                    plist.Value = table;

                    cmd.Parameters.Add(plist);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    table.Dispose();
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

                    var table = new DataTable();

                    table.Columns.Add("id", typeof(int));

                    foreach (var item in modificado.turnos)
                    {
                        table.Rows.Add(item.id);
                    }

                    var plist = new SqlParameter("@listaTurnos", SqlDbType.Structured);
                    plist.TypeName = "listaIDs";
                    plist.Value = table;

                    cmd.Parameters.Add(plist);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    table.Dispose();
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

        public Automovil obtener_auto_from_row(int id)
        {
            Automovil auto = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_automovilDetalles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idAuto", id);

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        auto = new Automovil(id, "");

                        if (lector.Read())
                        {
                            auto.marca = lector["marca_descripcion"].ToString();
                            auto.modelo = lector["modelo_descripcion"].ToString();
                            auto.patente = lector["auto_patente"].ToString();
                            auto.nombre_chofer = lector["chofer_nombre"].ToString();
                            auto.apellido_chofer = lector["chofer_apellido"].ToString();
                            auto.licencia = Convert.ToInt32(lector["auto_licencia"]);
                            auto.rodado = lector["auto_rodado"].ToString();
                            auto.habilitado = Convert.ToBoolean(lector["auto_habilitado"]);
                            auto.chofer_id = Convert.ToInt32(lector["chofer_id"]);
                            auto.idmarca = Convert.ToInt32(lector["marca_id"]);
                            auto.idmodelo = Convert.ToInt32(lector["modelo_id"]);
                        }
                    }

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                //throw;
            }

            auto.turnos = TurnoDAO.Instance.get_turnos_automovil(auto.id);

            return auto;
        }

        public Automovil get_automovil_chofer(int id_chofer)
        {
            Automovil auto = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_automovilHabilitado_chofer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idChofer", id_chofer);

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        if (lector.Read())
                        {
                            auto = new Automovil(Convert.ToInt32(lector["auto_id"]), lector["auto_patente"].ToString());
                            auto.chofer_id = Convert.ToInt32(lector["auto_chofer"]);
                            auto.idmodelo = Convert.ToInt32(lector["auto_modelo"]);
                            auto.licencia = Convert.ToInt32(lector["auto_licencia"]);
                            auto.rodado = lector["auto_rodado"].ToString();
                            auto.habilitado = Convert.ToBoolean(lector["auto_habilitado"]);
                        }
                    }

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                //throw;
            }

            return auto;
        }

    }
}
