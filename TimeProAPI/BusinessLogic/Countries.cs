using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class CountriesAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public CountriesAPIHelper(string timeProUrlID, string apiKey) : base(timeProUrlID, "Countries")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<CountryModel>> GetCountriesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<CountryModel> GetCountriesByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<CountryModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<CountryModel>> GetCountriesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}