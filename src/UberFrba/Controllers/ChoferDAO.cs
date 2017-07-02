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
            catch (SqlException)
            {
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
            catch (SqlException)
            {
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
            Chofer chofer = new Chofer((int)row.Cells["chofer_id"].Value);

            chofer.nombre = (string)row.Cells["chofer_nombre"].Value;
            chofer.apellido = (string)row.Cells["chofer_apellido"].Value;
            chofer.fecha_nacimiento = Convert.ToDateTime(row.Cells["chofer_fecha_nacimiento"].Value);
            chofer.dni = Convert.ToUInt32(row.Cells["chofer_dni"].Value);
            chofer.direccion = (string)row.Cells["chofer_direccion"].Value;
            chofer.telefono = Convert.ToUInt32(row.Cells["chofer_telefono"].Value);
            chofer.mail = (string)row.Cells["chofer_email"].Value;
            chofer.habilitado = Convert.ToBoolean(row.Cells["chofer_habilitado"].Value);

            return chofer;
        }

        public DataTable get_choferes(string nombre, string apellido, string dni)
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

    }
}
