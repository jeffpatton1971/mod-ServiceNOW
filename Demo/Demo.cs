using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetIncident getIncident = new GetIncident();
            getIncident.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewIncident newIncident = new NewIncident();
            newIncident.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetServer getServer = new GetServer();
            getServer.Visible = true;
        }
    }
}
