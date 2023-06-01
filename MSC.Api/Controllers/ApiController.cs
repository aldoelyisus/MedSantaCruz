using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using ErrorOr;

using MSC.Api.Common.Http;
using Microsoft.AspNetCore.Authorization;

namespace MSC.Api.Controllers;

[ApiController]
[Authorize]
[Route("error")]
public class ApiController : ControllerBase
{
    private static List<Error>? _errors;

    public IActionResult Problem(List<Error> errors)
    {
        if(errors.Count == 0)
            return Problem();

        _errors = errors;

        if(errors.All(error => error.Type == ErrorType.Validation))
            return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors[0]);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(title: error.Description, statusCode: statusCode);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach(var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }

    public static List<Error> GetErrors()
    {
        return _errors ?? new List<Error>();
    }
}
