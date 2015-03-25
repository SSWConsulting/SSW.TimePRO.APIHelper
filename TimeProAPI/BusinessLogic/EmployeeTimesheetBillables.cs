using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class EmployeeTimesheetBillablesAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public EmployeeTimesheetBillablesAPIHelper(string timeProUrlId, string apiKey) : base(timeProUrlId, "EmployeeTimesheetBillables")
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<EmployeeTimesheetBillableModel>> GetEmployeeTimesheetBillablesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<EmployeeTimesheetBillableModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<EmployeeTimesheetBillableModel> GetEmployeeTimesheetBillableByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<EmployeeTimesheetBillableModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<EmployeeTimesheetBillableModel>> GetEmployeeTimesheetBillablesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<EmployeeTimesheetBillableModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}