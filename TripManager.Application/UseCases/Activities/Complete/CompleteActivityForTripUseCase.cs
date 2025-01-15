using TripManager.Exception;
using TripManager.Exception.ExceptionBase;
using TripManager.Infrastructure;
using TripManager.Infrastructure.Entities;
using TripManager.Infrastructure.Enums;

namespace TripManager.Application.UseCases.Activities.Complete;

public class CompleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new TripDbContext();
        var activity = dbContext
            .Activities
            .FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId);

        Validate(activity);

        activity.Status = ActivityStatus.Done;

        dbContext.Activities.Update(activity);
        dbContext.SaveChanges();
    }

    private void Validate(Activity? activity)
    {
        if (activity is null)
            throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
    }
}
