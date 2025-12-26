namespace AT.UFTMS.WebAPI.Application.Queries.Tickets;
public sealed class FileTicketReadRepository 
    : ITicketReadRepository
{
    private const string BasePath = "Storage/ReadModels";

    IReadOnlyList<Models.TicketReadModel> ITicketReadRepository.GetByUserId(Guid userId)
    {
        if (!Directory.Exists(BasePath))
            return Array.Empty<Models.TicketReadModel>();

        return Directory.GetFiles(BasePath, "*.read")
                        .Select(File.ReadAllText)
                        .Select(json => System.Text.Json.JsonSerializer.Deserialize<Models.TicketReadModel>(json)!)
                        .ToList();
    }

    Models.TicketReadModel? ITicketReadRepository.GetById(Guid id)
    {
        string path = Path.Combine(BasePath, $"{id}.read");
        if (!File.Exists(path)) return null;

        return System.Text.Json.JsonSerializer.Deserialize<Models.TicketReadModel>(File.ReadAllText(path));
    }
}