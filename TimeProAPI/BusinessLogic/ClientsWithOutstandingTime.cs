using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ClientsWithOutstandingTimeAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ClientsWithOutstandingTimeAPIHelper(string timeProUrlId, string apiKey)
            : base(timeProUrlId, "ClientsWithOutstandingTime")
        {
            _apiKey = apiKey;
        }


        public async Task<IEnumerable<ClientsWithOutstandingTime>> GetClientsWithOutstandingTimeAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientsWithOutstandingTime>>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<string> Range(string clientFilter, string onlyWithOutstanding, string request)
        {
            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>();

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PostAsync(BaseRequestUri + "?clientFilter=" + clientFilter + "&onlyWithOutstanding=" + onlyWithOutstanding + "&request=" + request, content);

                string responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}