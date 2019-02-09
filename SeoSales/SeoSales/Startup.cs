using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchResultsAnalysis.Exceptions.ExceptionHandlers;
using SearchResultsAnalysis.Exceptions.ExceptionHandlers.Factories;
using SearchResultsAnalysis.Extensions;
using SearchResultsAnalysis.Proxies;
using SearchResultsAnalysis.Services;

namespace SearchResultsAnalysis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddTransient<ISearchResultsAnalysisService, SearchResultsAnalysisService>();
            //services.AddTransient<ISearchEngineParsingServiceProxy, SearchEngineParsingServiceProxy>();
            services.AddTransient<ISearchEngineParsingServiceProxy, RandomDataSearchEngineParsingServiceProxy>();

            services.AddTransient<IExceptionHandler, KeywordsNotSuppliedExceptionHandler>();
            services.AddTransient<IExceptionHandler, TargetSearchEngineUrlNotSuppliedExceptionHandler>();
            services.AddTransient<IExceptionHandler, UrlToMatchNotSuppliedExceptionHandler>();
            services.AddTransient<IExceptionHandlerFactory, ExceptionHandlerFactory>();

            //services.AddHttpClient<ISearchEngineParsingServiceProxy, SearchEngineParsingServiceProxy>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.ConfigureExceptionHandler();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
