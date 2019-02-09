using SearchResultsAnalysis.Dtos;
using SearchResultsAnalysis.Exceptions;
using SearchResultsAnalysis.Proxies;
using System.Linq;

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
            ValidateRequest(request);

            var parsingResponse = _searchEngineParsingServiceProxy.GetSearchResults(request);

            return AnalyseResponse(request, parsingResponse);
        }

        private void ValidateRequest(SearchResultsAnalysisRequest request)
        {
            ValidateTargetSearchEngineUrl(request);
            ValidateKeywords(request);
            ValidateUrlToMatch(request);
        }

        private void ValidateTargetSearchEngineUrl(SearchResultsAnalysisRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.TargetSearchEngineUrl))
            {
                throw new TargetSearchEngineUrlNotSuppliedException();
            }
        }

        private void ValidateKeywords(SearchResultsAnalysisRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Keywords))
            {
                throw new KeywordsNotSuppliedException();
            }
        }

        private void ValidateUrlToMatch(SearchResultsAnalysisRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.UrlToMatch))
            {
                throw new UrlToMatchNotSuppliedException();
            }
        }

        private SearchResultsAnalysisResponse AnalyseResponse(SearchResultsAnalysisRequest request, SearchEngineParsing.Dtos.SearchEngineParsingResponse parsingResponse)
        {
            var matchedResults = parsingResponse.Results.Where(p => p.Result == request.UrlToMatch).Select(p => p.Position).ToList();
            if (matchedResults.Any())
            {
                return new SearchResultsAnalysisResponse(string.Join(", ", matchedResults));
            }

            return new SearchResultsAnalysisResponse("0");
        }
    }
}
