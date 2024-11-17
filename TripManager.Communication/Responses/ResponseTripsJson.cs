namespace TripManager.Communication.Response;

public class ResponseTripsJson
{
    public IList<ResponseShortTripJson> Trips { get; set; } = [];
}
