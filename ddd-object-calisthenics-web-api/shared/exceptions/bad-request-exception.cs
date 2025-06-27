using System.Net;

namespace ddd_object_calisthenics_web_api.shared.exceptions;

public class BadRequestException : ExceptionBase
{
    private readonly List<string> _errors;

    public BadRequestException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages ?? new List<string>();
    }

    public BadRequestException(string errorMessage) : base(string.Empty)
    {
        _errors = [errorMessage];
    }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
