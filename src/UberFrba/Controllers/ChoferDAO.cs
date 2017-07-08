using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using UberFrba.Modelo;
using UberFrba.Controllers;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public bool crear_chofer(Chofer chofer)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_chofer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = chofer.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = chofer.apellido;
                    cmd.Parameters.Add("@fechanac", SqlDbType.Date).Value = chofer.fecha_nacimiento;
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = chofer.dni;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = chofer.direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = chofer.telefono;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = chofer.mail;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en Alta de Chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
                //throw;
            }

            return result;
        }

        public bool modificar_chofer(Chofer chofer)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_update_chofer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = chofer.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = chofer.apellido;
                    cmd.Parameters.Add("@fechanac", SqlDbType.Date).Value = chofer.fecha_nacimiento;
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = chofer.dni;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = chofer.direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = chofer.telefono;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = chofer.mail;
                    cmd.Parameters.AddWithValue("@habilitado", chofer.habilitado);
                    cmd.Parameters.AddWithValue("@idChofer", chofer.id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en Modificación de Chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
                //throw;
            }

            return result;
        }

        public bool eliminar_chofer(int id_chofer)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_baja_chofer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idchofer", id_chofer);

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

        public Chofer obtener_cliente_from_row(System.Windows.Forms.DataGridViewRow row)
        {
            Chofer chofer = new Chofer(Convert.ToInt32(row.Cells["chofer_id"].Value));

            chofer.nombre = row.Cells["chofer_nombre"].Value.ToString();
            chofer.apellido = row.Cells["chofer_apellido"].Value.ToString();
            chofer.fecha_nacimiento = Convert.ToDateTime(row.Cells["chofer_fecha_nacimiento"].Value);
            chofer.dni = Convert.ToUInt32(row.Cells["chofer_dni"].Value);
            chofer.direccion = row.Cells["chofer_direccion"].Value.ToString();
            chofer.telefono = Convert.ToUInt32(row.Cells["chofer_telefono"].Value);
            chofer.mail = row.Cells["chofer_email"].Value.ToString();
            chofer.habilitado = Convert.ToBoolean(row.Cells["chofer_habilitado"].Value);

            return chofer;
        }

        public DataTable get_choferes(string nombre, string apellido, string dni, string habilitados, string conAutohabilitado)
        {
            DataTable choferes = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_choferes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (nombre != null)
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    else
                        cmd.Parameters.AddWithValue("@nombre", DBNull.Value);
                    
                    if (apellido != null)
                        cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
                    else
                        cmd.Parameters.AddWithValue("@apellido", DBNull.Value);

                    if (dni != null)
                    {
                        UInt32 dni_num = 0;

                        if (UInt32.TryParse(dni, out dni_num))
                            cmd.Parameters.AddWithValue("@dni", dni_num);
                        else
                            cmd.Parameters.AddWithValue("@dni", DBNull.Value);
                    }
                    else
                        cmd.Parameters.AddWithValue("@dni", DBNull.Value);

                    if (habilitados == "SI")
                        cmd.Parameters.AddWithValue("@habilitado", 1);
                    else
                        cmd.Parameters.AddWithValue("@habilitado", DBNull.Value);

                    if (conAutohabilitado == "SI")
                        cmd.Parameters.AddWithValue("@conAutohabilitado", 1);
                    else
                        cmd.Parameters.AddWithValue("@conAutohabilitado", DBNull.Value);

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    choferes = new DataTable();
                    choferes.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException)
            {

                //throw;
            }

            return choferes;
        }

        public int realizar_rendicion(int id_chofer, DateTime fecha, int id_turno)
        {
            int id_rendicion = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_rendicion", conn))
                {

                    //[ddg].sp_alta_rendicion (@idChofer numeric(10,0), @fecha date, @idTurno numeric(10,0),  @retorno int output) as

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idChofer", id_chofer);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                    cmd.Parameters.AddWithValue("@idTurno", id_turno);

                    SqlParameter returnParameter = cmd.Parameters.Add("@retorno", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    id_rendicion = (int)cmd.Parameters["@retorno"].Value;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en alta rendición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                id_rendicion = -1;   
                //throw;
            }

            return id_rendicion;
        }

        public int get_importe_rendicion(int id_rendicion)
        {
            int importe = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_importe_rendicion", conn))
                {
                    //[DDG].sp_get_importe_rendicion (@idRendicion numeric(10,0)) as
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idFactura", id_rendicion);
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        if (lector.Read())
                        {
                            importe = Convert.ToInt32(lector["rendicion_importe"]);
                        }
                    }

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                importe = 1;
                //throw;
            }

            return importe;
        }

        public DataTable get_viajes_chofer(int id_rendicion)
        {
            DataTable viajes = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_viajes_factura", conn))
                {
                    //[ddg].sp_get_viajes_rendicion(@idRendicion numeric(10,0)) as
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRendicion", id_rendicion);

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        viajes = new DataTable();
                        viajes.Load(lector);
                    }
                     

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                
                //throw;
            }

            return viajes;
        }
    }
}
