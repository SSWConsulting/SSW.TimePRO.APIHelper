using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace SSW.TimeProAPI.Extension
{
    public static class HelperMethods
    {
        public static AuthenticationHeaderValue CreateAuthorizationHeader(string apiKey)
        {
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", apiKey, "password"))));
        }


        public static List<KeyValuePair<string, string>> CreateKeyValuePairsFromReflection<T>(T obj) where T : class
        {
            var values = new List<KeyValuePair<string, string>>();

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    object recievedValue = propertyInfo.GetValue(obj, null);
                    if (recievedValue != null)
                    {
                        values.Add(new KeyValuePair<string, string>(propertyInfo.Name, recievedValue.ToString()));
                    }
                }
            }
            return values;
        }



 
    }
}
