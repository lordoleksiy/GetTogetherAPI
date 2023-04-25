using FirebaseAdmin.Auth;
using GetTogether.BLL.Interfaces;

namespace GetTogether.WEBAPI.Middlewares;

public class StorageMiddleware
{
    private readonly RequestDelegate _next;

    public StorageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine(context.Request.Method);
        Console.WriteLine(context.Request.Path);
        Console.WriteLine(context.Request.Body);

        await _next(context);
    }
}
