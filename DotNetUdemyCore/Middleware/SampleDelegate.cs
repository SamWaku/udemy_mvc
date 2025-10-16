namespace DotNetUdemyCore.Middleware;

public class SampleDelegate(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Before delegate");
        await next(context);
        Console.WriteLine("After delegate");
    }
}