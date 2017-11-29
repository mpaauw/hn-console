using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hn_console.Domain
{
    public class QuickHelper
    {
        public static string SanitizeHtml(string html)
        {
            html = html.Replace("<p>", " ")
                .Replace("&#x27;", "'")
                .Replace("&#x2F;", "/")
                .Replace("&gt;", ">")
                .Replace("&quot;", "\"")
                .Replace("\n", " ");
            return html;
        }

        public static string DeriveSiteHost(string url)
        {
            Uri uri = new Uri(url);
            return uri.Host;
        }
    }
}
