using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.PLC;

namespace DesktopWinForms
{
    public partial class ctStation : UserControl
    {
        private Station _Station;
        public Station Station {
            get
            {
                return _Station;
            }
            set
            {
                _Station = value;
                lblName.Text = (_Station != null ? _Station.Name : "No name");
            }
        }

        public ctStation()
        {
            InitializeComponent();
        }
    }
}
