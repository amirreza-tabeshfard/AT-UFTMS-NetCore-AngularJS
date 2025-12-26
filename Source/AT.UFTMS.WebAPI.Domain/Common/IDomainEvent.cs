namespace AT.UFTMS.WebAPI.Domain.Common;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}