using System.Net;

namespace TripManager.Exception.ExceptionBase;

public class ErrorOnValidationException : TripException
{
    public ErrorOnValidationException(string message) : base(message)
    {        
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
}
