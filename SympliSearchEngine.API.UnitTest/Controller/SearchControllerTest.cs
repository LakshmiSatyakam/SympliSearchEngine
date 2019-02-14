using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SympliSearchEngine.API.Controllers;
using SympliSearchEngine.API.Services;
using System.Threading.Tasks;

namespace SympliSearchEngine.API.UnitTest.Controller
{
    [TestClass]
    public class SearchControllerTest
    {
        private SearchController _controller;
        private Mock<ISearchServiceProvider> _mockService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockService = new Mock<ISearchServiceProvider>();
            _controller = new SearchController(_mockService.Object);
        }

        [TestMethod]
        public void Constructor_Test()
        {
            SearchController controller = new SearchController(_mockService.Object);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public async void Invalid_Input1_Test()
        {
            IActionResult actionResult = await _controller.GetSearchResults(string.Empty, string.Empty, string.Empty);
            Assert.IsTrue(actionResult is BadRequestResult);
        }

        [TestMethod]
        public async void Invalid_Input2_Test()
        {
            IActionResult actionResult = await _controller.GetSearchResults(string.Empty, "aaa", string.Empty);
            Assert.IsTrue(actionResult is BadRequestResult);
        }

        [TestMethod]
        public async void Invalid_Input3_Test()
        {
            IActionResult actionResult = await _controller.GetSearchResults("aaa", string.Empty, string.Empty);
            Assert.IsTrue(actionResult is BadRequestResult);
        }

        [TestMethod]
        public async void Valid_Input_Test()
        {
            TaskCompletionSource<string> taskCompletion = new TaskCompletionSource<string>();
            taskCompletion.SetResult("1,10");

            Mock<ISearchService> service = new Mock<ISearchService>();
            service.Setup(x => x.SearchUrls("aaa", "bbb")).Returns(taskCompletion.Task);

            _mockService.Setup(x => x.GetSearchServiceProvider(string.Empty)).Returns(service.Object);
            IActionResult actionResult = await _controller.GetSearchResults("aaa", "bbb", string.Empty);
            Assert.IsTrue(actionResult is OkObjectResult);
        }

        [TestMethod]
        public async void Valid_Input1_Test()
        {
            TaskCompletionSource<string> taskCompletion = new TaskCompletionSource<string>();
            taskCompletion.SetResult("1,10");

            Mock<ISearchService> service = new Mock<ISearchService>();
            service.Setup(x => x.SearchUrls("aaa", "bbb")).Returns(taskCompletion.Task);

            _mockService.Setup(x => x.GetSearchServiceProvider("Google")).Returns(service.Object);
            IActionResult actionResult = await _controller.GetSearchResults("aaa", "bbb", "Google");
            Assert.IsTrue(actionResult is OkObjectResult);
        }

        [TestMethod]
        public async void Valid_Input2_Test()
        {
            TaskCompletionSource<string> taskCompletion = new TaskCompletionSource<string>();
            taskCompletion.SetResult("1,10");

            Mock<ISearchService> service = new Mock<ISearchService>();
            service.Setup(x => x.SearchUrls("aaa", "bbb")).Returns(taskCompletion.Task);

            _mockService.Setup(x => x.GetSearchServiceProvider("Bing")).Returns(service.Object);
            IActionResult actionResult = await _controller.GetSearchResults("aaa", "bbb", "Bing");
            Assert.IsTrue(actionResult is OkObjectResult);
        }
    }
}
