using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class TimeSheetsApiHelper:BaseApiHelper
    {
        private readonly string _apiKey;

        public TimeSheetsApiHelper(string timeProUrlID, string apiKey): base(timeProUrlID, "TimeSheets")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<TimesheetModel>> GetTimeSheetsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<TimesheetModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }


        public async Task<TimesheetModel> GetTimesheetByIdAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id.ToString());
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<TimesheetModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<TimesheetModel>> GetTimeSheetsWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<TimesheetModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }
        public async Task<TimesheetModel> CreateTimeSheetAsync(TimesheetModel TimeSheet)
        {

            using (var client = new HttpClient())
            {

                var values = HelperMethods.CreateKeyValuePairsFromReflection(TimeSheet);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TimesheetModel>(responseString);
            }
        }
        public async Task<int> SplitTimesheetAsync(int pintTimeID, int pintSplit )
        {

            using (var client = new HttpClient())
            {

                var values = new List<KeyValuePair<string, string>>();


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PostAsync(BaseRequestUri + "?pintTimeID=" + pintTimeID + "&pintSplit=" + pintSplit, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(responseString);
            }
        }

        public async Task<TimesheetModel> EditTimeSheetAsync(TimesheetModel TimeSheet)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(TimeSheet);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response =
                    await client.PutAsync(BaseRequestUri, content);

                return await GetTimesheetByIdAsync(TimeSheet.TimeID);

            }
        }

        public async void DeleteTimeSheetAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();


        }
    }
}