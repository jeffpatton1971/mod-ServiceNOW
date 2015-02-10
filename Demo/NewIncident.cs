namespace Demo
{
    using incident.snIncident;
    using System;
    using System.Net;
    using System.Windows.Forms;

    public partial class NewIncident : Form
    {
        public NewIncident()
        {
            InitializeComponent();
            txtUrl.Text = Demo.snConfig.ServiceNOWUrl() + "/incident.do?SOAP";
            txtUsername.Text = Demo.snConfig.snSoapUser;
            txtPassword.Text = Demo.snConfig.snSoapPass;
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential Credential = new NetworkCredential(txtUsername.Text, txtPassword.Text);

                insert newIncident = new insert();
                newIncident.caller_id = txtUser.Text;
                newIncident.opened_by = txtUser.Text;
                newIncident.watch_list = txtUser.Text;
                newIncident.contact_type = "Email";
                newIncident.short_description = txtShortDescription.Text;
                newIncident.description = txtDescription.Text;

                insertResponse response = incident.Incident.NewIncident(Credential, newIncident, txtUrl.Text);
                MessageBox.Show(response.number);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
