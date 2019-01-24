using log4net;
using LogicLayer;
using LogicLayer.PLC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWinForms
{
    public partial class fmMain : Form
    {
        public static ILog log = LogManager.GetLogger("DesktopWinForms");

        class ObserverMessaggi : IObserver<string>
        {
            TextBox tb;

            internal ObserverMessaggi(TextBox tb)
            {
                this.tb = tb;
            }

            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public void OnNext(string value)
            {
                tb.Text += Environment.NewLine + value;
            }
        }

        public fmMain()
        {
            InitializeComponent();
            lblStatus.Text = "Inattivo";

            StationManager.Instance().Observable().Subscribe(new ObserverMessaggi(txtMessaggi));

            // esempio stazioni
            var st1 = new Station();
            st1.Name = "Stazione 1";
            var plc1 = new PlcEmulator("PLC 1");
            var plcCtl1 = new Plc(250, new TimeSpan(0, 0, 5));
            plcCtl1.RealPlc = plc1;
            st1.Plc = plcCtl1;

            var st2 = new Station();
            st2.Name = "Stazione 2";
            var plc2 = new PlcEmulator("PLC 2");
            var plcCtl2 = new Plc(250, new TimeSpan(0, 0, 5));
            plcCtl2.RealPlc = plc2;
            st2.Plc = plcCtl2;

            ctStation1.Station = st1;
            ctStation1.ctRealPlc1.RealPlc = plc1;
            ctStation2.Station = st2;
            ctStation2.ctRealPlc1.RealPlc = plc2;
        }

        private void btnStartLoop_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "SW in funzione";
            PreliminaryChecks.Instance().SWNotReady += (o, r) =>
            {
                log.Warn(String.Format("Rilevato SW non pronto alle {0}", r.TimeReached));
                lblStatus.Invoke(new Action(() => lblStatus.Text = "Rilevato SW non pronto"));
            };
            PreliminaryChecks.Instance().SWReady += (o, r) =>
            {
                log.Info(String.Format("Rilevato SW pronto alle {0}", r.TimeReached));
                lblStatus.Invoke(new Action(() => lblStatus.Text = "SW in funzione"));
            };
            Task.Run(() => PreliminaryChecks.Instance().StartCheckLoop(500));
        }

        private void btnInviaMsg_Click(object sender, EventArgs e)
        {
            // push (publish) del messaggio
            StationManager.Instance().Messaggio(txtMessaggio.Text);
        }

        private void btnPulisci_Click(object sender, EventArgs e)
        {
            txtMessaggi.Text = "";
        }
    }
}
