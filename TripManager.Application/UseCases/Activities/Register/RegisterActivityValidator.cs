using FluentValidation;
using TripManager.Communication.Requests;
using TripManager.Exception;

namespace TripManager.Application.UseCases.Activities.Register;

public class RegisterActivityValidator : AbstractValidator<RequestRegisterActivityJson>
{
    public RegisterActivityValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
    }
}
