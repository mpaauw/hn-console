using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Data;
using hn_console.Interface;

namespace hn_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Loader loader = new Loader();
            HnService hnService = new HnService();
            ConsoleService consoleService = new ConsoleService();

            var getItemsTask = hnService.AsyncGetItemsWrapper();
            Console.Write("Loading stories ");
            Console.CursorVisible = false;
            while (!getItemsTask.IsCompleted)
            {
                loader.Rotate();
            }
            Console.Clear();
            Console.CursorVisible = true;

            consoleService.NavigateStories(getItemsTask.Result, 0);
            Console.ReadLine();
        }
    }
}
