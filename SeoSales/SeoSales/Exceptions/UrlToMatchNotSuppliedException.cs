using System;

namespace SearchResultsAnalysis.Exceptions
{
    public class UrlToMatchNotSuppliedException : Exception
    {
        public UrlToMatchNotSuppliedException()
            : base("UrlToMatch must be supplied")
        {

        }
    }
}
