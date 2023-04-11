using System.Security.Claims;
using FirebaseAdmin.Auth;
using GetTogether.BLL.Interfaces;

namespace GetTogether.WEBAPI.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IAccountService firebaseAuthService)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (authorizationHeader == null || !authorizationHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = 401;
            return;
        }

        var idToken = authorizationHeader["Bearer ".Length..];

        var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        var userEmail = decodedToken.Claims["email"].ToString();

        if (userEmail != null)
        {
            await firebaseAuthService.SetUserId(userEmail);
        }

        await _next(context);
    }
}
