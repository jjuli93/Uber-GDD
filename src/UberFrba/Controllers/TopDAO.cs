using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Controllers
{
    class TopDAO
    {
        private static readonly TopDAO _instance = new TopDAO();

        static TopDAO() { }
        private TopDAO() { fill_consultas(); }

        public static TopDAO Instance
        {
            get
            {
                return _instance;
            }
        }

        List<ObjetosFormCTRL.itemComboBox> consultas = new List<ObjetosFormCTRL.itemComboBox>();

        private void fill_consultas()
        {
            consultas.Add(new ObjetosFormCTRL.itemComboBox("", -1));
            consultas.Add(new ObjetosFormCTRL.itemComboBox("Choferes con mayor recuadación", 1));
            consultas.Add(new ObjetosFormCTRL.itemComboBox("Choferes con el viaje más largo realizado", 2));
            consultas.Add(new ObjetosFormCTRL.itemComboBox("Clientes con mayor consumo", 3));
            consultas.Add(new ObjetosFormCTRL.itemComboBox("Clientes que utilizó más veces el mismo automóvil", 4));
        }
    }
}
