namespace Demo
{
    using incident.snIncident;
    using System;
    using System.Net;
    using System.Windows.Forms;

    public partial class GetIncident : Form
    {
        public GetIncident()
        {
            InitializeComponent();
        }

        private void cmdGetIncident_Click(object sender, EventArgs e)
        {
            NetworkCredential Credential = new NetworkCredential(txtUsername.Text, txtPassword.Text);
            
            getRecords myIncident = new getRecords();
            myIncident.number = txtIncident.Text;

            getRecordsResponseGetRecordsResult[] myIncidents = incident.Incident.GetIncident(Credential, myIncident);
            foreach (getRecordsResponseGetRecordsResult result in myIncidents)
            {
                txtResult.Text += result.number + "\r\n";
                txtResult.Text += result.opened_by + "\r\n";
                txtResult.Text += result.short_description + "\r\n";
                txtResult.Text += result.u_comments_and_work_notes + "\r\n";
            }
        }
    }
}
