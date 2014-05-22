namespace ServiceNOW
{
    using cmdb_ci_server;
    using System;
    using System.Net;
    public class Configuration
    {
        /// <summary>
        /// This function inserts a server into the ServiceNow CI Database
        /// </summary>
        /// <param name="Credential">A NetworkCredential object that gets passed to the soap client for authentication</param>
        /// <param name="Server">An insert object that contains the data to be inserted into ServiceNOW</param>
        /// <returns>An insertResponse object containing data returned from ServiceNOW</returns>
        public static insertResponse NewServer(NetworkCredential Credential, insert Server)
        {
            try
            {
                string userName = Credential.UserName;
                string userPass = Credential.Password;
                ServiceNowSoapClient client = soapClient(userName, userPass);

                insertResponse response = new insertResponse();

                if (!(itemExist(client, Server.name)))
                {
                    response = client.insert(Server);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get one or more servers from ServiceNOW
        /// </summary>
        /// <param name="Credential">A NetworkCredential object that gets passed to the soap client for authentication</param>
        /// <param name="Server">A getRecrods object that contains the data to be retreived from ServiceNOW</param>
        /// <returns>A getRecordsResponseGetRecordsResult array of server(s)</returns>
        public static getRecordsResponseGetRecordsResult[] GetServer(NetworkCredential Credential, getRecords Server)
        {
            try
            {
                string userName = Credential.UserName;
                string userPass = Credential.Password;
                ServiceNowSoapClient client = soapClient(userName, userPass);

                getRecordsResponseGetRecordsResult[] result = client.getRecords(Server);

                return result;
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
        /// <param name="Name">The name property of the item</param>
        /// <returns>true if the item exists, false if it doesn't</returns>
        private static bool itemExist(ServiceNowSoapClient client, string Name)
        {
            try
            {
                getRecords gRecords = new getRecords();
                gRecords.name = Name;
                getRecordsResponseGetRecordsResult[] gResults = client.getRecords(gRecords);
                foreach (getRecordsResponseGetRecordsResult gResult in gResults)
                {
                    if (gResult.name == Name)
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