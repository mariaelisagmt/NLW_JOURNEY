using TripManager.Communication.Requests;
using TripManager.Exception;
using TripManager.Exception.ExceptionBase;

namespace TripManager.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            throw new TripException(ResourceErrorMessages.NAME_EMPTY);
        
        if (request.StartDate.Date < DateTime.UtcNow.Date)
            throw new TripException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);

        if (request.EndDate.Date < request.StartDate.Date)
            throw new TripException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
    }
}
