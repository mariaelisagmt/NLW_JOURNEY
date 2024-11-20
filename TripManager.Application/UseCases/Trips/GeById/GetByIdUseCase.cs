using Microsoft.EntityFrameworkCore;
using TripManager.Communication.Requests;
using TripManager.Communication.Response;
using TripManager.Exception;
using TripManager.Exception.ExceptionBase;
using TripManager.Infrastructure;

namespace TripManager.Application.UseCases.Trips.Register;

public class GetByIdUseCase
{
    public ResponseTripJson Execute(Guid id)
    {
        var dbContext = new TripDbContext();

        var trip = dbContext.Trips.Include(x => x.Activities).FirstOrDefault(x => x.Id == id);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }

        return new ResponseTripJson
        {
            Id = trip.Id,
            Name = trip.Name,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Activities = trip.Activities
            .Select(activity => new ResponseActivityJson 
            {
                Id = activity.Id,
                Name = activity.Name,
                Date = activity.Date,
                Status = (Communication.Enums.ActivityStatus)activity.Status,
            })
            .ToList(),
        };
    }
}
