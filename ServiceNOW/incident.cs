namespace mod_servicenow
{
    using incident;
    using System;
    using System.Net;
    public class Incident
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Credential"></param>
        /// <param name="Incident"></param>
        /// <param name="EndPoint"></param>
        /// <param name="RemoteAddress"></param>
        /// <returns></returns>
        public static insertResponse NewIncident(NetworkCredential Credential, insert Incident, string EndPoint, string RemoteAddress)
        {
            try
            {
                ServiceNowSoapClient client = soapClient(Credential, EndPoint, RemoteAddress);
                
                insertResponse response = new insertResponse();

                response = client.insert(Incident);
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
        /// <param name="Incident"></param>
        /// <param name="EndPoint"></param>
        /// <param name="RemoteAddress"></param>
        /// <returns></returns>
        public static getRecordsResponseGetRecordsResult[] GetIncident(NetworkCredential Credential, getRecords Incident, string EndPoint, string RemoteAddress)
        {
            try
            {
                ServiceNowSoapClient client = soapClient(Credential, EndPoint, RemoteAddress);

                getRecordsResponseGetRecordsResult[] result = client.getRecords(Incident);

                return result;
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