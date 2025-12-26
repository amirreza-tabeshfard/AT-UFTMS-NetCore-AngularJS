using Microsoft.Extensions.DependencyInjection;

namespace AT.UFTMS.WebAPI.Application.DependencyInjection;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Use Cases
        services.AddScoped<UseCases.Tickets.CreateTicket.CreateTicketUseCase>();
        services.AddScoped<UseCases.Tickets.CloseTicket.CloseTicketUseCase>();
        services.AddScoped<UseCases.Tickets.CreateTicket.CreateTicketValidator>();

        // Policies
        services.AddScoped<Policies.Tickets.ITicketClosePolicy, Policies.Tickets.DefaultTicketClosePolicy>();

        // DomainEvent
        services.AddScoped<Common.IDomainEventHandler<Domain.Events.TicketClosedDomainEvent>, EventHandlers.Tickets.TicketClosedEventHandler>();

        services.AddScoped<Queries.Tickets.Specifications.TicketReadSpecification>();

        return services;
    }
}