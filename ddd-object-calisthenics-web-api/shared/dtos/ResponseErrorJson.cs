namespace ddd_object_calisthenics_web_api.shared.dtos;

public class ResponseErrorJson
{
    public string Title { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public int Status { get; set; }
    public string TraceId { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public List<string>? ErrorMessages { get; set; }

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;
    }
    public ResponseErrorJson()
    { }
}
