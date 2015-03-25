using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SSW.TimeProAPI.BusinessLogic;
using SSW.TimeProAPI.Extension;

namespace SSW.TimeProAPI
{
    public class ReportsApiHelper : BaseApiHelper
    {
        private readonly string _apiKey;

        public ReportsApiHelper(string timeProUrlId, string apiKey): base(timeProUrlId, "Reports")
        {
            _apiKey = apiKey;
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