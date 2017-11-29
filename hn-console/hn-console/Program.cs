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
            HnService hnService = new HnService();
            ConsoleService consoleService = new ConsoleService();
            consoleService.NavigateStories(hnService.GetItems(), 0);
            Console.ReadLine();
        }
    }
}
