using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;

namespace SSW.TimeProAPI
{
    public class TimeInvoiceReportsApiHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public TimeInvoiceReportsApiHelper(string timeProUrlId, string apiKey): base(timeProUrlId, "TimeInvoiceReports")
        {
            _apiKey = apiKey;
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
