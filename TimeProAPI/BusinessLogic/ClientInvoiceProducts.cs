using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ClientInvoiceProductsApiHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlID;

        public ClientInvoiceProductsApiHelper(string timeProUrlID, string apiKey)
        {
            _timeProUrlID = timeProUrlID;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/ClientInvoiceProducts/"; }
        }

        public async Task<IEnumerable<ClientInvoiceProductModel>> GetClientInvoiceProductsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientInvoiceProductModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<ClientInvoiceProductModel> GetClientInvoiceProductByIdAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ClientInvoiceProductModel>(await response.Content.ReadAsStringAsync());
            return result;
        } 

        public async Task<IEnumerable<ClientInvoiceProductModel>> GetClientInvoiceProductsByInvoiceIdAsync(int invoiceID)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?invoiceID=" + invoiceID);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientInvoiceProductModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ClientInvoiceProductModel>> GetClientInvoiceProductsWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ClientInvoiceProductModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }



        public async Task<ClientInvoiceProductModel> CreateClientInvoiceProductAsync(ClientInvoiceProductModel ClientInvoiceProduct)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(ClientInvoiceProduct);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ClientInvoiceProductModel>(responseString);
            }
        }



        public async Task<ClientInvoiceProductModel> EditClientInvoiceProductAsync(ClientInvoiceProductModel ClientInvoiceProduct)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(ClientInvoiceProduct);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetClientInvoiceProductByIdAsync(ClientInvoiceProduct.InvoiceProdID);

            }
        }

        public async void DeleteClientInvoiceProductAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

           
        }
    }
}