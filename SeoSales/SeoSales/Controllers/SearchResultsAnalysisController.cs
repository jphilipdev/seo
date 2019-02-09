using Microsoft.AspNetCore.Mvc;
using SearchResultsAnalysis.Services;

namespace SearchResultsAnalysis.Controllers
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
            var response = _searchResultsAnalysisService.GetSearchResults(null);
            return Ok(response);
        }
    }
}
