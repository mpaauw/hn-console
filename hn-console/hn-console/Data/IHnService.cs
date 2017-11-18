using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;

namespace hn_console.Data
{
    interface IHnService
    {
        List<int> GetItemIds();

        Item GetItem(int itemId);

        List<Item> GetItems();

        List<Item> GetItemsChildren(List<Item> items);

        Item GetItemChildren(Item item);
    }
}
