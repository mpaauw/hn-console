﻿using System;
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
            html = html.Replace("<p>", " ");
            html = html.Replace("&#x27;", "'");
            html = html.Replace("&#x2F;", "/");
            html = html.Replace("&gt;", ">");
            html = html.Replace("&quot;", "\"");
            html = html.Replace("\n", " ");

            return html;
        }

        public static string DeriveSiteHost(string url)
        {
            Uri uri = new Uri(url);
            return uri.Host;
        }
    }
}
