namespace AT.UFTMS.WebAPI.Domain.Entities;
public class Ticket : Common.Entity
{
    #region Constructor
    
    public Ticket(Guid id,
                  string? title,
                  string? description,
                  Enums.TicketType type,
                  Enums.TicketPriority priority,
                  Guid createdByUserId)
        : base(id)
    {
        SetTitle(title);
        SetDescription(description);

        Type = type;
        Priority = priority;
        Status = Enums.TicketStatus.New;

        CreatedByUserId = createdByUserId;
        CreatedAt = DateTime.UtcNow;
    } 

    #endregion

    #region Properties

    public Guid CreatedByUserId { get; private set; }

    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public Enums.TicketType Type { get; private set; }

    public Enums.TicketPriority Priority { get; private set; }

    public Enums.TicketStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    #endregion

    #region Private Method(s)

    private void SetTitle(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new Exceptions.DomainException("Title is required.");

        Title = title;
    }

    private void SetDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new Exceptions.DomainException("Description is required.");

        Description = description;
    }

    #endregion

    #region Public Method(s)
    
    public void StartProgress()
    {
        if (Status != Enums.TicketStatus.New)
            throw new Exceptions.DomainException("Only new tickets can be started.");

        Status = Enums.TicketStatus.InProgress;
    }

    public void Answer()
    {
        if (Status != Enums.TicketStatus.InProgress)
            throw new Exceptions.DomainException("Only tickets in progress can be answered.");

        Status = Enums.TicketStatus.Answered;
    }

    public void Close()
    {
        if (Status == Enums.TicketStatus.Closed)
            throw new Exceptions.DomainException("Ticket is already closed.");

        Status = Enums.TicketStatus.Closed;
    } 

    #endregion
}