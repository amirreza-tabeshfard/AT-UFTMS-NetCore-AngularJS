namespace AT.UFTMS.WebAPI.Infrastructure.Repositories;
public class TicketRepository(Persistence.Serialization.ISerializer serializer,
                              Persistence.FileSystem.FileStorageService fileStorage,
                              Configuration.FileStorageOptions options)
    : Object
    , Application.Abstractions.Repositories.ITicketRepository
{
    #region Field(s)
    
    private readonly Persistence.Serialization.ISerializer _serializer = serializer;
    private readonly Persistence.FileSystem.FileStorageService _fileStorage = fileStorage;
    private readonly Configuration.FileStorageOptions _options = options;

    #endregion

    #region Implemetation: ITicketRepository

    Domain.Entities.Ticket? Application.Abstractions.Repositories.ITicketRepository.GetById(Guid id)
    {
        string path = BuildTicketPath(id);
        string? content = _fileStorage.Load(path);

        if (content is null)
            return null;

        return _serializer.Deserialize<Domain.Entities.Ticket>(content);
    }

    IReadOnlyList<Domain.Entities.Ticket> Application.Abstractions.Repositories.ITicketRepository.GetByUserId(Guid userId)
    {
        List<Domain.Entities.Ticket> result = new();

        IEnumerable<string> files = _fileStorage.GetFiles(_options.BasePath, "*.ticket");
        
        foreach (string? content in from string file in files
                                    let content = _fileStorage.Load(file)
                                    select content)
        {
            if (content is null)
                continue;

            Domain.Entities.Ticket ticket = _serializer.Deserialize<Domain.Entities.Ticket>(content);
            if (ticket.CreatedByUserId == userId)
                result.Add(ticket);
        }

        return result.AsReadOnly();
    } 
    
    void Application.Abstractions.Repositories.ITicketRepository.Add(Domain.Entities.Ticket ticket)
    {
        string path = BuildTicketPath(ticket.Id);
        string serializedTicket = _serializer.Serialize(ticket);

        _fileStorage.Save(path, serializedTicket);
    }

    void Application.Abstractions.Repositories.ITicketRepository.Update(Domain.Entities.Ticket ticket)
    {
        string path = BuildTicketPath(ticket.Id);
        string serializedTicket = _serializer.Serialize(ticket);
        _fileStorage.Save(path, serializedTicket);
    }

    #endregion

    #region Private Method(s)

    private string BuildTicketPath(Guid ticketId)
    {
        return Path.Combine(_options.BasePath, $"{ticketId}.ticket");
    }

    #endregion
}