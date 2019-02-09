using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SearchResultsAnalysis.Exceptions.ExceptionHandlers
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        public Type HandledType => null;

        public Task Handle(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Task.CompletedTask;
        }
    }
}