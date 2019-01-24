using System;
using System.Windows.Forms;
using LogicLayer.PLC;

namespace DesktopWinForms
{
    public partial class ctRealPlc : UserControl
    {
        internal class BoolObserver : IObserver<bool>
        {
            Control _ctl;

            internal BoolObserver(Control ctl)
            {
                _ctl = ctl;
            }
            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public void OnNext(bool value)
            {
                _ctl.Invoke(new Action(() => _ctl.Text = value.ToString()));
            }
        }
        private PlcEmulator _RealPlc;
        public PlcEmulator RealPlc
        {
            get
            {
                return _RealPlc;
            }
            set
            {
                _RealPlc = value;
                if (_RealPlc != null)
                {
                    lblName.Text = _RealPlc.Name;
                    _RealPlc.PowerObservable().Subscribe(new BoolObserver(lblBit));
                }
            }
        }

        public ctRealPlc()
        {
            InitializeComponent();
        }

        private void btnAccendi_Click(object sender, EventArgs e)
        {
            RealPlc.accendi();
        }

        private void btnSpegni_Click(object sender, EventArgs e)
        {
            RealPlc.spegni();
        }
    }
}
