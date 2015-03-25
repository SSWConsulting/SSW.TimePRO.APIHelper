using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ProductsApiHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ProductsApiHelper(string timeProUrlId, string apiKey): base(timeProUrlId, "Products")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }


        public async Task<ProductModel> GetProductByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {

            using (var client = new HttpClient())
            {

                var values = HelperMethods.CreateKeyValuePairsFromReflection(product);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductModel>(responseString);
            }
        }

        public async Task<ProductModel> EditProductAsync(ProductModel product)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(product);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PutAsync(BaseRequestUri, content);

                return await GetProductByIdAsync(product.ProdID);

            }
        }

        public async void DeleteProductAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();


        }
    }
}