using Microsoft.AspNetCore.Mvc;
using TripManager.Application.UseCases.Trips.Register;
using TripManager.Communication.Requests;

namespace TripManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        var useCase = new RegisterTripUseCase();
        
        useCase.Execute(request);

        return Created();
    }
}
