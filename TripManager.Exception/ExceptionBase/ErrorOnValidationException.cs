using System.Net;

namespace TripManager.Exception.ExceptionBase;

public class ErrorOnValidationException : TripException
{
    private readonly IList<string> _errors;
    public ErrorOnValidationException(IList<string> messages) : base(string.Empty)
    {    
        _errors = messages;
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
    public override IList<string> GetErroMessages()
    {
        return _errors;
    }
}
