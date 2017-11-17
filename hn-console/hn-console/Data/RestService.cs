using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace hn_console.Data
{
    class RestService<T> : IRestService<T>
    {
        private JavaScriptSerializer serializer;

        public RestService()
        {
            serializer = new JavaScriptSerializer();
        }

        public T GetJsonData(string endpoint, string parameters, string format, string[] headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(endpoint);

                foreach (string header in headers)
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(header));
                }

                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(parameters + format).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return serializer.Deserialize<T>(json);
                }
                else
                {
                    Console.WriteLine("Request Failed.");
                    Console.WriteLine("{0} ({1})", (int)httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
                    return default(T);
                }
            }
        }
    }
}
