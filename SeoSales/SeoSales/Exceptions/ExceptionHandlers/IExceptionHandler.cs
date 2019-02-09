using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SearchResultsAnalysis.Exceptions.ExceptionHandlers
{
    public interface IExceptionHandler
    {
        Type HandledType { get; }

        Task Handle(HttpContext context, Exception exception);
    }
}
