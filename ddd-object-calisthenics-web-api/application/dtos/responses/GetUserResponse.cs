namespace ddd_object_calisthenics_web_api.application.dtos.responses;

public class GetUserResponse
{
    public Guid Id { get; init; }
    public string Email { get; init; } = string.Empty;
}
