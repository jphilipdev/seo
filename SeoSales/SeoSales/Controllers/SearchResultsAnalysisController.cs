using Microsoft.AspNetCore.Mvc;
using SearchResultsAnalysis.Dtos;
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

        public IActionResult Post([FromBody] SearchResultsAnalysisRequest request)
        {
            var response = _searchResultsAnalysisService.GetSearchResults(request);
            return Ok(response);
        }
    }
}
