namespace Demo
{
    using group.snGroup;
    using System;
    using System.Net;
    using System.Windows.Forms;
    
    public partial class GetGroup : Form
    {
        public GetGroup()
        {
            InitializeComponent();
            txtUrl.Text = Demo.snConfig.ServiceNOWUrl() + "/sys_user_group.do?SOAP";
            txtUsername.Text = Demo.snConfig.snSoapUser;
            txtPassword.Text = Demo.snConfig.snSoapPass;
        }

        private void cmdGetGroup_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential Credential = new NetworkCredential(txtUsername.Text, txtPassword.Text);

                getRecords myGroup = new getRecords();
                myGroup.name = txtGroup.Text;

                getRecordsResponseGetRecordsResult[] myIncidents = group.Group.GetGroup(Credential, myGroup, txtUrl.Text);
                foreach (getRecordsResponseGetRecordsResult result in myIncidents)
                {
                    txtResult.Text += result.name + "\r\n";
                    txtResult.Text += result.description + "\r\n";
                    txtResult.Text += result.active + "\r\n";
                    txtResult.Text += result.sys_id + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
