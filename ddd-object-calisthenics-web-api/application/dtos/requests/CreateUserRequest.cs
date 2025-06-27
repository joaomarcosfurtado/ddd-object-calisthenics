namespace ddd_object_calisthenics_web_api.application.dtos;

public class CreateUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
