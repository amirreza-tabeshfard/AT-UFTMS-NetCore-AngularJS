namespace AT.UFTMS.WebAPI.Infrastructure.Persistence.FileSystem;
public class FileStorageService
{
    #region Public Method(s)
    
    public void Save(string path, string content)
    {
        string directory = Path.GetDirectoryName(path)!;
        Directory.CreateDirectory(directory);
        File.WriteAllText(path, content);
    }

    public string? Load(string path)
    {
        if (!File.Exists(path))
            return null;

        return File.ReadAllText(path);
    }

    public IEnumerable<string> GetFiles(string directory, string pattern)
    {
        if (!Directory.Exists(directory))
            return Enumerable.Empty<string>();

        return Directory.GetFiles(directory, pattern);
    } 

    #endregion
}