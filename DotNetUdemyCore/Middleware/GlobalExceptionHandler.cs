using DotNetUdemyCore.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotNetUdemyCore.Middleware;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string message { get; set; }
    public string description { get; set; }
}

public class GlobalExceptionHandler: IExceptionHandler
{
    public async  ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception, 
        CancellationToken cancellationToken)
    {
        var (statusCode, message, description) = exception switch
        {
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized dont be a cunt", "exception.Message"),
            BadHttpRequestException => (StatusCodes.Status400BadRequest, "Bad Request", exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error", exception.Message)
        };

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            message = message,
            description = description
        };
        
        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}