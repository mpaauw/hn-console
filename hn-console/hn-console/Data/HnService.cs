using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;
using hn_console.Data;
using System.IO;
using hn_console.Domain;

namespace hn_console.Data
{
    class HnService
    {
        private const string _endpoint = @"https://hacker-news.firebaseio.com/v0/";
        private string _endpointParams = @"topstories";
        private string _endpointFormat = @".json";
        private readonly string[] _acceptHeaders = { "application/json" };
        private const int _numStories = 20;

        private TestRestSharpService _trsService;

        public HnService()
        {
            _trsService = new TestRestSharpService();
        }

        // NOTE: currently limited to # of posts specified within private vars
        public List<int> GetItemIds()
        {
            //RestService<List<int>> restService = new RestService<List<int>>();
            //List<int> itemIds = restService.GetJsonData(_endpoint, _endpointParams, _endpointFormat, _acceptHeaders);

            List<int> itemIds = _trsService.GetItemIds(_endpoint, _endpointParams, _endpointFormat);
            for (int i = _numStories; i < itemIds.Count; i++) // remove all posts past a certain #; in order to save processing time
            {
                itemIds.RemoveAt(i);
            }
            return itemIds;
        }

        public Item GetItem(int itemId)
        {
            string parameters = String.Format("item/{0}", itemId);
            //RestService<Item> restService = new RestService<Item>();
            //Item item = restService.GetJsonData(_endpoint, parameters, _endpointFormat, _acceptHeaders);

            Item item = _trsService.GetItem(_endpoint, parameters, _endpointFormat);

            if(item.text != null)
            {
                item.text = QuickHelper.SanitizeHtml(item.text);
            }
            return item;
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

        public async Task<Item> AsyncGetItemChildrenWrapper(Item item)
        {
            return await Task.Run(() => GetItemChildren(item));
        }

        public Item GetItemChildren(Item item)
        {
            item.children = new List<Item>();
            if (item.kids == null)
            {
                
                return item;
            }
            item.children = new List<Item>();
            for (int i = 0; i < item.kids.Count; i++)
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
