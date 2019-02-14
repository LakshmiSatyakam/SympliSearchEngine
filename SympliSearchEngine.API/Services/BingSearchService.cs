using SympliSearchEngine.API.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace SympliSearchEngine.API.Services
{
    public class BingSearchService : ISearchService
    {
        private List<string> _parseFields = new List<string> { "<div id=\"b_content\">", "<li class=\"b_algo\">" };

        public async Task<string> SearchUrls(string searchText, string searchUrl)
        {
            string searchRequest = "https://www.bing.com/search?num=100&q={0}&btnG=Search";
            string requestString = string.Format(searchRequest, HttpUtility.UrlEncode(searchText));

            return WebRequestHelper.GetSearchResults(requestString, searchUrl, _parseFields);
        }
    }
}
