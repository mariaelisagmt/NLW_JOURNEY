using Microsoft.AspNetCore.Mvc;
using TripManager.Application.UseCases.Trips.Register;
using TripManager.Communication.Requests;
using TripManager.Exception.ExceptionBase;

namespace TripManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        try
        {
            var useCase = new RegisterTripUseCase();

            useCase.Execute(request);

            return Created();
        }
        catch (TripException ex) 
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro desconhecido"); //TODO Forma de retirar mensagens via HARD CODE
        }
    }
}
