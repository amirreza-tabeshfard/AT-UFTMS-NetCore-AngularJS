namespace AT.UFTMS.WebAPI.Infrastructure.Queries.Tickets;
public class FileTicketReadRepository 
    : Application.Queries.Tickets.ITicketReadRepository
{
    private const string BasePath = "Storage/ReadModels";

    IReadOnlyList<Application.Queries.Tickets.Models.TicketReadModel> Application.Queries.Tickets.ITicketReadRepository.GetByUserId(Guid userId)
    {
        if (!Directory.Exists(BasePath))
            return Array.Empty<Application.Queries.Tickets.Models.TicketReadModel>();

        return Directory.GetFiles(BasePath, "*.read")
            .Select(f => File.ReadAllText(f))
            .Select(c => System.Text.Json.JsonSerializer.Deserialize<Application.Queries.Tickets.Models.TicketReadModel>(c)!)
            .Where(t => t.Id != Guid.Empty)
            .ToList();
    }

    Application.Queries.Tickets.Models.TicketReadModel? Application.Queries.Tickets.ITicketReadRepository.GetById(Guid id)
    {
        string path = Path.Combine(BasePath, $"{id}.read");
        if (!File.Exists(path)) return null;

        return System.Text.Json.JsonSerializer.Deserialize<Application.Queries.Tickets.Models.TicketReadModel>(
            File.ReadAllText(path));
    }
}