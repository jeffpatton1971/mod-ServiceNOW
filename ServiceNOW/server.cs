namespace mod_servicenow
{
    using cmdb_ci_server;
    using System;
    using System.Net;
    public class Configuration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Credential"></param>
        /// <param name="Server"></param>
        /// <param name="EndPoint"></param>
        /// <param name="RemoteAddress"></param>
        /// <returns></returns>
        public static insertResponse NewServer(NetworkCredential Credential, insert Server, string EndPoint, string RemoteAddress)
        {
            try
            {
                ServiceNowSoapClient client = soapClient(Credential, EndPoint, RemoteAddress);

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
        /// 
        /// </summary>
        /// <param name="Credential"></param>
        /// <param name="Server"></param>
        /// <param name="EndPoint"></param>
        /// <param name="RemoteAddress"></param>
        /// <returns></returns>
        public static getRecordsResponseGetRecordsResult[] GetServer(NetworkCredential Credential, getRecords Server, string EndPoint, string RemoteAddress)
        {
            try
            {
                ServiceNowSoapClient client = soapClient(Credential, EndPoint, RemoteAddress);

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
        /// 
        /// </summary>
        /// <param name="Credential"></param>
        /// <param name="EndPoint"></param>
        /// <param name="RemoteAddress"></param>
        /// <returns></returns>
        private static ServiceNowSoapClient soapClient(NetworkCredential Credential, string EndPoint, string RemoteAddress)
        {
            try
            {
                ServiceNowSoapClient soapClient = new ServiceNowSoapClient(EndPoint, RemoteAddress);
                soapClient.ClientCredentials.UserName.UserName = Credential.UserName;
                soapClient.ClientCredentials.UserName.Password = Credential.Password;
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