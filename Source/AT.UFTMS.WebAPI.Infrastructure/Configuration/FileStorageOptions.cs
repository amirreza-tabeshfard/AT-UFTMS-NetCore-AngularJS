namespace AT.UFTMS.WebAPI.Infrastructure.Configuration;
public class FileStorageOptions
{
    public FileStorageOptions()
    {
        BasePath = Path.Combine(
            AppContext.BaseDirectory,
            "Storage",
            "Tickets"
        );
    }

    public string BasePath { get; set; }
}