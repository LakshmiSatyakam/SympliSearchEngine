using Microsoft.VisualStudio.TestTools.UnitTesting;
using SympliSearchEngine.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSearchEngine.API.UnitTest.Services
{
    [TestClass]
    public class SearchServiceProviderTest
    {
        private SearchServiceProvider _provider;

        [TestInitialize]
        public void TestInitialize()
        {
            _provider = new SearchServiceProvider();
        }

        [TestMethod]
        public void Input_Null_Test()
        {
            ISearchService service = _provider.GetSearchServiceProvider(string.Empty);

            Assert.IsTrue(service is GoogleSearchService);
        }

        [TestMethod]
        public void Input_Google_Test()
        {
            ISearchService service = _provider.GetSearchServiceProvider(SearchServiceProvider.GoogleSearchEngine);

            Assert.IsTrue(service is GoogleSearchService);
        }

        [TestMethod]
        public void Input_Bing_Test()
        {
            ISearchService service = _provider.GetSearchServiceProvider(SearchServiceProvider.BingSearchEngine);

            Assert.IsTrue(service is BingSearchService);
        }

        [TestMethod]
        public void Input_Any_Test()
        {
            ISearchService service = _provider.GetSearchServiceProvider("aaa");

            Assert.IsTrue(service is GoogleSearchService);
        }
    }
}
