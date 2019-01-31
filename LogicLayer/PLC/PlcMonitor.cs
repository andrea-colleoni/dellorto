using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using log4net;

namespace LogicLayer.PLC
{
    public class PlcMonitor
    {
        public static ILog log = LogManager.GetLogger("DesktopWinForms");

        public PlcEmulator PlcEmulator { get; set;  }
        public HardwarePlc RealPlc { get; set; }
        public string Name
        {
            get
            {
                return PlcEmulator.Name;
            }
        }
        public string IP
        {
            get
            {
                return (Emulazione ? PlcEmulator.IP : RealPlc.IP);
            }
        }
        public bool Acceso { get; set; }
        public bool Emulazione { get; set; }

        // eventi broadcast
        private ISubject<PlcStatus> _plcStatus;
        private ISubject<bool> _plcBit;
        private ISubject<TimeSpan> _plcTimeElapsedSinceLastBitChange;

        private Timer _pollingTimer;
        private int _pollingTime;
        private Timer _notificationTimer;
        private int _notificationTime;
        private DateTime _prevTime;
        private TimeSpan _timeThreshold;
        private bool _prevBitState;
        private PlcStatus _prevStatus;

        public PlcMonitor(int pollingTime, int notificationTime, TimeSpan timeThreshold)
        {
            _pollingTime = pollingTime;
            _notificationTime = notificationTime;
            _timeThreshold = timeThreshold;

            //_plcMessages = new Subject<PlcMessage>();
            _plcStatus = new Subject<PlcStatus>();
            _plcBit = new Subject<bool>();
            _plcTimeElapsedSinceLastBitChange = new Subject<TimeSpan>();
        }
        public void StartMonitor()
        {
            log.Info("avvio monitoraggio");
            _prevTime = DateTime.Now;
            _pollingTimer = new Timer(CheckPlc, null, 0, _pollingTime);
            _notificationTimer = new Timer(NotifyTimeElapsed, null, 0, _notificationTime);
            Acceso = true;
        }
        public void StopMonitor()
        {
            log.Info("arresto monitoraggio");
            _pollingTimer = null;
            _notificationTimer = null;
            Acceso = false;
        }
        private void NotifyTimeElapsed(object state)
        {
            if (Acceso)
            {
                TimeSpan ts = DateTime.Now - _prevTime;
                log.Debug($"tempo trascorso: {ts.TotalMilliseconds} millis");
                _plcTimeElapsedSinceLastBitChange.OnNext(ts);
            }
        }

        public IObservable<PlcStatus> PlcStatus()
        {
            return _plcStatus.AsObservable();
        }
        public IObservable<bool> PlcBit()
        {
            return _plcBit.AsObservable();
        }
        public IObservable<TimeSpan> PlcTimeElapsedSinceLastBitChange()
        {
            return _plcTimeElapsedSinceLastBitChange.AsObservable();
        }

        private void CheckPlc(object state)
        {
            if (Acceso && Emulazione && PlcEmulator != null)
            {
                var plcBitState = PlcEmulator.BitPlcPowerOn;
                log.Info($"bit letto in EMULAZIONE: {plcBitState}");
                evaluateStateBit(plcBitState);
            }
            else if (Acceso && !Emulazione && RealPlc != null)
            {
                log.Debug($"lettura in REAL da {IP}");
                var plcBitState = RealPlc.ReadPowerOn();
                log.Info($"bit letto in REAL da {IP}: {plcBitState}");
                if (plcBitState != null)
                {
                    evaluateStateBit(plcBitState.Value);
                }
                else
                {
                    evaluateStateBit(_prevBitState, false);
                }
            }
        }

        private void evaluateStateBit(bool stateBit, bool unknownValue = false)
        {
            var now = DateTime.Now;
            if (stateBit != _prevBitState)
            {
                log.Info($"cambio stato: da {_prevBitState} a {stateBit}");
                _prevBitState = stateBit;
                _prevTime = now;
                _plcBit.OnNext(stateBit);
                if (_prevStatus != PLC.PlcStatus.Ok)
                {
                    log.Warn($"rientro dallo stato di allerta: da {_prevStatus} a {PLC.PlcStatus.Ok}");
                    _prevStatus = PLC.PlcStatus.Ok;
                    _plcStatus.OnNext(_prevStatus);
                }
            }
            else
            {
                log.Debug($"check threshold");
                TimeSpan ts = (now - _prevTime);
                if (ts > _timeThreshold)
                {
                    log.Warn($"soglia superata da {ts.TotalMilliseconds} millis");
                    if (_prevStatus == PLC.PlcStatus.Ok)
                    {
                        _prevStatus = (unknownValue ? PLC.PlcStatus.NotResponding : PLC.PlcStatus.ThresholdReached);
                        _plcStatus.OnNext(_prevStatus);
                    }
                }
            }
        }
    }
}
