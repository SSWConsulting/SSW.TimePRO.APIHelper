using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ControlsApiHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlId;

        public ControlsApiHelper(string timeProUrlId, string apiKey)
        {
            _timeProUrlId = timeProUrlId;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlId + ".sswtimepro.com/api/Controls/"; }
        }

        public async Task<IEnumerable<ControlModel>> GetControlsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ControlModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }
        

        public async Task<ControlModel> GetControlByIdAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ControlModel>(await response.Content.ReadAsStringAsync());
            return result;
        }



        public async Task<ControlModel> EditControlAsync(ControlModel control)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(control);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PutAsync(BaseRequestUri, content);

                return await GetControlByIdAsync(control.ID);

            }
        }

    }
}