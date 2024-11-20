using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TripManager.Exception.ExceptionBase;

namespace TripManager.Api.Filters;

public class ExceptionFilter<T> : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TripException)
        {
            var tripException = (TripException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)tripException.GetStatusCode();
            context.Result = new ObjectResult(context.Exception.Message);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult("Erro Desconhecido!");
        }
    }
}
