namespace SeoSales.Dtos
{
    public class SearchResultsAnalysisResponse
    {
        public SearchResultsAnalysisResponse(string results)
        {
            Results = results;
        }

        public string Results { get; }
    }
}
