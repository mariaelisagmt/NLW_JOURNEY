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

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
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

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var useCase = new GetAllTripUseCase();

            var result = useCase.Execute();

            return Ok(result);
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
