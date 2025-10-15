using Microsoft.AspNetCore.Diagnostics;

namespace DotNetUdemyCore.Middleware;

public static class ExceptionHandlingExtension
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandling>();
    }
}