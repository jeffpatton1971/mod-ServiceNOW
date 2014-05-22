namespace ServiceNOW
{
    //
    // This is the service reference
    //
    using cmdb_ci_server;
    using System;
    using System.Net;
    public class Configuration
    {
        /// <summary>
        /// This function inserts a server into the ServiceNow CI Database
        /// </summary>
        /// <param name="Credential">A credential object that gets passed to the soap client for authentication</param>
        /// <param name="server">An insert object that contains the data to be inserted into ServiceNOW</param>
        /// <returns>An insertResponse object containing data returned from ServiceNOW</returns>
        public static insertResponse NewServer(NetworkCredential Credential, insert server)
        {
            try
            {
                string userName = Credential.UserName;
                string userPass = Credential.Password;
                ServiceNowSoapClient client = soapClient(userName, userPass);

                insertResponse response = new insertResponse();

                if (!(itemExist(client, server.name)))
                {
                    response = client.insert(server);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A private function used by NewServer for validation purposes.
        /// </summary>
        /// <param name="client">A ServiceNOW soapclient</param>
        /// <param name="configurationItem">The name property of the item</param>
        /// <returns>true if the item exists, false if it doesn't</returns>
        private static bool itemExist(ServiceNowSoapClient client, string configurationItem)
        {
            try
            {
                getRecords gRecords = new getRecords();
                gRecords.name = configurationItem;
                getRecordsResponseGetRecordsResult[] gResults = client.getRecords(gRecords);
                foreach (getRecordsResponseGetRecordsResult gResult in gResults)
                {
                    if (gResult.name == configurationItem)
                    {
                        //
                        // this item already exists
                        //
                        return true;
                    }
                }
                //
                // No match found
                //
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }
        /// <summary>
        /// A private function to create the soapclient to communicate with ServiceNOW
        /// </summary>
        /// <param name="UserName">The API Username</param>
        /// <param name="Password">The API Password</param>
        /// <returns>A ServiceNow SoapClient object</returns>
        private static ServiceNowSoapClient soapClient(string UserName, string Password)
        {
            try
            {
                ServiceNowSoapClient soapClient = new ServiceNowSoapClient();
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