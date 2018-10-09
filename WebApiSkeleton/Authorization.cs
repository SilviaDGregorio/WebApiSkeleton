using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApiSkeleton
{
    public class Authorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if(!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                throw new UnauthorizedAccessException("Invalid Authorization");
            }
            string authorization = context.HttpContext.Request.Headers["Authorization"];
            if(!string.Equals(authorization,"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2V4YW1wbGUuYXV0aDAuY29tLyIsImF1ZCI6Imh0dHBzOi8vYXBpLmV4YW1wbGUuY29tL2NhbGFuZGFyL3YxLyIsInN1YiI6InVzcl8xMjMiLCJpYXQiOjE0NTg3ODU3OTYsImV4cCI6MTQ1ODg3MjE5Nn0.CA7eaHjIHz5NxeIJoFK9krqaeZrPLwmMmgI_XiQiIkQ")) throw new UnauthorizedAccessException("Invalid Authorization");
        }        
    }
}
