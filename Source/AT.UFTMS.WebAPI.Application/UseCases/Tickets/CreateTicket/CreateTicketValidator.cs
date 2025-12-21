namespace AT.UFTMS.WebAPI.Application.UseCases.Tickets.CreateTicket;
public class CreateTicketValidator
{
    public void Validate(DTOs.Requests.CreateTicketRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ApplicationException("Title is required.");

        if (string.IsNullOrWhiteSpace(request.Description))
            throw new ApplicationException("Description is required.");
    }
}