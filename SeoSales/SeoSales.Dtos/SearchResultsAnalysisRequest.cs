namespace SearchResultsAnalysis.Dtos
{
    public class SearchResultsAnalysisRequest
    {
        public SearchResultsAnalysisRequest(string targetSearchEngineUrl, string keywords, string urlToMatch)
        {
            TargetSearchEngineUrl = targetSearchEngineUrl;
            Keywords = keywords;
            UrlToMatch = urlToMatch;
        }

        public string TargetSearchEngineUrl { get; }
        public string Keywords { get; }
        public string UrlToMatch { get; }
    }
}