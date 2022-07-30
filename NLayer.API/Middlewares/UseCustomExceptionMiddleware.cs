using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using System.Data.SqlTypes;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionMiddleware
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    
                    context.Response.ContentType = "application/json";
                
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;
                    var exceptionMessage = exceptionFeature.Error.Message;
                    var statusCode = context.Response.StatusCode;
                    switch (exception)
                    {
                        case SqlNullValueException:
                            exceptionMessage = "Böyle bir veri bulunamadı.";
                            statusCode = 400;
                            break;
                        case NullReferenceException:
                            exceptionMessage = "Böyle bir veri bulunamadı.";
                            statusCode = 404;
                            break;
                    }

                    var response =new ObjectResult(ResponseDto<NoContentDto>.Fail(statusCode, exceptionMessage));

                    await context.Response.WriteAsJsonAsync(response);

                });
            });
        }

    }
}
