using System.Net;

namespace TripManager.Exception.ExceptionBase;

public abstract class TripException : System.Exception
{
    public TripException(string message) : base(message)
    {        
    }

    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErroMessages();
}
