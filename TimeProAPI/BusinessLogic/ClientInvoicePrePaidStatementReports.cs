using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SSW.TimeProAPI.Extension;

namespace SSW.TimeProAPI
{
    public class ClientInvoicePrePaidStatementReportsApiHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlId;

        public ClientInvoicePrePaidStatementReportsApiHelper(string timeProUrlId, string apiKey)
        {
            _timeProUrlId = timeProUrlId;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlId + ".sswtimepro.com/api/ClientInvoicePrePaidStatementReports/"; }
        } 

        public async Task<String> CreateNewReportAsync(int id)
        {

            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", id.ToString())
                };
              
                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri + "?id=" + id, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            } 
        }
    }
}
