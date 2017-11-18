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

            // limit to only first five posts for testing:
            List<int> itemIds = GetItemIds();
            for(int i = 0; i < 5; i++)
            {
                items.Add(SetItemChildren(GetItem(itemIds[i])));
            }

            //foreach(int id in GetItemIds())
            //{
            //    items.Add(SetItemChildren(GetItem(id)));
            //}
            return items;
        }

        public Item SetItemChildren(Item item)
        {
            if(item.kids == null)
            {
                return item;
            }
            item.children = new List<Item>();
            for(int i = 0; i < item.kids.Length; i++)
            {
                int kid = item.kids[i];
                Item child = GetItem(kid);
                child = SetItemChildren(child);
                item.children.Add(child);
            }
            return item;
        }
    }
}
