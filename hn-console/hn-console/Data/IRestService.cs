using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hn_console.Data
{
    interface IRestService<T>
    {
        T GetJsonData(string endpoint, string parameters, string format, string[] headers);
    }
}