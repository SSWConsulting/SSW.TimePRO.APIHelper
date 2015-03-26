using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class RatesApiHelper :BaseApiHelper
    {
        private readonly string _apiKey;

        public RatesApiHelper(string timeProUrlId, string apiKey): base(timeProUrlId, "Rates")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<RateModel>> GetRatesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<RateModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }


        public async Task<RateModel> GetRateByIdAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id.ToString());
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<RateModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<RateModel>> GetRatesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<RateModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<RateModel> CreateRateAsync(RateModel Rate)
        {

            using (var client = new HttpClient())
            {

                var values = HelperMethods.CreateKeyValuePairsFromReflection(Rate);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RateModel>(responseString);
            }
        }

        public async Task<RateModel> EditRateAsync(RateModel Rate)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(Rate);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PutAsync(BaseRequestUri, content);

                return await GetRateByIdAsync(Rate.ClientRateID);

            }
        }

        public async void DeleteRateAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();


        }
    }
}