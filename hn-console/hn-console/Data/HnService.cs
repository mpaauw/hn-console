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
        private const int _numStories = 20;

        public HnService()
        {

        }

        // NOTE: currently limited to # of posts specified within private vars
        public List<int> GetItemIds()
        {
            RestService<List<int>> restService = new RestService<List<int>>();
            List<int> itemIds = restService.GetJsonData(_endpoint, _endpointParams, _endpointFormat, _acceptHeaders);
            for (int i = _numStories; i < itemIds.Count; i++) // remove all posts past a certain #; in order to save processing time
            {
                itemIds.RemoveAt(i);
            }
            return itemIds;
        }

        public Item GetItem(int itemId)
        {
            string parameters = String.Format("item/{0}", itemId);
            RestService<Item> restService = new RestService<Item>();
            return restService.GetJsonData(_endpoint, parameters, _endpointFormat, _acceptHeaders);
        }

        public List<Item> GetItems()
        {
            List<int> itemIds = GetItemIds();
            List<Item> items = new List<Item>();
            for(int i = 0; i < _numStories; i++)
            {
                Item item = GetItem(itemIds[i]);
                item.children = new List<Item>();
                items.Add(item);
            }
            return items;
        }

        public List<Item> GetItemsChildren(List<Item> items)
        {
            for(int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                item = GetItemChildren(item); // get rid of assignment? use ref types
            }
            return items;
        }

        public Item GetItemChildren(Item item)
        {
            item.children = new List<Item>();
            if (item.kids == null)
            {
                
                return item;
            }
            item.children = new List<Item>();
            for (int i = 0; i < item.kids.Length; i++)
            {
                int kid = item.kids[i];
                Item child = GetItem(kid);
                child = GetItemChildren(child);
                item.children.Add(child);
            }
            return item;
        }
    }
}
