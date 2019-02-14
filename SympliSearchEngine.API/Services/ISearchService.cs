using System.Threading.Tasks;

namespace SympliSearchEngine.API.Services
{
    public interface ISearchService
    {
        Task<string> SearchUrls(string searchText, string searchUrl); 
    }    
}
