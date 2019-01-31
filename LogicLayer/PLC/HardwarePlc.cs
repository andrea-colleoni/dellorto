using log4net;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.PLC
{
    public class HardwarePlc
    {
        public static ILog log = LogManager.GetLogger("DesktopWinForms");

        public string IP { get; set; }
        public int PcPowerOnDB { get; set; }
        public bool _lock;

        public HardwarePlc(string ip, int pcPowerOnDB)
        {
            IP = ip;
            PcPowerOnDB = pcPowerOnDB;
            _lock = false;
        }

        public bool? ReadPowerOn()
        {
            bool? bit = null;
            if (!_lock)
            {
                _lock = true;
                using (var S7Plc = new Plc(CpuType.S7300, IP, 0, 2))
                {
                    try
                    {
                        S7Plc.Open();
                        bit = Convert.ToBoolean(S7Plc.Read(DataType.DataBlock, PcPowerOnDB, 0, VarType.Bit, 1));
                        log.Debug($"real bit read from {IP} cell {PcPowerOnDB}: {bit}");
                        S7Plc.Close();
                    }
                    catch (Exception e)
                    {
                        log.Error($"reading power on bit on {IP}", e);
                    }
                }
                _lock = false;
            }
            else
            {
                log.Debug($"skip bit read from {IP}");
            }
            return bit;
        }
    }
}
