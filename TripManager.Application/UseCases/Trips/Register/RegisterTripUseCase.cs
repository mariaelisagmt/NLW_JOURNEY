using TripManager.Communication.Requests;
using TripManager.Communication.Response;
using TripManager.Exception;
using TripManager.Exception.ExceptionBase;
using TripManager.Infrastructure;
using TripManager.Infrastructure.Entities;

namespace TripManager.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public ResponseShortTripJson Execute(RequestRegisterTripJson request)
    {
        Validate(request);

        var dbContext = new TripDbContext();
        
        var entity = new Trip
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        dbContext.Trips.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            EndDate = entity.EndDate,
            StartDate = entity.StartDate,
            Name = entity.Name,
            Id = entity.Id
        };
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
