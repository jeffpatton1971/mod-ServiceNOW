namespace group
{
    using System;
    using System.Net;
    using System.ServiceModel;
    using snGroup;
    public class Group
    {
        /// <summary>
        /// Get one or more incidents from ServiceNOW
        /// </summary>
        /// <param name="Credential">A NetworkCredential object that gets passed to the soap client for authentication</param>
        /// <param name="Group">A getRecrods object that contains the data to be retreived from ServiceNOW</param>
        /// <param name="ServiceNowUrl">The ServiceNOW Url</param>
        /// <returns>A getRecordsResponseGetRecordsResult array of incidents</returns>
        public static getRecordsResponseGetRecordsResult[] GetGroup(NetworkCredential Credential, getRecords Group, string ServiceNowUrl)
        {
            try
            {
                string userName = Credential.UserName;
                string userPass = Credential.Password;
                ServiceNowSoapClient client = soapClient(userName, userPass, ServiceNowUrl);

                getRecordsResponseGetRecordsResult[] result = client.getRecords(Group);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A private function to create the soapclient to communicate with ServiceNOW
        /// </summary>
        /// <param name="UserName">The API Username</param>
        /// <param name="Password">The API Password</param>
        /// <param name="ServiceNowUrl">The ServiceNOW Url</param>
        /// <returns>A ServiceNow SoapClient object</returns>
        private static ServiceNowSoapClient soapClient(string UserName, string Password, string ServiceNowUrl)
        {
            try
            {
                EndpointAddress endpoint = new EndpointAddress(new Uri(ServiceNowUrl));
                ServiceNowSoapClient soapClient = new ServiceNowSoapClient("ServiceNowSoap", endpoint);
                soapClient.ClientCredentials.UserName.UserName = UserName;
                soapClient.ClientCredentials.UserName.Password = Password;

                return soapClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}