using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace hn_console.Data
{
    public class Database : IDatabase
    {
        private const string _endpoint = @"https://hacker-news.firebaseio.com/v0/";
        private string endpointParams = @"topstories"; // can also search by: 'newstories' or 'beststories'
        private readonly string[] acceptHeaders = { "application/json" };

        public void GetData()
        {
            using(HttpClient httpClient = new HttpClient()) {
                httpClient.BaseAddress = new Uri(_endpoint);

                foreach (string header in acceptHeaders)
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(header));
                }

                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(endpointParams).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    //var data = httpResponseMessage.Content.ReadAsAsync<IEnumerable<TestDataObject>>().Result;

                    var data = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    //var data = httpResponseMessage.Content.ToString();
                    foreach (var i in data)
                    {
                        Console.WriteLine("{0}", i);
                    }
                }
                else
                {
                    Console.WriteLine("Request Failed.");
                    Console.WriteLine("{0} ({1})", (int)httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
                }
            }        
        } 
    }

    class TestDataObject
    {
        public string Name { get; set; }
    }
}
