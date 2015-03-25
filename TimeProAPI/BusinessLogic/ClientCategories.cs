using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ClientCategoriesApiHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ClientCategoriesApiHelper(string timeProUrlId, string apiKey): base(timeProUrlId, "ClientCategories")
        {
            _apiKey = apiKey;
        }


        public async Task<IEnumerable<ClientCategoryModel>> GetClientCategoriesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<ClientCategoryModel> GetClientCategoryByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ClientCategoryModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ClientCategoryModel>> GetClientCategoriesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<ClientCategoryModel> CreateClientCategoryAsync(ClientCategoryModel clientCategory)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(clientCategory);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ClientCategoryModel>(responseString);
            }
        }

        public async Task<ClientCategoryModel> EditClientCategoryAsync(ClientCategoryModel clientCategory)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(clientCategory);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PutAsync(BaseRequestUri, content);

                return await GetClientCategoryByIdAsync(clientCategory.CategoryID);
            }
        }

        public async void DeleteClientCategoryAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();
        }
    }
}