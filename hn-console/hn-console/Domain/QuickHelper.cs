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
                .Replace("\n", " ")
                .Replace("<i>", "~")
                .Replace("</i>", "~");

            while(html.Contains("<a href="))
            {
                int openingTagIndex = html.IndexOf("<a href=");
                int closingTagIndex = html.IndexOf("</a>");
                string hrefSubstring = html.Substring(openingTagIndex, (closingTagIndex - openingTagIndex) + 4);
                string[] hrefProps = hrefSubstring.Split('"');
                string link = hrefProps[1];
                html = html.Replace(hrefSubstring, String.Format("[{0}]", link));
            }

            return html;
        }

        public static string DeriveSiteHost(string url)
        {
            Uri uri = new Uri(url);
            return uri.Host;
        }
    }
}
