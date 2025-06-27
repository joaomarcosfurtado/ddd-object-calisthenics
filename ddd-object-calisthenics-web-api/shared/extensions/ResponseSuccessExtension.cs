using ddd_object_calisthenics_web_api.shared.dtos;
using Microsoft.AspNetCore.Mvc;

namespace ddd_object_calisthenics_web_api.shared.extensions;

public static class ResponseSuccessExtensions
{
    public static IActionResult ToSuccessResponse<T>(
        this ControllerBase controller,
        int statusCode = StatusCodes.Status200OK,
        T? data = default,
        string? message = null)
    {
        string traceId = controller.HttpContext.TraceIdentifier;
        PathString path = controller.HttpContext.Request.Path;
        string finalMessage = !string.IsNullOrEmpty(message) ? message : "Operation completed successfully";

        ResponseSuccessJson<T> response = new(
            statusCode,
            finalMessage,
            data,
            traceId,
            path
        );

        return new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }

    public static IActionResult ToSuccessResponse(
        this ControllerBase controller,
        int statusCode = StatusCodes.Status200OK,
        string? message = null
    )
    {
        string traceId = controller.HttpContext.TraceIdentifier;
        PathString path = controller.HttpContext.Request.Path;
        string finalMessage = !string.IsNullOrEmpty(message) ? message : "Operation completed successfully";

        ResponseSuccessJson<object> response = new(
            statusCode,
            finalMessage,
            null,
            traceId,
            path
        );

        return new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }

}
