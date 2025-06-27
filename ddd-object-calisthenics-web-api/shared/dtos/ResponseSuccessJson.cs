namespace ddd_object_calisthenics_web_api.shared.dtos;

public class ResponseSuccessJson<T>(int statusCode, string message, T? data, string? traceId = null, string? path = null)
{
    public int StatusCode { get; set; } = statusCode;
    public string Message { get; set; } = message;
    public string? TraceId { get; set; } = traceId;
    public string? Path { get; set; } = path;
    public T? Data { get; set; } = data;
}
