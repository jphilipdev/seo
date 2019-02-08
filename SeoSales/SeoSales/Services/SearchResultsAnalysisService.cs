﻿using SeoSales.Dtos;
using SeoSales.Proxies;

namespace SeoSales.Services
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
            _searchEngineParsingServiceProxy.GetSearchResults(request);
            return null;
        }
    }
}