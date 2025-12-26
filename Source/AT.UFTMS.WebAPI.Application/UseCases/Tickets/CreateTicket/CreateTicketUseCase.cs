namespace AT.UFTMS.WebAPI.Application.UseCases.Tickets.CreateTicket;
public class CreateTicketUseCase(Abstractions.Repositories.ITicketRepository ticketRepository,
                                 Abstractions.Services.ICurrentUserService currentUserService,
                                 CreateTicketValidator validator)
{
    public DTOs.Responses.CreateTicketResponseDto Execute(DTOs.Requests.CreateTicketRequestDto request)
    {
        validator.Validate(request);

        Domain.Entities.Ticket ticket = Domain.Entities.Ticket.Create(request.Title!,
                                                                      request.Description!,
                                                                      request.Type,
                                                                      request.Priority,
                                                                      currentUserService.UserId);

        ticketRepository.Add(ticket);

        return new DTOs.Responses.CreateTicketResponseDto(ticket.Id);
    }
}