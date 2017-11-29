using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using hn_console.Model;

namespace hn_console.Data
{
    public class TestRestSharpService
    {
        public TestRestSharpService() { }

        public T Execute<T>(RestRequest request, string endpoint) where T : new()
        {
            var client = new RestClient(endpoint);
            var response = client.Execute<T>(request);
            if(response.ErrorException != null)
            {
                Console.WriteLine(response.ErrorException);
            }

            return response.Data;
        }

        public List<int> GetItemIds(string endpoint, string endpointParams, string endpointFormat)
        {
            var request = new RestRequest(endpointParams + endpointFormat, Method.GET);
            return Execute<List<int>>(request, endpoint);
        }

        public Item GetItem(string endpoint, string endpointParams, string endpointFormat)
        {
            var request = new RestRequest(endpointParams + endpointFormat, Method.GET);
            return Execute<Item>(request, endpoint);
        }
    }
}
