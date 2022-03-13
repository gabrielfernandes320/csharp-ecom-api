using System.Net;
using System.Text.Json;
using Domain.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureHttpExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        ?.Error;

                    if (exception is HttpException httpException)
                    {
                        await context.Response.WriteAsync(
                            JsonSerializer.Serialize(new
                            {
                                statusCode = httpException.StatusCode, message = httpException.Message, code = httpException.Code,
                                parameter = httpException.Parameter
                            }));
                        return;
                    }

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {statusCode = HttpStatusCode.InternalServerError, message = "Internal Server Error"}));
                }
            });
        });
    }
}