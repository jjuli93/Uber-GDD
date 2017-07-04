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

        public bool crear_cliente(Cliente cliente)
        {
            if (cliente == null)
                return false;

            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_cliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
                    cmd.Parameters.Add("@fechanac", SqlDbType.Date).Value = cliente.fecha_nacimiento;
                    //cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = cliente.dni;
                    cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(cliente.dni));
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                    //cmd.Parameters.Add("@codpost", SqlDbType.Decimal).Value = cliente.codigoPostal;
                    cmd.Parameters.AddWithValue("@codpost", Convert.ToInt32(cliente.codigoPostal));
                    //cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = cliente.telefono;
                    cmd.Parameters.AddWithValue("@telefono", Convert.ToInt32(cliente.telefono));
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.mail;

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

        public bool modificar_cliente(Cliente cliente)
        {
            if (cliente == null)
                return false;

            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_update_cliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
                    cmd.Parameters.Add("@fechaNacimiento", SqlDbType.Date).Value = cliente.fecha_nacimiento;
                    //cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = cliente.dni;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                    cmd.Parameters.Add("@codPostal", SqlDbType.Decimal).Value = cliente.codigoPostal;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = cliente.telefono;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.mail;
                    cmd.Parameters.AddWithValue("@habilitado", cliente.habilitado);
                    cmd.Parameters.AddWithValue("@idcliente", cliente.id);

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

        public bool eliminar_cliente(int id_cliente)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_baja_cliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idcliente", id_cliente);

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

        public Cliente obtener_cliente_from_row(System.Windows.Forms.DataGridViewRow row)
        {
            Cliente cliente = new Cliente(Convert.ToInt32(row.Cells["cliente_id"].Value));

            cliente.nombre = row.Cells["cliente_nombre"].Value.ToString();
            cliente.apellido = row.Cells["cliente_apellido"].Value.ToString();
            cliente.fecha_nacimiento = Convert.ToDateTime(row.Cells["cliente_fecha_nacimiento"].Value);
            cliente.dni = Convert.ToUInt32(row.Cells["cliente_dni"].Value);
            cliente.direccion = row.Cells["cliente_direccion"].Value.ToString();

            var cod_post = row.Cells["cliente_codigo_postal"].Value.ToString();

            if (string.IsNullOrEmpty(cod_post))
                cliente.codigoPostal = 0;
            else
                cliente.codigoPostal = Convert.ToInt32(cod_post);

            cliente.telefono = Convert.ToUInt32(row.Cells["cliente_telefono"].Value);
            cliente.mail = row.Cells["cliente_email"].Value.ToString();
            cliente.habilitado = Convert.ToBoolean(row.Cells["cliente_habilitado"].Value);

            return cliente;
        }

        public DataTable get_clientes(string nombre, string apellido, string dni)
        {
            DataTable clientes = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_clientes", conn))
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

                    clientes = new DataTable();
                    clientes.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                
                //throw;
            }

            return clientes;
        }

        /*
           * Creo que lo mejor es hacer lo siguiente:
           * 
           * 1) llamar esta funcion, que realice la facturacion (sp_alta_factura) 
           *      y que devuelva el id de factura
           *      
           * 2) luego llamar otra funcion (ej: obtenerImporte(id_factura)) 
           *      -> (sp_calcular_importe @id_factura) -> devuelve el importe
           *      
           * 3) finalmente llamar obtenerViajes donde tambien le paso el id_factura
           *      -> (sp_get_viajes_facturados @id_factura)
           */

        public int realizarFacturacion(int id_cliente, DateTime hora_inicio, DateTime hora_fin)
        {
            int id_factura = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_factura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlParameter returnParameter = cmd.Parameters.Add("@id_factura", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    id_factura = (int)cmd.Parameters["@id_factura"].Value;
                }
            }
            catch (SqlException)
            {
                id_factura = -1;
                //throw;
            }

            return id_factura;
        }

        public int obtener_importe(int id_factura)
        {
            int importe = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_importe", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_factura", id_factura);
                    SqlParameter returnParameter = cmd.Parameters.Add("@importe", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    importe = (int)cmd.Parameters["@importe"].Value;
                }
            }
            catch (SqlException)
            {
                return -1;
                //throw;
            }

            return importe;
        }

        public DataTable obtenerViajes(int id_factura)
        {
            DataTable viajes = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    viajes.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                return null;
                //throw;
            }

            return viajes;
        }
    }
}
