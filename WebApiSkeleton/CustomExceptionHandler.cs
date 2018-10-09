using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace WebApiSkeleton
{
    public class CustomExceptionHandler
    {
        public RequestDelegate Create()
        {
            return async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/html";
                var exceptionType = context.Features.GetType();
                Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature ex = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                if (ex != null)
                {
                    Type errorType = ex.Error.GetType();
                    if(errorType == typeof(UnauthorizedAccessException)){
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                    else if(errorType == typeof(NotImplementedException)){
                        context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    }
                    else if(errorType == typeof(ArgumentException) || errorType == typeof(ArgumentNullException)){
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    }
                    else if(errorType == typeof(KeyNotFoundException)){
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                    }
                    else if(errorType == typeof(NotImplementedException)){
                        context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    }
                   
                    await context.Response.WriteAsync(ex.Error.Message, Encoding.UTF8).ConfigureAwait(false);
                }
            };
        }
    }
}