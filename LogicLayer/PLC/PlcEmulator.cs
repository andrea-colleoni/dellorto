using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace LogicLayer.PLC
{
    public class PlcEmulator
    {
        public bool BitPlcPowerOn { get; set; }
        public string Name { get; }

        private ISubject<bool> _bitPower;
        private const int SWITCH_TIME_MS = 500;
        private bool _acceso;
        private Timer timer;

        public PlcEmulator(string name)
        {
            _acceso = false;
            Name = name;
            timer = new Timer(switchBit, null, 0, SWITCH_TIME_MS);
            _bitPower = new Subject<bool>();
        }

        public void accendi()
        {
            _acceso = true;
        }

        public void spegni()
        {
            _acceso = false;
        }
        public IObservable<bool> PowerObservable()
        {
            return _bitPower.AsObservable();
        }

        private void switchBit(object state)
        {
            if (_acceso)
            {
                this.BitPlcPowerOn = !this.BitPlcPowerOn;
                _bitPower.OnNext(this.BitPlcPowerOn);
            }
        }
    }
}
