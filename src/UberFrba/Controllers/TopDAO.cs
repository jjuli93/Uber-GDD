using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data;
using UberFrba.Modelo;
using UberFrba.Controllers;
using System.Data.SqlClient;

namespace UberFrba.Controllers
{
    class TopDAO
    {
        private static readonly TopDAO _instance = new TopDAO();

        static TopDAO() { }
        private TopDAO() { }

        public static TopDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        public void fill_consultas_on_ListBox(ListBox list)
        {
            list.Items.Add(new ObjetosFormCTRL.itemListBox("Choferes con mayor recuadación", 1));
            list.Items.Add(new ObjetosFormCTRL.itemListBox("Choferes con el viaje más largo realizado", 2));
            list.Items.Add(new ObjetosFormCTRL.itemListBox("Clientes con mayor consumo", 3));
            list.Items.Add(new ObjetosFormCTRL.itemListBox("Clientes que utilizó más veces el mismo automóvil", 4));
        }

        public void fill_trimestres(ComboBox combo)
        {
            combo.Items.Add(new ObjetosFormCTRL.itemComboBox("1er Trimestre [Ene-Mar]", 1));
            combo.Items.Add(new ObjetosFormCTRL.itemComboBox("2do Trimestre [Abr-Jun]", 2));
            combo.Items.Add(new ObjetosFormCTRL.itemComboBox("3er Trimestre [Jul-Sep]", 3));
            combo.Items.Add(new ObjetosFormCTRL.itemComboBox("4to Trimestre [Oct-Dic]", 4));
        }

        public DataTable consultar_top(int year, int trimestre_id, int consulta_id)
        {
            DataTable resultados = new DataTable();
            string sp = "";

            switch (consulta_id)
            {
                case 1:
                    sp = "DDG.sp_get_choferes_con_mayor_recaudacion";
                    break;
                case 2:
                    sp = "DDG.sp_get_choferes_con_viaje_mas_largo";
                    break;
                case 3:
                    sp = "DDG.sp_get_clientes_con_mayor_consumo";
                    break;
                case 4:
                    sp = "DDG.sp_get_clientes_mayor_uso_mismo_auto";
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(sp))
                return null;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.Instance.getConnectionString()))
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@trimestre", trimestre_id);
                    
                    conn.Open();
                    SqlDataReader lector = cmd.ExecuteReader();

                    resultados.Load(lector);

                    lector.Close();
                }
            }
            catch (SqlException)
            {

                //throw;
            }

            return resultados;
        }
    }
}
