using SearchResultsAnalysis.Dtos;
using SearchResultsAnalysis.Proxies;

namespace SearchResultsAnalysis.Services
{
    public interface ISearchResultsAnalysisService
    {
        SearchResultsAnalysisResponse GetSearchResults(SearchResultsAnalysisRequest request);
    }

    public class SearchResultsAnalysisService : ISearchResultsAnalysisService
    {
        private readonly ISearchEngineParsingServiceProxy _searchEngineParsingServiceProxy;

        public SearchResultsAnalysisService(ISearchEngineParsingServiceProxy searchEngineParsingServiceProxy)
        {
            _searchEngineParsingServiceProxy = searchEngineParsingServiceProxy;
        }

        public SearchResultsAnalysisResponse GetSearchResults(SearchResultsAnalysisRequest request)
        {
            var response = _searchEngineParsingServiceProxy.GetSearchResults(request);
            return response;
        }
    }
}
