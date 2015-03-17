using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class ProjectsAPIHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlID;

        public ProjectsAPIHelper(string timeProUrlID, string apiKey)
        {
            _timeProUrlID = timeProUrlID;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/Projects/"; }
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProjectModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }

        public async Task<ProjectModel> GetProjectByIdAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ProjectModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectsWithinRangeAsync(int startRecord, int numberOfRecords)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.GetAsync(BaseRequestUri + "?startRecord=" + startRecord + "&numberOfRecords=" + numberOfRecords);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<IEnumerable<ProjectModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }



        public async Task<ProjectModel> CreateProjectAsync(ProjectModel project)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(project);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProjectModel>(responseString);
            }
        }



        public async Task<ProjectModel> EditProjectAsync(ProjectModel project)
        {

            using (var client = new HttpClient())
            {
                var values = HelperMethods.CreateKeyValuePairsFromReflection(project);


                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);


                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                return await GetProjectByIdAsync(project.EmpID);

            }
        }

        public async void DeleteProjectAsync(string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            var response = await client.DeleteAsync(BaseRequestUri + id);
            response.EnsureSuccessStatusCode();

           
        }
    }
}