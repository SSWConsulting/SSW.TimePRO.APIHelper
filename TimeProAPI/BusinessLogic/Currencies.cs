using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class CurrenciesAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public CurrenciesAPIHelper(string timeProUrlID, string apiKey)
            : base(timeProUrlID, "Currencies")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<CurrencyModel>> GetCurrenciesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<CurrencyModel> GetCurrencyByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<CurrencyModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<CurrencyModel>> GetCurrenciesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }



        public async Task<CurrencyModel> CreateCurrencyAsync(CurrencyModel Currency)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(Currency);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CurrencyModel>(responseString);
            }
        }



        public async Task<CurrencyModel> EditCurrencyAsync(CurrencyModel Currency)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(Currency);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetCurrencyByIdAsync(Currency.CurrencyID);

            }
        }

        public async void DeleteCurrencyAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

           
        }
    }
}