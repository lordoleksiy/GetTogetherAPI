using Firebase.Storage;
using FluentValidation;
using FluentValidation.AspNetCore;
using GetTogether.BLL.Interfaces;
using GetTogether.BLL.Services;
using GetTogether.DAL.Context;
using GetTogether.WEBAPI.Infrastructure;
using GetTogether.WEBAPI.Middlewares;
using GetTogether.WEBAPI.Validation.User;
using Microsoft.EntityFrameworkCore;

namespace CollectionsAndLinq.WebApi.Infrastructure;

public static class ConfigServices
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMyDependencyGroup(config);
        return services;
    }

    public static void AddMyDependencyGroup(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options => options.UseNpgsql(config.GetConnectionString("DbContext")), ServiceLifetime.Scoped);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IPartyService, PartyService>();
        services.AddFirebaseApp();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<NewUserValidator>();
        services.AddFluentValidationAutoValidation(config =>
        {
            config.DisableDataAnnotationsValidation = true;
        });
    }
}
