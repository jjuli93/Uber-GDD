using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using UberFrba.Modelo;
using System.Windows.Forms;

namespace UberFrba.Controllers
{
    class TurnoDAO
    {
        private static readonly TurnoDAO _instance = new TurnoDAO();

        static TurnoDAO() { }
        private TurnoDAO() { }

        public static TurnoDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public DataTable search_turnos(string descripcion)
        {
            DataTable turnos = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_turnos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    turnos = new DataTable();

                    turnos.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException)
            {
                
                //throw;
            }

            return turnos;
        }

        public bool set_turnos_CB(ComboBox combo)
        {
            bool result = true;

            combo.Items.Add(new ObjetosFormCTRL.itemComboBox("", -1));

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_turnos_habilitados", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        while (lector.HasRows)
                        {
                            combo.Items.Add(new ObjetosFormCTRL.itemComboBox(lector["turno_descripcion"].ToString(), Convert.ToInt32(lector["turno_id"])));
                        }
                    }

                    lector.Close();
                }
            }
            catch (SqlException)
            {

                //throw;
            }

            return result;
        }

        public bool crear_turno(Turno nuevo)
        {
            if (nuevo == null)
                return false;

            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_alta_turno", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@horaInicio", nuevo.hora_inicio.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@horaFin", nuevo.hora_fin.ToLongTimeString());
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = nuevo.descripcion;
                    cmd.Parameters.AddWithValue("@valorKM", nuevo.valor_km);
                    cmd.Parameters.AddWithValue("@precioBase", nuevo.precio_base);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en Alta de Turno");
                result = false;
                //throw;
            }

            return result;
        }

        public bool modificar_turno(Turno modificado)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_update_turno", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idTurno", modificado.id);
                    cmd.Parameters.AddWithValue("@horaInicio", modificado.hora_inicio.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@horaFin", modificado.hora_fin.ToLongTimeString());
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = modificado.descripcion;
                    cmd.Parameters.AddWithValue("@valorKM", modificado.valor_km);
                    cmd.Parameters.AddWithValue("@precioBase", modificado.precio_base);
                    cmd.Parameters.AddWithValue("@habilitado", modificado.habilitado);

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

        public bool baja_turno(int turno_id)
        {
            bool result = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_baja_turno", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


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

        public Turno obtener_turno_from_row(DataGridViewRow row)
        {
            Turno turno = null;
            bool error = false;

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null)
                {
                    error = true;
                    break;
                }
            }

            if (error)
            {
                //MessageBox.Show("Error al seleccionar una fila vacia", "Error Seleccion Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            turno = new Turno(Convert.ToInt32(row.Cells["turno_habilitado"].Value));
            turno.descripcion = row.Cells["turno_descripcion"].Value.ToString();
            turno.hora_inicio = Convert.ToDateTime(row.Cells["turno_hora_inicio"].Value);
            turno.hora_fin = Convert.ToDateTime(row.Cells["turno_hora_fin"].Value);
            turno.valor_km = Convert.ToDouble(row.Cells["turno_valor_km"].Value.ToString());
            turno.precio_base = Convert.ToDouble(row.Cells["turno_precio_base"].Value.ToString());

            return turno;
        }

    }
}
