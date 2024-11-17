namespace TripManager.Communication.Requests;

public class RequestRegisterTripJson //INFO: ModelBind
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
