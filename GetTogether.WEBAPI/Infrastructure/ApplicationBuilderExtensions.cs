using GetTogether.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.WEBAPI.Infrastructure;

public static class BuilderExtensions
{
    public static void UseStartupMigrations(this IApplicationBuilder app)
    {
        _ = bool.TryParse(Environment.GetEnvironmentVariable("DATABASE_UPDATED"), out bool databaseUpdated);

        if (!databaseUpdated)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            using var context = scope?.ServiceProvider.GetRequiredService<DataContext>();
            context?.Database.Migrate();
        } 
    }
}
