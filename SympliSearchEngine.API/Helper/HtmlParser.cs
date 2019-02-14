using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SympliSearchEngine.API.Helper
{
    public class HtmlParser
    {
        /// <summary>
        /// Returns the list of indices found 
        /// </summary>
        /// <param name="html">html result</param>
        /// <param name="url">Link to be looked for</param>
        /// <returns></returns>
        public static string FindAllHrefMatches(string html, Uri url, List<string> parseFields)
        {
            html = html.Substring(html.IndexOf(parseFields[0]));
            html = html.Substring(html.IndexOf(parseFields[1]));
            string lookup = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";
            MatchCollection matches = Regex.Matches(html, lookup);

            string result = string.Empty;

            for (int i = 0; i < matches.Count && i < 100; i++)
            {
                string match = matches[i].Groups[0].Value;
                if (match.Contains(url.Host))
                {
                    result = result + (i + 1) + ",";
                }
            }

            return result == string.Empty ? "0" : result.TrimEnd(',');
        }
    }
}
