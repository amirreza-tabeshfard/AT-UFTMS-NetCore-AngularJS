namespace AT.UFTMS.WebAPI.Application.UseCases.Tickets.CreateTicket;
public class CreateTicketUseCase(Abstractions.Repositories.ITicketRepository ticketRepository,
                                 Abstractions.Services.ICurrentUserService currentUserService,
                                 CreateTicketValidator validator)
{
    #region Field(s)
    
    private readonly Abstractions.Repositories.ITicketRepository _ticketRepository = ticketRepository;
    private readonly Abstractions.Services.ICurrentUserService _currentUserService = currentUserService;
    private readonly CreateTicketValidator _validator = validator;

    #endregion

    #region Public Method(s)
    
    public DTOs.Responses.CreateTicketResponseDto Execute(DTOs.Requests.CreateTicketRequestDto request)
    {
        _validator.Validate(request);

        Domain.Entities.Ticket ticket = new(Guid.NewGuid(),
                                            request.Title,
                                            request.Description,
                                            request.Type,
                                            request.Priority,
                                            _currentUserService.UserId);

        _ticketRepository.Add(ticket);

        return new DTOs.Responses.CreateTicketResponseDto
        {
            TicketId = ticket.Id
        };
    } 

    #endregion
}