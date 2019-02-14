using Microsoft.VisualStudio.TestTools.UnitTesting;
using SympliSearchEngine.API.Helper;
using System;
using System.Collections.Generic;
using System.IO;

namespace SympliSearchEngine.API.UnitTest.Helper
{
    [TestClass]
    public class HtmlParserTest
    {
        private List<string> _parseFields = new List<string> { "<div id=\"b_content\">", "<li class=\"b_algo\">" };
        private List<string> _googleParseFields = new List<string> { "<div class=\"sd\" id=\"resultStats\">", "<div class=\"g\">" };

        [TestMethod]
        public void HtmlParser_BingResults_Test()
        {
            string html = File.ReadAllText(@"Sample Data\BingSampleResults.html");
            string results = HtmlParser.FindAllHrefMatches(html, new Uri("https://www.Sympli.com.au"), _parseFields);

            Assert.IsTrue(results != "0");
        }

        [TestMethod]
        public void HtmlParser_GoogleResults_Test()
        {
            string html = File.ReadAllText(@"Sample Data\GoogleSampleResults.html");
            string results = HtmlParser.FindAllHrefMatches(html, new Uri("https://www.Sympli.com.au"), _googleParseFields);

            Assert.IsTrue(results != "0");
        }
    }
}
