using System.Net;

namespace TripManager.Exception.ExceptionBase;

public class NotFoundException : TripException
{
    public NotFoundException(string message) : base(message)
    {        
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }
}
