﻿using System;
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

                /*
                 * select [columns]
                 * from DDG.Clientes
                 * where cliente_nombre like @nombre
                 *      and cliente_apellido like @apellido
                 *      and cliente_dni = @dni
                 */

                // BUILD SOMEHOW THE PARAMETERS

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                clientes.Load(lector);

                lector.Close();
            }

            return clientes;
        }
    }
}
