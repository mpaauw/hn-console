using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;
using hn_console.Data;

namespace hn_console.Data
{
    class HnService : IHnService
    {
        private const string _endpoint = @"https://hacker-news.firebaseio.com/v0/";
        private string _endpointParams = @"topstories";
        private string _endpointFormat = @".json";
        private readonly string[] _acceptHeaders = { "application/json" };

        public HnService()
        {

        }

        public Item GetItem(int itemId)
        {
            string parameters = String.Format("item/{0}", itemId);
            RestService<Item> restService = new RestService<Item>();
            return restService.GetJsonData(_endpoint, parameters, _endpointFormat, _acceptHeaders);
        }

        public List<int> GetItemIds()
        {
            RestService<List<int>> restService = new RestService<List<int>>();
            return restService.GetJsonData(_endpoint, _endpointParams, _endpointFormat, _acceptHeaders);
        }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            foreach(int id in GetItemIds())
            {
                items.Add(GetItem(id));
            }
            return items;
        }
    }
}
