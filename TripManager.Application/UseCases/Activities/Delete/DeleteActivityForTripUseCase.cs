using TripManager.Exception;
using TripManager.Exception.ExceptionBase;
using TripManager.Infrastructure;

namespace TripManager.Application.UseCases.Trips.Register;

public class DeleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new TripDbContext();

        var activity = dbContext.Activities.FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId);

        if (activity is null)
            throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);

        dbContext.Activities.Remove(activity);
        dbContext.SaveChanges();
    }
}
