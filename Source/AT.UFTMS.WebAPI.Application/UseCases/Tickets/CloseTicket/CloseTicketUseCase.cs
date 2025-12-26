namespace AT.UFTMS.WebAPI.Application.UseCases.Tickets.CloseTicket;
public class CloseTicketUseCase(Abstractions.Repositories.ITicketRepository ticketRepository,
                                Abstractions.Authorization.IAuthorizationService authorizationService,
                                Abstractions.Services.ICurrentUserService currentUserService,
                                Policies.Tickets.ITicketClosePolicy closePolicy,
                                Common.IDomainEventDispatcher domainEventDispatcher)
{
    public void Execute(Guid ticketId)
    {
        Domain.Entities.Ticket ticket = ticketRepository.GetById(ticketId) ?? throw new InvalidOperationException("Ticket not found.");
        authorizationService.EnsureUserIsTicketOwner(ticket.CreatedByUserId);
        closePolicy.Validate(ticket);
        ticket.Close(currentUserService.UserId);
        ticketRepository.Update(ticket);
        ticket.ClearDomainEvents();
    }

    public async Task ExecuteAsync(Guid ticketId,
                                   CancellationToken cancellationToken)
    {
        Domain.Entities.Ticket ticket = ticketRepository.GetById(ticketId)
                                        ?? throw new InvalidOperationException("Ticket not found.");

        authorizationService.EnsureUserIsTicketOwner(ticket.CreatedByUserId);
        ticket.Close(currentUserService.UserId);
        ticketRepository.Update(ticket);
        await domainEventDispatcher.DispatchAsync(ticket.DomainEvents, cancellationToken);
        ticket.ClearDomainEvents();
    }
}