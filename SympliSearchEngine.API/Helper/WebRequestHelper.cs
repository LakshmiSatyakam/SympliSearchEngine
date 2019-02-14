using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SympliSearchEngine.API.Helper
{
    public class WebRequestHelper
    {
        public static string GetSearchResults(string searchRequest, string searchUrl, List<string> parseFields)
        {
            Uri searchUri = new Uri($"https://{searchUrl}/");

            WebRequest request = WebRequest.Create(searchRequest);
            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    return HtmlParser.FindAllHrefMatches(responseFromServer, searchUri, parseFields);
                }
            }
        }
    }
}
