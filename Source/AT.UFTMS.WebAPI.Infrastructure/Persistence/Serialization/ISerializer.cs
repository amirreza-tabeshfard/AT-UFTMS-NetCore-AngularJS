namespace AT.UFTMS.WebAPI.Infrastructure.Persistence.Serialization;
public interface ISerializer
{
    string Serialize<T>(T data);

    T Deserialize<T>(string content);
}