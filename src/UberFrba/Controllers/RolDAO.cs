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
            DataTable roles = new DataTable();

            using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
            using (SqlCommand cmd = new SqlCommand("DDG.sp_get_roles", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                roles.Load(lector);

                lector.Close();
            }

            return roles;
        }

        public bool modificar_rol(Rol rol_modificado)
        {
            return true;
        }

        public bool eliminar_rol(int id_rol)
        {
            return true;
        }

        internal bool crear_rol(string nombre_rol, System.Windows.Forms.ListBox.SelectedObjectCollection funcionalidades)
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
            Rol rol = new Rol((int)row.Cells[0].Value);

            rol.nombre = row.Cells[1].Value.ToString();
            rol.habilitado = Convert.ToBoolean((int)row.Cells[0].Value);

            rol.funcionalidades = FuncionalidadDAO.Instance.get_funcionalidades_by_Rol(rol.id);

            return rol;
        }
    }
}
