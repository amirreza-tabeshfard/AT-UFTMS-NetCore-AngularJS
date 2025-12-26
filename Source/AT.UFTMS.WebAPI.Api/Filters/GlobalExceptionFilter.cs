using AT.UFTMS.WebAPI.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AT.UFTMS.WebAPI.Api.Filters;
public sealed class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        ApiResponse<string> response =
            ApiResponse<string>.Fail(context.Exception.Message);

        context.Result = new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };

        context.ExceptionHandled = true;
    }
}