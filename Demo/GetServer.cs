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
            txtUrl.Text = Demo.snConfig.ServiceNOWUrl() + "/cmdb_ci_server.do?SOAP";
            txtUsername.Text = Demo.snConfig.snSoapUser;
            txtPassword.Text = Demo.snConfig.snSoapPass;
        }

        private void cmdGetServer_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential Credential = new NetworkCredential(txtUsername.Text, txtPassword.Text);

                server.ciServer.getRecords Server = new getRecords();
                //Server.sys_id = txtServer.Text;
                Server.name = txtServer.Text;

                getRecordsResponseGetRecordsResult[] Result = server.Configuration.GetServer(Credential, Server, txtUrl.Text);
                foreach (getRecordsResponseGetRecordsResult item in Result)
                {
                    txtResult.Text += item.sys_id + "\r\n";
                    txtResult.Text += item.name + "\r\n";
                    txtResult.Text += item.asset + "\r\n";
                    txtResult.Text += item.comments + "\r\n";
                    txtResult.Text += item.department + "\r\n";
                    txtResult.Text += item.managed_by + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
