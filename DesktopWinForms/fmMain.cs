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

        public fmMain()
        {
            log.Info("avvio programma");
            InitializeComponent();

            // esempio stazioni
            var st1 = new Station();
            st1.Name = "Stazione 1";
            var plcCtl1 = new PlcMonitor(100, 100, new TimeSpan(0, 0, 5));
            plcCtl1.Emulazione = true;
            var plc1 = new PlcEmulator("PLC 1");
            plcCtl1.PlcEmulator = plc1;
            var rpc1 = new HardwarePlc("192.168.12.146", 501);
            plcCtl1.RealPlc = rpc1;
            st1.Plc = plcCtl1;

            var st2 = new Station();
            st2.Name = "Stazione 2";
            var plcCtl2 = new PlcMonitor(100, 50, new TimeSpan(0, 0, 5));
            plcCtl2.Emulazione = true;
            var plc2 = new PlcEmulator("PLC 2");
            plcCtl2.PlcEmulator = plc2;
            var rpc2 = new HardwarePlc("192.168.12.147", 501);
            plcCtl2.RealPlc = rpc2;
            st2.Plc = plcCtl2;

            var st3 = new Station();
            st3.Name = "Stazione 3";
            var plcCtl3 = new PlcMonitor(100, 50, new TimeSpan(0, 0, 5));
            plcCtl3.Emulazione = true;
            var plc3 = new PlcEmulator("PLC 3");
            plcCtl3.PlcEmulator = plc3;
            var rpc3 = new HardwarePlc("192.168.12.148", 501);
            plcCtl3.RealPlc = rpc3;
            st3.Plc = plcCtl3;

            ctStation1.Station = st1;
            ctStation1.ctPlc1.Plc = plcCtl1;
            ctStation2.Station = st2;
            ctStation2.ctPlc1.Plc = plcCtl2;
            ctStation3.Station = st3;
            ctStation3.ctPlc1.Plc = plcCtl3;
        }
    }
}
