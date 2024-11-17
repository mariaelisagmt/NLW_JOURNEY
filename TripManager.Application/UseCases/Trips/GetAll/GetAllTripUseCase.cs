using TripManager.Communication.Response;
using TripManager.Infrastructure;

namespace TripManager.Application.UseCases.Trips.Register;

public class GetAllTripUseCase
{
    public ResponseTripsJson Execute()
    {
        var dbContext = new TripDbContext();

        var trips = dbContext.Trips.ToList();

        return new ResponseTripsJson
        {
            Trips = trips.Select(trip => new ResponseShortTripJson
            {
                Id = trip.Id,
                Name = trip.Name,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate
            })
            .ToList()
        };
    }
}
