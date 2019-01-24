using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;

namespace LogicLayer.PLC
{
    public class Plc
    {
        public PlcEmulator RealPlc { get; set; }

        private ISubject<PlcMessage> _plcMessages;
        private Timer _pollingTimer;
        private int _pollingTime;
        private DateTime _prevTime;
        private TimeSpan _timeThreshold;
        private bool _prevState;

        public Plc(int pollingTime, TimeSpan timeThreshold)
        {
            _pollingTime = pollingTime;
            _timeThreshold = timeThreshold;
            _pollingTimer = new Timer(CheckPlc, null, 0, _pollingTime);
            _plcMessages = new Subject<PlcMessage>();
        }

        public IObservable<PlcMessage> PlcMessages()
        {
            return _plcMessages.AsObservable();
        }

        private void CheckPlc(object state)
        {
            if (RealPlc != null)
            {
                var plcState = RealPlc.BitPlcPowerOn;
                var now = DateTime.Now;
                if (plcState != _prevState)
                {
                    _prevState = plcState;
                    _prevTime = now;
                }
                else
                {
                    if ((now - _prevTime) > _timeThreshold)
                    {
                        PlcMessage message = new PlcMessage()
                        {
                            Message = String.Format("RealPlc {0} not responding", RealPlc.Name)
                        };
                        _plcMessages.OnNext(message);
                    }
                }
            }
        }
    }
}
