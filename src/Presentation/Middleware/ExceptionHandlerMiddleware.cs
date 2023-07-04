

using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Presentation.Middleware;

public static class ExceptionHandlerMiddleware
{ 
        /// <summary>
        /// A Global Exception Handler for the API.
        /// This handler will be called when an exception is thrown in the API.
        /// This extension method is registered at the startup class for global exception handler.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger? logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        // logger?.Information("Something went wrong: {ErrorMessage}", contextFeature.Error.Message);
                        var exception = contextFeature.Error;
                        var error = new
                        {
                            message = exception.Message,
                            exception = exception.GetType().Name,
                        };
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(error, new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }));
                    }
                });
            });
        }

}