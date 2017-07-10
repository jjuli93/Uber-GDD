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

                    if (descripcion != null)
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    else
                        cmd.Parameters.AddWithValue("@descripcion", DBNull.Value);

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

        public List<ObjetosFormCTRL.itemListBox> get_turnos_asList()
        {
            List<ObjetosFormCTRL.itemListBox> turnos = new List<ObjetosFormCTRL.itemListBox>();

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
                        while (lector.Read())
                        {
                            turnos.Add(new ObjetosFormCTRL.itemListBox(lector[3].ToString(), Convert.ToInt32(lector[0])));
                        }
                    }

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
                        while (lector.Read())
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

                    cmd.Parameters.AddWithValue("@horaInicio", nuevo.hora_inicio.TimeOfDay);
                    cmd.Parameters.AddWithValue("@horaFin", nuevo.hora_fin.TimeOfDay);
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = nuevo.descripcion;
                    cmd.Parameters.AddWithValue("@valorKM", nuevo.valor_km);
                    cmd.Parameters.AddWithValue("@precioBase", nuevo.precio_base);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en Alta de Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmd.Parameters.AddWithValue("@horaInicio", modificado.hora_inicio.TimeOfDay);
                    cmd.Parameters.AddWithValue("@horaFin", modificado.hora_fin.TimeOfDay);
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = modificado.descripcion;
                    cmd.Parameters.AddWithValue("@valorKM", modificado.valor_km);
                    cmd.Parameters.AddWithValue("@precioBase", modificado.precio_base);
                    cmd.Parameters.AddWithValue("@habilitado", modificado.habilitado);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error en Modificación de Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmd.Parameters.AddWithValue("@idTurno", turno_id);


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

            turno = new Turno(Convert.ToInt32(row.Cells["ID"].Value));
            turno.descripcion = row.Cells["Descripcion"].Value.ToString();
            turno.hora_inicio = Convert.ToDateTime(row.Cells["Hora_Inicio"].Value.ToString());
            turno.hora_fin = Convert.ToDateTime(row.Cells["Hora_Fin"].Value.ToString());
            turno.valor_km = Convert.ToDouble(row.Cells["Valor_KM"].Value.ToString());
            turno.precio_base = Convert.ToDouble(row.Cells["Precio_Base"].Value.ToString());
            turno.habilitado = Convert.ToBoolean(row.Cells["Habilitado"].Value);

            return turno;
        }

        public List<Turno> get_turnos_automovil(int id_auto)
        {
            var turnos = new List<Turno>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand("DDG.sp_get_turnos_automovil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idAuto", id_auto);

                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            Turno nuevo = new Turno(Convert.ToInt32(lector["turno_id"]));

                            nuevo.descripcion = lector["turno_descripcion"].ToString();

                            nuevo.hora_inicio += (TimeSpan)lector["turno_hora_inicio"];
                            nuevo.hora_fin += (TimeSpan)lector["turno_hora_fin"];

                            turnos.Add(nuevo);
                        }
                    }

                    lector.Close();
                }
            }
            catch (SqlException)
            {

                //throw;
            }

            return turnos;
        }

    }
}
