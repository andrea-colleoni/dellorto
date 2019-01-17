using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PreliminaryChecks
    {
        /// <summary>
        /// Verifica se il SW è pronto per funzionare
        /// </summary>
        /// <returns></returns>
        public static bool CheckSWReady()
        {
            var _return = true;
            // facciamo tutte le verifiche
            _return &= DBOnline();

            return _return;
        }

        /// <summary>
        /// Verifica se il DB è on line
        /// </summary>
        /// <returns>true se il DB è on ine, altrimenti false.</returns>
        private static bool DBOnline()
        {
            var _return = true;
            var conn = DBManager.getConnection();
            _return &= (conn != null) && conn.State == System.Data.ConnectionState.Open;
            return _return;
        }
    }
}
