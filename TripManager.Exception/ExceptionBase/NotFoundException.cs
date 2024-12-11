using System.Net;

namespace TripManager.Exception.ExceptionBase;

public class NotFoundException(string message) : TripException(message)
{
    public override IList<string> GetErroMessages()
    {
        return [ Message ];
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }
}
