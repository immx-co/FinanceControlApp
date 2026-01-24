using finance.control.application;
using finance.control.core;
using finance.control.infrastructure;
using finance.control.persistance;
using Microsoft.EntityFrameworkCore;

namespace finance.control.web.api;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryAdditionRepository, CategoryAdditionRepository>();

        serviceCollection.AddDbContext<ApplicationContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5432;Database=FinanceAppDb;Username=postgres;Password=topiho99");
        });

        return serviceCollection;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryAdditionService, CategoryAdditionService>();
        return serviceCollection;
    }

    public static IServiceCollection AddBackgroundServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IMonitoringService, MonitoringService>();
        serviceCollection.AddHostedService<BackgroundMonitoringService>();
        return serviceCollection;
    }
}
