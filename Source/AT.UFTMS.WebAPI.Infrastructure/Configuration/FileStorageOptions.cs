namespace AT.UFTMS.WebAPI.Infrastructure.Configuration;
public class FileStorageOptions
{
    public FileStorageOptions()
    {
        BasePath = "Storage/Tickets";
    }

    public string BasePath { get; set; }
}