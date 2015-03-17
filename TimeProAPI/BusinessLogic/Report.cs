using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ReportAPIHelper
    {
        string _timeProUrlID;
        string _apiKey;
        public ReportAPIHelper(string timeProUrlId, string apiKey)
        {
            this._timeProUrlID = timeProUrlId;
            this._apiKey = apiKey;
        }
        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/Reports/"; }
        }
        public async void CreateNewReportAsync()
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


    

    }

}

