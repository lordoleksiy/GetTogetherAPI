using CollectionsAndLinq.WebApi.Infrastructure;
using GetTogether.WEBAPI.Infrastructure;

namespace GetTogether.WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddConfig(builder.Configuration);
            builder.Services.AddFirebaseAuthorization(builder.Configuration);
            builder.Services.AddValidators();
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors(opt => opt
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());

            app.UseMiddlewares();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseStartupMigrations();

            app.Run();
        }
    }
}