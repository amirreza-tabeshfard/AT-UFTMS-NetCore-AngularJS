namespace AT.UFTMS.WebAPI.Domain.Common;
public abstract class Entity
{
    public Guid Id { get; protected set; }

    protected Entity(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.");

        Id = id;
    }
}