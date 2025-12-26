using Microsoft.Extensions.DependencyInjection;

namespace AT.UFTMS.WebAPI.Infrastructure.DependencyInjection;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<Configuration.FileStorageOptions>();
        
        services.AddSingleton<Persistence.FileSystem.FileStorageService>();
        services.AddSingleton<Persistence.Serialization.ISerializer, Persistence.Serialization.JsonSerializerAdapter>();

        services.AddScoped<Application.Abstractions.Repositories.ITicketRepository, Repositories.TicketRepository>();
        services.AddScoped<Application.Common.IDomainEventDispatcher, DomainEvents.DomainEventDispatcher>();

        services.AddScoped<Application.Queries.Tickets.ITicketReadRepository, Queries.Tickets.FileTicketReadRepository>();

        services.AddScoped<Application.Queries.Tickets.GetMyTickets.GetMyTicketsQuery>();

        return services;
    }
}