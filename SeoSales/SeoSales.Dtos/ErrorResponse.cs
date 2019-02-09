namespace SearchResultsAnalysis.Dtos
{
    public class ErrorResponse
    {
        public ErrorResponse(string errorMessage, string errorType)
        {
            ErrorMessage = errorMessage;
            ErrorType = errorType;
        }

        public string ErrorMessage { get; }
        public string ErrorType { get; }
    }
}
