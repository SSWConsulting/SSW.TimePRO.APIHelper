using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SSW.TimeProAPI.Extension;

namespace SSW.TimeProAPI
{
    public class ReportsApiHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlId;

        public ReportsApiHelper(string timeProUrlId, string apiKey)
        {
            _timeProUrlId = timeProUrlId;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlId + ".sswtimepro.com/api/Reports/"; }
        }

        public async Task<Stream> GetReportByIdAsync(string reportName)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);

            reportName = reportName.Replace("\"", "");

            HttpResponseMessage response = await client.GetAsync(BaseRequestUri + "?reportName=" + reportName);
            response.EnsureSuccessStatusCode();

            Stream result = await response.Content.ReadAsStreamAsync();
            return result;
        }
    }
}