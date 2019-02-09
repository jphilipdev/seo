using SearchEngineParsing.Dtos;
using SearchResultsAnalysis.Dtos;
using System;
using System.Net.Http;

namespace SearchResultsAnalysis.Proxies
{
    public interface ISearchEngineParsingServiceProxy
    {
        SearchEngineParsingResponse GetSearchResults(SearchResultsAnalysisRequest request);
    }

    /// <remarks>
    /// I was planning on adding another microservice (SearchEngineParsingService) which would fake the retrieval of 
    /// search results by providing random data, then in the integration tests this downstream service would be mocked
    /// so that success and failure responses could be injected. However due to time constraints I changed the random
    /// data generation to be in another proxy implementation which can be mocked instead.
    /// </remarks>
    public class SearchEngineParsingServiceProxy : ISearchEngineParsingServiceProxy
    {
        private readonly HttpClient _httpClient;

        public SearchEngineParsingServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public SearchEngineParsingResponse GetSearchResults(SearchResultsAnalysisRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
