using System.Security.Claims;

namespace GetTogether.WEBAPI.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (authorizationHeader == null || !authorizationHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = 401;
            return;
        }

        var idToken = authorizationHeader["Bearer ".Length..];

        var decodedToken = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        Console.WriteLine(idToken);
        //var claims = new List<Claim>();
        //claims.Add(new Claim(ClaimTypes.NameIdentifier, decodedToken.Uid));
        //claims.Add(new Claim(ClaimTypes.Name, decodedToken.Name));
        //claims.Add(new Claim(ClaimTypes.Email, decodedToken.Email));

        //var identity = new ClaimsIdentity(claims, "Firebase");
        //var principal = new ClaimsPrincipal(identity);

        //context.User = principal;

        await _next(context);
    }
}
