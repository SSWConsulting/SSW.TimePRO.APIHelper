using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;
using TimeProAPI.BusinessLogic;


namespace SSW.TimeProAPI
{
    public class ProductCategoriesAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ProductCategoriesAPIHelper(string timeProUrlID, string apiKey) : base(timeProUrlID, "ProductCategories")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetCategoriesAsync()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var response = await client.GetAsync(BaseRequestUri);
                response.EnsureSuccessStatusCode();

                var result =
                    JsonConvert.DeserializeObject<IEnumerable<ProductCategoryModel>>(
                        await response.Content.ReadAsStringAsync());
                return result;

            }
            catch (Exception ex)
            {
                var test = ex.Message;
                throw;
            }
        }

        public async Task<ProductCategoryModel> GetCategoryByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ProductCategoryModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetCategoriesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }



        public async Task<ProductCategoryModel> CreateCategoryAsync(ProductCategoryModel productCategory)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(productCategory);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductCategoryModel>(responseString);
            }
        }



        public async Task<ProductCategoryModel> EditCategoryAsync(ProductCategoryModel productCategory)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(productCategory);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);


                return JsonConvert.DeserializeObject<ProductCategoryModel>(await response.Content.ReadAsStringAsync());

            }
        }

        public async void DeleteCategoryAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();
             

        }
    }
}