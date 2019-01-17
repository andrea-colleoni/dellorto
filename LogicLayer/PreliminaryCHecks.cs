using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PreliminaryChecks
    {
        public static event EventHandler<SWNotReadyEventArgs> SWNotReady;

        public class SWNotReadyEventArgs : EventArgs
        {
            public bool Ready { get; set; }
            public DateTime TimeReached { get; set; }
        }

        private static bool LoopRunning = false;
        public static void StartCheckLoop(int pollingTime)
        {
            Debug.WriteLine("Start loop");
            LoopRunning = true;
            while(LoopRunning)
            {
                CheckSWReadyAsync();
                Thread.Sleep(pollingTime);
            }
        }
        public static void StopCheckLoop()
        {
            Debug.WriteLine("Stop loop");
            LoopRunning = false;
        }

        public static bool CheckSWReady()
        {
            return Task.Run(async () => await CheckSWReadyAsync()).Result;
        }

        /// <summary>
        /// Verifica se il SW è pronto per funzionare
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CheckSWReadyAsync()
        {
            var _return = true;
            // facciamo tutte le verifiche
            _return &= await DBOnlineAsync();

            Debug.WriteLine("Status: {0}", _return);
            if (!_return)
            {
                EventHandler<SWNotReadyEventArgs> eh = SWNotReady;
                if (eh != null)
                {
                    eh(null, new SWNotReadyEventArgs { Ready = _return, TimeReached = DateTime.Now });
                }
            }
            return _return;
        }

        private static bool DBOnline()
        {
            return Task.Run(async () => await DBOnlineAsync()).Result;
        }

        /// <summary>
        /// Verifica se il DB è on line
        /// </summary>
        /// <returns>true se il DB è on ine, altrimenti false.</returns>
        private static async Task<bool> DBOnlineAsync()
        {
            var _return = true;
            try
            {
                using (var conn = DBManager.getConnection())
                {
                    using (var cmd = new SqlCommand("select 1", conn))
                    {
                        await conn.OpenAsync();
                        await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                _return &= false;
            }
            catch (Exception ex)
            {
                _return &= false;
            }
            return _return;
        }
    }
}
