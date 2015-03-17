using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class CountriesAPIHelper
    {
        string _timeProUrlID;
        string _apiKey;
        public CountriesAPIHelper(string timeProUrlId, string apiKey)
        {
            this._timeProUrlID = timeProUrlId;
            this._apiKey = apiKey;
        }
        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/Countries/"; }
        }
        public async Task<IEnumerable<CountryModel>> GetCountriesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }


        public async Task<CountryModel> GetCountriesByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<CountryModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<CountryModel>> GetCountriesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }
    }

}

