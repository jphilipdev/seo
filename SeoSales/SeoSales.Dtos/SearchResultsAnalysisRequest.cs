namespace SeoSales.Dtos
{
    public class SearchResultsAnalysisRequest
    {
        public SearchResultsAnalysisRequest(string searchEngineUrl, string keywords)
        {
            SearchEngineUrl = searchEngineUrl;
            Keywords = keywords;
        }

        public string SearchEngineUrl { get; }
        public string Keywords { get; }
    }
}