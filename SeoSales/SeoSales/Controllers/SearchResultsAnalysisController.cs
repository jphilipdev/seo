using Microsoft.AspNetCore.Mvc;
using SeoSales.Dtos;
using SeoSales.Services;

namespace SeoSales.Controllers
{
    [Route("api/[controller]")]
    public class SearchResultsAnalysisController : Controller
    {
        private readonly ISearchResultsAnalysisService _searchResultsAnalysisService;

        public SearchResultsAnalysisController(ISearchResultsAnalysisService searchResultsAnalysisService)
        {
            _searchResultsAnalysisService = searchResultsAnalysisService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _searchResultsAnalysisService.GetSearchResults(null);
            return Ok();
        }
    }
}
