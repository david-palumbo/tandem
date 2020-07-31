using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Tandem.Api.Middleware
{
    /// <summary>
    /// Add Open API capabilities to the application pipeline.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static  class OpenApiExtensions
    {
        /// <summary>
        /// Adds Open API capabilities to the service collection.
        /// </summary>
        /// <param name="serviceCollection">
        /// Required service collection to add Open API to.
        /// </param>
        public static void AddOpenApi(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(apiVersion, new OpenApiInfo()
                {
                    Title = apiName,
                    Version = apiVersion
                });

            });
        }

        /// <summary>
        /// Instructs the application builder to use Open API.
        /// </summary>
        /// <param name="apiBuilder">
        /// Required application builder.
        /// </param>
        public static void UseOpenApi(this IApplicationBuilder apiBuilder)
        {
            apiBuilder.UseSwagger();
            apiBuilder.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint(
                    $"/swagger/{apiVersion}/swagger.json",
                    apiName
                );
            });
        }

        private const string apiName = "Tandem API";
        private const string apiVersion = "v1";
    }
}