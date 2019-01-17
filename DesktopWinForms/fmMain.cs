using LogicLayer;
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
        public fmMain()
        {
            InitializeComponent();
            lblStatus.Text = "Inattivo";
        }

        private void btnStartLoop_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "SW in funzione...";
            PreliminaryChecks.Instance().SWNotReady += (o, r) =>
            {
                MessageBox.Show("!!");
                lblStatus.Text = "Rilevato SW non pronto";
                Debug.WriteLine("Status: {0}", r.Ready);
            };
            Task.Run(() => PreliminaryChecks.Instance().StartCheckLoop(1000));
        }

    }
}
