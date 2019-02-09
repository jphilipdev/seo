using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using SearchEngineParsing.Dtos;
using SearchResultsAnalysis.Configuration;
using SearchResultsAnalysis.Dtos;
using SearchResultsAnalysis.Exceptions;
using SearchResultsAnalysis.Proxies;
using System;
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
        private readonly IMemoryCache _memoryCache;

        public SearchResultsAnalysisService(ISearchEngineParsingServiceProxy searchEngineParsingServiceProxy, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _searchEngineParsingServiceProxy = searchEngineParsingServiceProxy;
            _configuration = configuration;
            _memoryCache = memoryCache;
        }

        public SearchResultsAnalysisResponse GetSearchResults(SearchResultsAnalysisRequest request)
        {
            ValidateRequest(request);

            var cachedResult = _memoryCache.Get<string>(GetCacheKey(request));
            if (cachedResult == null)
            {
                return GetSourceResult(request);
            }

            return new SearchResultsAnalysisResponse(cachedResult);
        }

        private SearchResultsAnalysisResponse GetSourceResult(SearchResultsAnalysisRequest request)
        {
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

            var formattedResult = FormatResult(limitedResults);

            CacheResult(request, formattedResult);

            return new SearchResultsAnalysisResponse(formattedResult);
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

        private string FormatResult(List<int> limitedResults)
        {
            if (limitedResults.Any())
            {
                return string.Join(", ", limitedResults);
            }

            return "0";
        }

        private string GetCacheKey(SearchResultsAnalysisRequest request)
        {
            return $"{request.TargetSearchEngineUrl}:{request.Keywords}:{request.UrlToMatch}";
        }

        private void CacheResult(SearchResultsAnalysisRequest request, string formattedResult)
        {
            var resultsCacheTimeInSeconds = _configuration.GetValue<int>(Constants.Config.ResultsCacheTimeInSeconds);
            _memoryCache.Set(GetCacheKey(request), formattedResult, TimeSpan.FromSeconds(resultsCacheTimeInSeconds));
        }
    }
}
