namespace AT.UFTMS.WebAPI.Infrastructure.Exceptions;
public class InfrastructureException 
    : Exception
{
    public InfrastructureException(string message)
        : base(message)
    {
    }
}