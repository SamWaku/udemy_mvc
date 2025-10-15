using Microsoft.AspNetCore.Diagnostics;

namespace DotNetUdemyCore.Middleware;

public class ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unhandled exception");
        }
    }
}