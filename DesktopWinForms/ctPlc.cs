using System;
using System.Windows.Forms;
using LogicLayer.PLC;
using System.Reactive.Linq;

namespace DesktopWinForms
{
    public partial class ctPlc : UserControl
    {
        private PlcMonitor _Plc;
        public PlcMonitor Plc
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
                    lblName.Text = $"{_Plc.Name} - {(_Plc.IP == null ? "?" : _Plc.IP.Split('.')[3])}";
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

        public ctPlc()
        {
            InitializeComponent();
        }

        private void btnAccendi_Click(object sender, EventArgs e)
        {
            if (Plc.Emulazione)
            {
                Plc.PlcEmulator.accendi();
            }
        }

        private void btnSpegni_Click(object sender, EventArgs e)
        {
            if (Plc.Emulazione)
            {
                Plc.PlcEmulator.spegni();
            }
        }

        private void chkEmulazione_CheckedChanged(object sender, EventArgs e)
        {
            Plc.Emulazione = chkEmulazione.Checked;
            btnAccendi.Enabled = chkEmulazione.Checked;
            btnSpegni.Enabled = chkEmulazione.Checked;
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            if(Plc.Acceso)
            {
                Plc.StopMonitor();
                btnMonitor.Text = "Avvia Monitor";
            }
            else
            {
                Plc.StartMonitor();
                btnMonitor.Text = "Arresta Monitor";
            }
        }
    }
}
