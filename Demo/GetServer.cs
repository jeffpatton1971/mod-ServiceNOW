namespace Demo
{
    using server.ciServer;
    using System;
    using System.Net;
    using System.Windows.Forms;

    public partial class GetServer : Form
    {
        public GetServer()
        {
            InitializeComponent();
        }

        private void cmdGetServer_Click(object sender, EventArgs e)
        {
            NetworkCredential Credential = new NetworkCredential(txtUsername.Text, txtPassword.Text);

            server.ciServer.getRecords Server = new getRecords();
            Server.sys_id = txtServer.Text;

            getRecordsResponseGetRecordsResult[] Result = server.Configuration.GetServer(Credential, Server);
            foreach (getRecordsResponseGetRecordsResult item in Result)
            {
                txtResult.Text += item.asset + "\r\n";
                txtResult.Text += item.comments + "\r\n";
                txtResult.Text += item.department + "\r\n";
                txtResult.Text += item.managed_by + "\r\n";
            }
        }
    }
}
