using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;

namespace hn_console.Interface
{
    interface IConsoleService
    {
        void DisplayStories(List<Item> stories);

        void NavigateStories(List<Item> stories);

        void MaximizeConsoleWindow();
    }
}
