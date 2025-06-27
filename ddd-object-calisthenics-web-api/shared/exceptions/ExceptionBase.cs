namespace ddd_object_calisthenics_web_api.shared.exceptions;

public abstract class ExceptionBase : SystemException
{
    public abstract int StatusCode { get; }

    protected ExceptionBase(string message)
        : base(message)
    {
    }

    public abstract List<string> GetErrors();
}