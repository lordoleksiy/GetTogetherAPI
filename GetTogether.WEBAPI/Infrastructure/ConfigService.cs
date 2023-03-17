using GetTogether.DAL;
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

    public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options => options.UseNpgsql(config.GetConnectionString("DbContext")), ServiceLifetime.Scoped);
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IAutoMapper, MyAutoMapper>();
        //services.AddScoped<IProjectService, ProjectService>();
        //services.AddScoped<ITaskService, TaskService>();
        //services.AddScoped<ITeamService, TeamService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IDataProcessingService, DataProcessingService>();
        return services;
    }
}
