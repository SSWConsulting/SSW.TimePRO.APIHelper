using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ControlsApiHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ControlsApiHelper(string timeProUrlId, string apiKey) : base(timeProUrlId, "Controls")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<ControlModel>> GetControlsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ControlModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<IEnumerable<ControlModel>> GetControlByIdAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id.ToString());
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ControlModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<IEnumerable<ControlModel>> EditControlAsync(ControlModel control)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(control);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PutAsync(BaseRequestUri, content);

                return await GetControlByIdAsync(control.ID);
            }
        }
    }
}