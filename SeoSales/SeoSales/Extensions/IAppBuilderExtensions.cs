using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using SearchResultsAnalysis.Exceptions.ExceptionHandlers.Factories;

namespace SearchResultsAnalysis.Extensions
{
    public static class IAppBuilderExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFactory = (IExceptionHandlerFactory)context.RequestServices.GetService(typeof(IExceptionHandlerFactory));

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var handler = exceptionHandlerFactory.Create(contextFeature?.Error);
                    await handler.Handle(context, contextFeature?.Error);                        
                });
            });
        }
    }
}
