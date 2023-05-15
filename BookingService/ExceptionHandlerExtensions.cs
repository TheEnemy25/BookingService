using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace BookingService.API
{
    public static class ExceptionHandlerExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    var problemDetails = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = "Internal Server Error",
                        Detail = exception.Message
                    };

                    var json = JsonSerializer.Serialize(problemDetails);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(json);
                });
            });
        }
    }
}

