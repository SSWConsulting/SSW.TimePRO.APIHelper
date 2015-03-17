using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class EmployeeTimesheetCategoriesAPIHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlID;

        public EmployeeTimesheetCategoriesAPIHelper(string timeProUrlID, string apiKey)
        {
            _timeProUrlID = timeProUrlID;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {

            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/EmployeeTimesheetCategories/"; }

        }

        public async Task<IEnumerable<EmployeeTimesheetCategoryModel>> GetCategoriesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<EmployeeTimesheetCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<EmployeeTimesheetCategoryModel> GetCategoryByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<EmployeeTimesheetCategoryModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<EmployeeTimesheetCategoryModel>> GetCategoriesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<EmployeeTimesheetCategoryModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }



        public async Task<EmployeeTimesheetCategoryModel> CreateCategoryAsync(EmployeeTimesheetCategoryModel employeeTimesheetCategory)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(employeeTimesheetCategory);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeeTimesheetCategoryModel>(responseString);
            }
        }



        public async Task<EmployeeTimesheetCategoryModel> EditCategoryAsync(EmployeeTimesheetCategoryModel employeeTimesheetCategory)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(employeeTimesheetCategory);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetCategoryByIdAsync(employeeTimesheetCategory.CategoryID);

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