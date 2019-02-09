using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SearchResultsAnalysis.Configuration;
using SearchResultsAnalysis.Dtos;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SearchResultsAnalysis.Exceptions.ExceptionHandlers
{
    public class KeywordsNotSuppliedExceptionHandler : IExceptionHandler
    {
        public Type HandledType => typeof(KeywordsNotSuppliedException);

        public async Task Handle(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse(exception.Message, Constants.ErrorType.KeywordsNotSupplied)));
        }
    }
}