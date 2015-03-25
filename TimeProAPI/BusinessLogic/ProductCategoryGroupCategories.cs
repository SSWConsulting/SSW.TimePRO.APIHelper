using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ProductCategoryGroupCategoriesAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ProductCategoryGroupCategoriesAPIHelper(string timeProUrlID, string apiKey) : base(timeProUrlID, "ProductCategoryGroupCategories")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<ProductCategoryGroupCategoryModel>> GetProductCategoryGroupCategoriesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductCategoryGroupCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<ProductCategoryGroupCategoryModel> GetProductCategoryGroupCategoryByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ProductCategoryGroupCategoryModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ProductCategoryGroupCategoryModel>> GetProductCategoryGroupCategoriesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductCategoryGroupCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<ProductCategoryGroupCategoryModel> CreateProductCategoryGroupCategoryAsync(ProductCategoryGroupCategoryModel ProductCategoryGroupCategory)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(ProductCategoryGroupCategory);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductCategoryGroupCategoryModel>(responseString);
            }
        }


        public async Task<ProductCategoryGroupCategoryModel> EditProductCategoryGroupCategoryAsync(ProductCategoryGroupCategoryModel ProductCategoryGroupCategory)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(ProductCategoryGroupCategory);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetProductCategoryGroupCategoryByIdAsync(ProductCategoryGroupCategory.CategoryID);
            }
        }

        public async void DeleteProductCategoryGroupCategoryAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();
        }
    }
}