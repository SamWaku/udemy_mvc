namespace DotNetUdemyCore.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public Task InvokeAsync(HttpContext httpContext)
    {
        return next(httpContext);
    }
}