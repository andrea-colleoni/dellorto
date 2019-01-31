using System;
using System.Windows.Forms;
using LogicLayer.PLC;
using System.Reactive.Linq;

namespace DesktopWinForms
{
    public partial class ctRealPlc : UserControl
    {
        private Plc _Plc;
        public Plc Plc
        {
            get
            {
                return _Plc;
            }
            set
            {
                _Plc = value;
                if (_Plc != null)
                {
                    lblName.Text = _Plc.Name;
                    _Plc.PlcBit().Subscribe(b =>
                    {
                        if (!this.IsDisposed)
                        {
                            this.Invoke(new Action(() => lblBit.Text = b.ToString()));
                        }
                    }
                    );
                    _Plc.PlcStatus().Subscribe(s =>
                    {
                        if (!this.IsDisposed)
                        {
                            switch (s)
                            {
                                case PlcStatus.Ok:
                                    this.Invoke(new Action(() => pctStatus.Image = global::DesktopWinForms.Properties.Resources.iconfinder_bullet_green_84433));
                                    break;
                                case PlcStatus.ThresholdReached:
                                case PlcStatus.NotResponding:
                                    this.Invoke(new Action(() => pctStatus.Image = global::DesktopWinForms.Properties.Resources.iconfinder_bullet_red_84435));
                                    break;
                            }
                        }
                    });
                    _Plc.PlcTimeElapsedSinceLastBitChange().Subscribe(
                        ts =>
                        {
                            if (!this.IsDisposed)
                            {
                                this.Invoke(new Action(() => aGauge1.Value = (float)(ts.TotalMilliseconds / 100)));
                            }
                        }
                    );
                }
            }
        }

        public ctRealPlc()
        {
            InitializeComponent();
        }

        private void btnAccendi_Click(object sender, EventArgs e)
        {
            if (!Plc.Acceso)
            {
                Plc.Acceso = true;
            }
            Plc.RealPlc.accendi();
        }

        private void btnSpegni_Click(object sender, EventArgs e)
        {
            Plc.RealPlc.spegni();
        }
    }
}
