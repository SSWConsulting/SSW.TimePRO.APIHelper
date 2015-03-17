using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class AuthorizationAPIHelper
    {
        string _email;
        string _password;
        string _timeProUrlID;
        public AuthorizationAPIHelper(string email, string password, string timeProUrlID)
        {
            _email = email;
            _password = password;
            _timeProUrlID = timeProUrlID;
        }
        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/Authorization/"; }
        }


        public async Task<SuccessfulAuthorizedModel> Authorize()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(BaseRequestUri + "?email=" + _email + "&password=" + _password);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<SuccessfulAuthorizedModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

    }

}

