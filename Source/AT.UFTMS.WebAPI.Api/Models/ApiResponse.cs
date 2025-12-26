namespace AT.UFTMS.WebAPI.Api.Models;
public sealed class ApiResponse<T>
{
    public bool Success { get; }
    public T? Data { get; }
    public string? Error { get; }

    private ApiResponse(bool success, T? data, string? error)
    {
        Success = success;
        Data = data;
        Error = error;
    }

    public static ApiResponse<T> Ok(T data)
        => new(true, data, null);

    public static ApiResponse<T> Fail(string error)
        => new(false, default, error);
}