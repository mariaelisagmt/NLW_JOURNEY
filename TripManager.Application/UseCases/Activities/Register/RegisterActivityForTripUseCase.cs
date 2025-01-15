using Microsoft.EntityFrameworkCore;
using TripManager.Communication.Requests;
using TripManager.Communication.Responses;
using TripManager.Exception;
using TripManager.Exception.ExceptionBase;
using TripManager.Infrastructure;
using TripManager.Infrastructure.Entities;
using FluentValidation.Results;
using TripManager.Communication.Enums;

namespace TripManager.Application.UseCases.Activities.Register;

public class RegisterActivityForTripUseCase
{
    public ResponseActivityJson? Execute(Guid tripId, RequestRegisterActivityJson request)
    {
        var dbContext = new TripDbContext();
        var trip = dbContext
            .Trips
            .Include(trip => trip.Activities)
            .FirstOrDefault(trip => trip.Id == tripId);

        Validate(trip, request);

        var entity = new Activity
        {
            Name = request.Name,
            Date = request.Date,
            TripId = tripId,
        };
         
        dbContext.Activities.Add(entity);
        dbContext.SaveChanges();

        return new ResponseActivityJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Date = entity.Date,
            Status = (ActivityStatus)entity.Status,
        };
    }

    private void Validate(Trip? trip, RequestRegisterActivityJson request)
    {
        if (trip is null)
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);

        var validator = new RegisterActivityValidator();
        var result = validator.Validate(request);

        if (!(request.Date >= trip.StartDate && request.Date <= trip.EndDate)) 
        {
            result.Errors.Add(new ValidationFailure("Date", ResourceErrorMessages.DATE_NOT_WITHIN_TRAVEL_PERIOD));
        }
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
