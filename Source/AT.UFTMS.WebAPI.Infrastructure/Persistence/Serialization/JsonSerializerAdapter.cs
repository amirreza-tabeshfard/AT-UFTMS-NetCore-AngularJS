namespace AT.UFTMS.WebAPI.Infrastructure.Persistence.Serialization;
public class JsonSerializerAdapter
    : Object
    , ISerializer
{
    #region Implementation: ISerializer
    
    T ISerializer.Deserialize<T>(string content)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(content)!;
    }

    string ISerializer.Serialize<T>(T data)
    {
        return System.Text.Json.JsonSerializer.Serialize(data);
    } 

    #endregion
}