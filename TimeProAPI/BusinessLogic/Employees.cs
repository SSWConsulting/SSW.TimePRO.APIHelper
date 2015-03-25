using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class EmployeesAPIHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public EmployeesAPIHelper(string timeProUrlID, string apiKey): base(timeProUrlID, "Employees")
        {
            _apiKey = apiKey;
        }


        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<EmployeeModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(await response.Content.ReadAsStringAsync());
            return result;
        }


        public async Task<IEnumerable<EmployeeModel>> CreateEmployeeAsync(EmployeeModel employee)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(employee);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);
            }
        }


        public async Task<EmployeeModel> EditEmployeeAsync(EmployeeModel employee)
        {
            using (var client = new HttpClient())
            {
                List<KeyValuePair<string, string>> values = HelperMethods.CreateKeyValuePairsFromReflection(employee);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetEmployeeByIdAsync(employee.EmpID);
            }
        }

        public async void DeleteEmployeeAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            HttpResponseMessage response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();
        }
    }
}