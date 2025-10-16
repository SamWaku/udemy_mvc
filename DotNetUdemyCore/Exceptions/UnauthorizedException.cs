using Microsoft.AspNetCore.Diagnostics;

namespace DotNetUdemyCore.Exceptions;

public sealed class UnauthorizedAccessAppException : Exception
{
    
}

internal sealed class UnauthorizedException(ILogger<UnauthorizedException> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not UnauthorizedAccessAppException  unauthorizedException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        httpContext.Response.ContentType = "application/json";
        var data = new
        {
            statusCode = httpContext.Response.StatusCode,
            message = "Unauthorized",
            description = exception.Message,
        };
        await httpContext.Response.WriteAsJsonAsync(data);
        
        return true;
    }
}