using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeProAPI.BusinessLogic
{
    public class BaseApiHelper
    {
        private const string SswTimeProLiveUri = "https://sswtimepro.com/api";

        private readonly string _subdomain;
        private readonly string _baseEntity;

        private string _baseUri;

        /// <summary>
        /// Base URI to use instead of the default production SSW TimePRO Uri. Do not include a your subdomain, it will be added for you.
        /// </summary>
        public string BaseUri
        {
            get { return _baseUri; }
            set { _baseUri = value; }
        }

        public BaseApiHelper(string subdomain, string baseEntity) : this(subdomain, baseEntity, SswTimeProLiveUri)
        {
        }

        public BaseApiHelper(string subdomain, string baseEntity, string baseUri)
        {
            _baseEntity = baseEntity;
            _baseUri = baseUri;
            _subdomain = subdomain;
        }

        protected Uri BaseRequestUri
        {
            get
            {
                _baseUri = _baseUri.EndsWith("/") ? _baseUri : _baseUri + "/";

                var uriBuilder = new UriBuilder(string.Format(_baseUri, _subdomain));
                uriBuilder.Host = _subdomain + "." + uriBuilder.Host;
                uriBuilder.Path += _baseEntity + "/";

                return uriBuilder.Uri;
            }
        }
    }
}
