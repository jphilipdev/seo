namespace SearchResultsAnalysis.Configuration
{
    public static class Constants
    {
        public static class Config
        {
            public const string MaxResultPosition = "Settings:MaxResultPosition";
            public const string ResultsCacheTimeInSeconds = "Settings:ResultsCacheTimeInSeconds";
        }

        public static class ErrorType
        {
            public const string KeywordsNotSupplied = "KeywordsNotSupplied";
            public const string TargetSearchEngineUrlNotSupplied = "TargetSearchEngineUrlNotSupplied";
            public const string UrlToMatchNotSupplied = "UrlToMatchNotSupplied";
        }
    }
}
