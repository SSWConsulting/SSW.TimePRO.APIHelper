using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimeProAPI.BusinessLogic;
using TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class AuthorizationAPIHelper : BaseApiHelper
    {
        string _email;
        string _password;
        public AuthorizationAPIHelper(string email, string password, string timeProUrlID) : base(timeProUrlID, "Authorization")
        {
            _email = email;
            _password = password;
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

