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
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = cliente.dni;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                    cmd.Parameters.Add("@codpost", SqlDbType.Decimal).Value = cliente.codigoPostal;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = cliente.telefono;
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
            bool result = true;

            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            //    using (SqlCommand cmd = new SqlCommand("DDG.sp_update_cliente", conn))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.AddWithValue("@idcliente", cliente.id);
                    
            //        //definir bien como va a hacer para modificar

            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //    }
            //}
            //catch (SqlException)
            //{
            //    result = false;
            //    //throw;
            //}

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
            Cliente cliente = new Cliente((int)row.Cells[0].Value);

            //fill up da shit

            return cliente;
        }

        public DataTable get_clientes()
        {
            DataTable clientes = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_clientes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public DataTable get_clientes_with_parameters(string nombre, string apellido, double dni)
        {
            DataTable clientes = new DataTable();

            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_get_clientes", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                clientes.Load(lector);

                lector.Close();
            }

            return clientes;
        }

        public int realizarFacturacion(int id_cliente)
        {
            int importe = 0;

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

            try
            {

            }
            catch (SqlException)
            {
                importe = -1;
                //throw;
            }

            return importe;
        }

        public DataTable obtenerViajes(int id_cliente)
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
