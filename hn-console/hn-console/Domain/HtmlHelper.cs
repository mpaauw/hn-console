using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hn_console.Domain
{
    public class HtmlHelper
    {
        public static string SanitizeHtml(string html)
        {
            html = html.Replace("<p>", "\n");
            html = html.Replace("&#x27;", "'");
            html = html.Replace("&#x2F;", "/");
            html = html.Replace("&gt;", ">");
            html = html.Replace("&quot;", "\"");

            return html;
        }
    }
}
