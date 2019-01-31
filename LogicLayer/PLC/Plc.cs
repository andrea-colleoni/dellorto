using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.Diagnostics;

namespace LogicLayer.PLC
{
    public class Plc
    {
        public PlcEmulator RealPlc { get; set;  }
        public string Name
        {
            get
            {
                return RealPlc.Name;
            }
        }
        public string IP
        {
            get
            {
                return RealPlc.IP;
            }
        }
        public bool Acceso { get; set; }

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

        public Plc(int pollingTime, int notificationTime, TimeSpan timeThreshold)
        {
            _pollingTime = pollingTime;
            _notificationTime = notificationTime;
            _timeThreshold = timeThreshold;

            //_plcMessages = new Subject<PlcMessage>();
            _plcStatus = new Subject<PlcStatus>();
            _plcBit = new Subject<bool>();
            _plcTimeElapsedSinceLastBitChange = new Subject<TimeSpan>();

            _pollingTimer = new Timer(CheckPlc, null, 0, _pollingTime);
            _notificationTimer = new Timer(NotifyTimeElapsed, null, 0, _notificationTime);

        }

        private void NotifyTimeElapsed(object state)
        {
            if (Acceso)
            {
                TimeSpan ts = DateTime.Now - _prevTime;
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
            if (RealPlc != null)
            {
                var plcBitState = RealPlc.BitPlcPowerOn;
                var now = DateTime.Now;
                if (plcBitState != _prevBitState)
                {
                    _prevBitState = plcBitState;
                    _prevTime = now;
                    _plcBit.OnNext(plcBitState);
                    if(_prevStatus != PLC.PlcStatus.Ok)
                    {
                        _prevStatus = PLC.PlcStatus.Ok;
                        _plcStatus.OnNext(_prevStatus);
                    }
                }
                else
                {
                    if ((now - _prevTime) > _timeThreshold)
                    {
                        if (_prevStatus == PLC.PlcStatus.Ok)
                        {
                            _prevStatus = PLC.PlcStatus.ThresholdReached;
                            _plcStatus.OnNext(_prevStatus);
                        }
                    }
                }
            }
        }
    }
}
