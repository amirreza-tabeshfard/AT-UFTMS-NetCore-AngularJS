using AT.UFTMS.WebAPI.Application.Abstractions.Repositories;
using AT.UFTMS.WebAPI.Infrastructure.Configuration;
using AT.UFTMS.WebAPI.Infrastructure.Persistence.FileSystem;
using AT.UFTMS.WebAPI.Infrastructure.Persistence.Serialization;
using AT.UFTMS.WebAPI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AT.UFTMS.WebAPI.Infrastructure.DependencyInjection;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<FileStorageOptions>();
        services.AddSingleton<FileStorageService>();

        services.AddSingleton<ISerializer, JsonSerializerAdapter>();
        services.AddScoped<ITicketRepository, TicketRepository>();

        return services;
    }
}