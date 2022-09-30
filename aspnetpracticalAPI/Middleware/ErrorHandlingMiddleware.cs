using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlbumAPI.Data;
using AlbumAPI.Model;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace aspnetpracticalAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public static class ErrorHandlingMiddleware
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILogger logger)
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
                        var errorDetail = new ErrorDetails();
                        errorDetail.StatusCode = context.Response.StatusCode;
                        errorDetail.Message = "Internal Server Error UseGlobalExceptionHandler.";

                        if (errorDetail != null)
                        {

                            await context.Response.WriteAsJsonAsync<ErrorDetails>(errorDetail);
                        }
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                    }
                });
            });

        }
    }
}
