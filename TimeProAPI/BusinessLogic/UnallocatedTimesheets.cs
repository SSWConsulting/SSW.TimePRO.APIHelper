using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class UnallocatedTimesheetsAPIHelper
    {
        string _timeProUrlID;
        string _apiKey;
        public UnallocatedTimesheetsAPIHelper(string timeProUrlId, string apiKey)
        {
            this._timeProUrlID = timeProUrlId;
            this._apiKey = apiKey;
        }
        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/UnallocatedTimesheets/"; }
        }
        public async Task<IEnumerable<UnallocatedTimesheetModel>> GetUnallocatedTimesheetsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<UnallocatedTimesheetModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }


    

    }

}

