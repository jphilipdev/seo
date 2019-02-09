using Microsoft.Extensions.Configuration;
using SearchEngineParsing.Dtos;
using SearchResultsAnalysis.Configuration;
using SearchResultsAnalysis.Dtos;
using SearchResultsAnalysis.Exceptions;
using SearchResultsAnalysis.Proxies;
using System.Collections.Generic;
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
        private readonly IConfiguration _configuration;

        public SearchResultsAnalysisService(ISearchEngineParsingServiceProxy searchEngineParsingServiceProxy, IConfiguration configuration)
        {
            _searchEngineParsingServiceProxy = searchEngineParsingServiceProxy;
            _configuration = configuration;
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

        private SearchResultsAnalysisResponse AnalyseResponse(SearchResultsAnalysisRequest request, SearchEngineParsingResponse parsingResponse)
        {
            var filteredResults = FilterResults(request, parsingResponse);
            var limitedResults = LimitResults(filteredResults);

            if (limitedResults.Any())
            {
                return new SearchResultsAnalysisResponse(string.Join(", ", limitedResults));
            }

            return new SearchResultsAnalysisResponse("0");
        }        

        private List<int> FilterResults(SearchResultsAnalysisRequest request, SearchEngineParsingResponse parsingResponse)
        {
            return parsingResponse.Results.Where(p => p.Result == request.UrlToMatch).Select(p => p.Position).ToList();
        }

        private List<int> LimitResults(List<int> filteredResults)
        {
            var maxResultPosition = _configuration.GetValue<int>(Constants.Config.MaxResultPosition);
            return filteredResults.Where(p => p <= maxResultPosition).ToList();
        }
    }
}
