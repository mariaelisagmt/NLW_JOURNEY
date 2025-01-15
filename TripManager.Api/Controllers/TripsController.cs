using Microsoft.AspNetCore.Mvc;
using TripManager.Application.UseCases.Activities.Complete;
using TripManager.Application.UseCases.Activities.Register;
using TripManager.Application.UseCases.Trips.Register;
using TripManager.Communication.Requests;
using TripManager.Communication.Responses;

namespace TripManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        var useCase = new RegisterTripUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTripUseCase();
        var result = useCase.Execute();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetByIdTripUseCase();
        var result = useCase.Execute(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteByIdTripUseCase();
        useCase.Execute(id);
        return NoContent();
    }

    [HttpPost]
    [Route("{tripId}/activity")]
    [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
    public IActionResult RegisterActivity(
        [FromRoute] Guid tripId,
        [FromBody] RequestRegisterActivityJson request)
    {
        var useCase = new RegisterActivityForTripUseCase();
        var response = useCase.Execute(tripId, request);
        return Created(string.Empty, response);

    }

    [HttpPut]
    [Route("{tripId}/activity/{activityId}/complete")]
    [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
    public IActionResult CompleteActivity(
        [FromRoute] Guid tripId,
        [FromRoute] Guid activityId)
    {
        var useCase = new CompleteActivityForTripUseCase();
        useCase.Execute(tripId, activityId);
        return NoContent();
    }

    [HttpDelete]
    [Route("{tripId}/activity/{activityId}/delete")]
    [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteActivity(
        [FromRoute] Guid tripId,
        [FromRoute] Guid activityId)
    {
        var useCase = new CompleteActivityForTripUseCase();
        useCase.Execute(tripId, activityId);
        return NoContent();
    }
}
