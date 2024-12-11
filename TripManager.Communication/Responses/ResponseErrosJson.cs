namespace TripManager.Communication.Responses;

public class ResponseErrosJson
{
    public IList<string> Errors { get; set; } = [];

    public ResponseErrosJson(IList<string> errors)
    {
        Errors = errors;
    }
}
