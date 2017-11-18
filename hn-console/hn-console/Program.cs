using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Data;

namespace hn_console
{
    class Program
    {
        static void Main(string[] args)
        {
            HnService service = new HnService();
            service.GetItems();
        }
    }
}
