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
    public partial class SetConfig : Form
    {
        public SetConfig()
        {
            InitializeComponent();
        }

        private void CmdOk_Click(object sender, EventArgs e)
        {
            Demo.snConfig.snInstance = txtInstance.Text;
            Demo.snConfig.snSoapUser = txtUser.Text;
            Demo.snConfig.snSoapPass = txtPassword.Text;

            SetConfig setConfig = new SetConfig();
            setConfig.Close();
        }
    }
}
