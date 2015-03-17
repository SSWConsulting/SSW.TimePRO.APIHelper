using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ProductCategoryGroupsAPIHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlID;

        public ProductCategoryGroupsAPIHelper(string timeProUrlID, string apiKey)
        {
            _timeProUrlID = timeProUrlID;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/ProductCategoryGroups/"; }
        }

        public async Task<IEnumerable<ProductCategoryGroupModel>> GetProductCategoryGroupsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductCategoryGroupModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<ProductCategoryGroupModel> GetProductCategoryGroupByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ProductCategoryGroupModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ProductCategoryGroupModel>> GetProductCategoryGroupsWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductCategoryGroupModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }



        public async Task<ProductCategoryGroupModel> CreateProductCategoryGroupAsync(ProductCategoryGroupModel ProductCategoryGroup)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(ProductCategoryGroup);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductCategoryGroupModel>(responseString);
            }
        }



        public async Task<ProductCategoryGroupModel> EditProductCategoryGroupAsync(ProductCategoryGroupModel ProductCategoryGroup)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(ProductCategoryGroup);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetProductCategoryGroupByIdAsync(ProductCategoryGroup.GroupID);

            }
        }

        public async void DeleteProductCategoryGroupAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

           
        }
    }
}