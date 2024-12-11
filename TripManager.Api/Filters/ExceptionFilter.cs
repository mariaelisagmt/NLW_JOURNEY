using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TripManager.Communication.Responses;
using TripManager.Exception.ExceptionBase;

namespace TripManager.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TripException)
        {
            TripException tripException = (TripException)context.Exception;
            
            context.HttpContext.Response.StatusCode = (int)tripException.GetStatusCode();

            var responseJson = new ResponseErrosJson(tripException.GetErroMessages());
            
            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var responseJson = new ResponseErrosJson(["Erro desconhecido"]);
            context.Result = new ObjectResult(responseJson);
        }
    }
}
