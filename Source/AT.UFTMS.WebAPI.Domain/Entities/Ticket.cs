namespace AT.UFTMS.WebAPI.Domain.Entities;
public class Ticket : Common.Entity
{
    #region Constructor (Rehydration)

    [System.Text.Json.Serialization.JsonConstructor]
    private Ticket(Guid id,
                   Guid createdByUserId,
                   string title,
                   string description,
                   Enums.TicketType type,
                   Enums.TicketPriority priority,
                   Enums.TicketStatus status,
                   DateTime createdAt)
        : base(id)
    {
        CreatedByUserId = createdByUserId;
        Title = title;
        Description = description;
        Type = type;
        Priority = priority;
        Status = status;
        CreatedAt = createdAt;
    }

    #endregion

    #region Constructor (Protected - Domain)

    protected Ticket(Guid id) 
        : base(id)
    {
    }

    #endregion

    #region Properties

    public Guid CreatedByUserId { get; private set; }

    public string Title { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public Enums.TicketType Type { get; private set; }

    public Enums.TicketPriority Priority { get; private set; }

    public Enums.TicketStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    #endregion

    #region State Pattern (Runtime Behavior)

    private Tickets.States.ITicketState _state = null!;

    private void InitializeState()
    {
        _state = Tickets.States.TicketStateFactory.Create(Status);
    }

    internal void SetState(Tickets.States.ITicketState state)
    {
        _state = state;
        Status = state.Status;
    }

    #endregion

    #region Factory Method (Creation)

    public static Ticket Create(string title,
                                string description,
                                Enums.TicketType type,
                                Enums.TicketPriority priority,
                                Guid createdByUserId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new Exceptions.DomainException("Title is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new Exceptions.DomainException("Description is required.");

        Ticket ticket = new(Guid.NewGuid())
        {
            Title = title,
            Description = description,
            Type = type,
            Priority = priority,
            Status = Enums.TicketStatus.New,
            CreatedByUserId = createdByUserId,
            CreatedAt = DateTime.UtcNow
        };

        ticket.InitializeState();
        return ticket;
    }

    #endregion

    #region Behavior (State Transitions)

    public void StartProgress()
    {
        _state.StartProgress(this);
    }

    public void Answer()
    {
        _state.Answer(this);
    }

    public void Close()
    {
        _state.Close(this);
    }

    public void Close(Guid closedByUserId)
    {
        _state.Close(this);
        AddDomainEvent(new Events.TicketClosedDomainEvent(Id, closedByUserId));
    }

    #endregion
}