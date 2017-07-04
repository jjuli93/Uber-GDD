using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using UberFrba.Modelo;

namespace UberFrba.Controllers
{
    class RolDAO
    {
        private static readonly RolDAO _instance = new RolDAO();

        static RolDAO() { }
        private RolDAO() { }

        public static RolDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public DataTable get_roles()
        {
            DataTable roles = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_roles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    roles = new DataTable();

                    roles.Load(lector);

                    lector.Close();
                }    
            }
            catch (SqlException)
            {
                
                //throw;
            }

            return roles;
        }

        public bool modificar_rol(Rol rol_modificado)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_update_rol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", rol_modificado.id);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = rol_modificado.nombre;
                    cmd.Parameters.Add("@habilitado", SqlDbType.Bit).Value = Convert.ToInt32(rol_modificado.habilitado);

                    var table = new DataTable();

                    table.Columns.Add("id", typeof(int));

                    foreach (var item in rol_modificado.funcionalidades)
                    {
                        table.Rows.Add(item.id);
                    }

                    var plist = new SqlParameter("@listaFuncionalidades", SqlDbType.Structured);
                    plist.TypeName = "listaIDs";
                    plist.Value = table;

                    cmd.Parameters.Add(plist);

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

        public bool eliminar_rol(int id_rol)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_baja_rol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id_rol);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                
                throw;
            }

            return result;
        }

        internal bool crear_rol(string nombre_rol, List<ObjetosFormCTRL.itemListBox> funcionalidades)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_rol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre_rol;
                    cmd.Parameters.Add("@habilitado", SqlDbType.Bit).Value = 1;

                    var table = new DataTable();

                    table.Columns.Add("id", typeof(int));

                    foreach (ObjetosFormCTRL.itemListBox item in funcionalidades)
                    {
                        table.Rows.Add(item.id_item);
                    }

                    var plist = new SqlParameter("@listaFuncionalidades", SqlDbType.Structured);
                    plist.TypeName = "listaIDs";
                    plist.Value = table;

                    cmd.Parameters.Add(plist);

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

        public Rol obtenerRol(System.Windows.Forms.DataGridViewRow row)
        {
            if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                return null;

            Rol rol = new Rol(Convert.ToInt32(row.Cells[0].Value));

            rol.nombre = row.Cells[1].Value.ToString();
            rol.habilitado = Convert.ToBoolean(row.Cells[2].Value);

            rol.funcionalidades = FuncionalidadDAO.Instance.get_funcionalidades_by_Rol(rol.id);

            return rol;
        }
    }
}
