using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GetTogether.WEBAPI.Infrastructure;

public static class FirebaseAuthorization
{
    public static void AddFirebaseAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        var projectId = configuration.GetSection("FirebaseConfig")
            .GetValue<string>("project_id");

        var secureUri = configuration.GetSection("FirebaseConfig")
            .GetValue<string>("secure_uri");


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"{secureUri}/{projectId}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"{secureUri}/{projectId}",
                    ValidateAudience = true,
                    ValidAudience = projectId,
                    ValidateLifetime = true
                };
            });
    }
    public static void AddFirebaseApp(this IServiceCollection services)
    {
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile($"{Environment.CurrentDirectory}/FirebaseServiceAccountKey.json")
        });
    }
}
