namespace AT.UFTMS.WebAPI.Infrastructure.Persistence.Serialization;
public class BinaryJsonSerializerAdapter 
    : Object
    , ISerializer
{
    #region Implemetation: ISerializer

    string ISerializer.Serialize<T>(T data)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(data);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
        return Convert.ToBase64String(bytes);
    }

    T ISerializer.Deserialize<T>(string content)
    {
        byte[] bytes = Convert.FromBase64String(content);
        string json = System.Text.Encoding.UTF8.GetString(bytes);
        return System.Text.Json.JsonSerializer.Deserialize<T>(json)!;
    } 

    #endregion
}