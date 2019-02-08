using SeoSales.Dtos;

namespace SeoSales.Proxies
{
    public interface ISearchEngineParsingServiceProxy
    {
        void GetSearchResults(SearchResultsAnalysisRequest request);
    }

    public class SearchEngineParsingServiceProxy : ISearchEngineParsingServiceProxy
    {
        public void GetSearchResults(SearchResultsAnalysisRequest request)
        {
            
        }
    }
}
