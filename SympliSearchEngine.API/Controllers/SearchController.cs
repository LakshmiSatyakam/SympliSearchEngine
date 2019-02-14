using Microsoft.AspNetCore.Mvc;
using SympliSearchEngine.API.Services;
using System.Threading.Tasks;

namespace SympliSearchEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchServiceProvider _searchServiceProvider;

        public SearchController(ISearchServiceProvider searchServiceProvider)
        {
            _searchServiceProvider = searchServiceProvider;
        }

        [HttpGet("searchResults")]
        public async Task<IActionResult> GetSearchResults([FromQuery] string searchText, [FromQuery] string searchUrl, [FromQuery] string searchEngine)
        {
            if (string.IsNullOrWhiteSpace(searchText) || string.IsNullOrWhiteSpace(searchUrl))
            {
                return BadRequest();
            }

            ISearchService service = _searchServiceProvider.GetSearchServiceProvider(searchEngine);
            return Ok(await service.SearchUrls(searchText, searchUrl));
        }
    }
}