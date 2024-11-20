using Microsoft.EntityFrameworkCore;
using TripManager.Exception;
using TripManager.Exception.ExceptionBase;
using TripManager.Infrastructure;

namespace TripManager.Application.UseCases.Trips.Register;

public class DeleteByIdTripUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new TripDbContext();

        var trip = dbContext.Trips.Include(x => x.Activities).FirstOrDefault(x => x.Id == id);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }

        dbContext.Trips.Remove(trip);
        dbContext.SaveChanges();
    }
}
