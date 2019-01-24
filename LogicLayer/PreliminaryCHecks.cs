using log4net;
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
        public static ILog log = LogManager.GetLogger("LogicLayer");

        public event EventHandler<SWReadynessEventArgs> SWNotReady;
        public event EventHandler<SWReadynessEventArgs> SWReady;

        public class SWReadynessEventArgs : EventArgs
        {
            public bool Ready { get; set; }
            public DateTime TimeReached { get; set; }
        }

        private static PreliminaryChecks _Instance;
        public bool SWStatus { get; set; }

        private PreliminaryChecks()
        {
            SWStatus = false;
        }

        public static PreliminaryChecks Instance()
        {
            if (_Instance == null)
            {
                _Instance = new PreliminaryChecks();
            }
            return _Instance;
        }
        public void StartCheckLoop(int pollingTime)
        {
            log.Info("Start loop");
            var autoEvent = new AutoResetEvent(false);
            var stateTimer = new Timer(this.CheckSWReady,
                                   autoEvent, 0, pollingTime);
            autoEvent.WaitOne();
            // cambio di timing
            stateTimer.Change(0, 5000);
            autoEvent.WaitOne();
            Task.Run(() => StartCheckLoop(pollingTime));
        }

        public void CheckSWReady(object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            log.Debug("Checking...");
            var result = Task.Run(async () => await CheckSWReadyAsync()).Result;
            if (result != SWStatus)
            {
                autoEvent.Set();
                SWStatus = result;
            }
        }

        /// <summary>
        /// Verifica se il SW è pronto per funzionare
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckSWReadyAsync()
        {
            var _return = true;
            // facciamo tutte le verifiche
            _return &= await DBOnlineAsync();

            if (!_return)
            {
                EventHandler<SWReadynessEventArgs> eh = SWNotReady;
                if (eh != null)
                {
                    eh(null, new SWReadynessEventArgs { Ready = _return, TimeReached = DateTime.Now });
                }
            }
            if (_return)
            {
                EventHandler<SWReadynessEventArgs> eh = SWReady;
                if (eh != null)
                {
                    eh(null, new SWReadynessEventArgs { Ready = _return, TimeReached = DateTime.Now });
                }
            }
            return _return;
        }

        private bool DBOnline()
        {
            return Task.Run(async () => await DBOnlineAsync()).Result;
        }

        /// <summary>
        /// Verifica se il DB è on line
        /// </summary>
        /// <returns>true se il DB è on ine, altrimenti false.</returns>
        private async Task<bool> DBOnlineAsync()
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
                log.Warn("Eccezione check DBOnline", ex);
                _return &= false;
            }
            catch (Exception ex)
            {
                log.Error("Eccezione check DBOnline", ex);
                _return &= false;
            }
            log.Info(String.Format("Esito check DBOnline: {0}", _return));
            return _return;
        }
    }
}
