using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ClientsAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ClientsAPIHelper(string timeProUrlId, string apiKey) : base(timeProUrlId, "Clients")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<ClientModel>> GetClientsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<ClientModel> GetClientsByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ClientModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ClientModel>> GetClientsWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}