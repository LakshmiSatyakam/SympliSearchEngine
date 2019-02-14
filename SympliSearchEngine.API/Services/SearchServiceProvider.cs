using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliSearchEngine.API.Services
{
    public interface ISearchServiceProvider
    {
        ISearchService GetSearchServiceProvider(string searchEngine);
    }

    public class SearchServiceProvider : ISearchServiceProvider
    {
        public const string GoogleSearchEngine = "GOOGLE";
        public const string BingSearchEngine = "BING";

        public ISearchService GetSearchServiceProvider(string searchEngine)
        {
            if (string.IsNullOrEmpty(searchEngine))
            {
                return new GoogleSearchService();
            }

            switch (searchEngine.ToUpper())
            {
                case BingSearchEngine:
                    return new BingSearchService();

                case GoogleSearchEngine:
                default:
                    return new GoogleSearchService();
            }
        }
    } 
}
