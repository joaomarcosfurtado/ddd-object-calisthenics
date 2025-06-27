
using ddd_object_calisthenics_web_api.shared.dtos;
using ddd_object_calisthenics_web_api.shared.exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ddd_object_calisthenics_web_api.shared.filter;

public class ExceptionFilter() : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExceptionBase)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        ExceptionBase exceptionBase = (ExceptionBase)context.Exception;
        ResponseErrorJson errorResponse = new(exceptionBase.GetErrors())
        {
            Title = "Validation Error",
            Detail = "Entrance validation error.",
            Status = exceptionBase.StatusCode,
            TraceId = context.HttpContext.TraceIdentifier,
            Path = context.HttpContext.Request.Path
        };

        context.HttpContext.Response.StatusCode = exceptionBase.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnkowError(ExceptionContext context)
    {
        if (context.Exception is SystemException ex)
            // _logger.LogError("EXCEPTION_FILTER", ex);
            Console.WriteLine($"EXCEPTION_FILTER: {ex.Message}, exception: {ex}");

        ResponseErrorJson errorResponse = new()
        {
            Title = "Unknown error.",
            Detail = "Unknown error ocurred try again later.",
            Status = StatusCodes.Status500InternalServerError,
            TraceId = context.HttpContext.TraceIdentifier,
            Path = context.HttpContext.Request.Path
        };

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
