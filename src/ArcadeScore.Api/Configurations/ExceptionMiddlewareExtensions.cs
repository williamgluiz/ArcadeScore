using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ArcadeScore.API.Extensions
{
    /// <summary>
    /// Provides extension methods to configure global exception handling middleware.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Adds a global exception handler middleware that captures exceptions,
        /// returns validation errors with HTTP 400 status code, and handles unexpected errors gracefully.
        /// </summary>
        /// <param name="app">The application builder to configure the middleware.</param>
        /// <returns>The configured application builder.</returns>
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                    if (exception is ValidationException validationException)
                    {
                        var errors = validationException.Errors
                            .Select(e => new { e.PropertyName, e.ErrorMessage });

                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = "Validation failed",
                            Errors = errors
                        });
                    }
                    else
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = "An unexpected error occurred"
                        });
                    }
                });
            });

            return app;
        }
    }
}
