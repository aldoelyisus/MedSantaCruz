using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ErrorOr;
using MapsterMapper;
using MediatR;

using MSC.Application.Authentication.Commands.Register;
using MSC.Application.Authentication.Common;
using MSC.Application.Authentication.Queries.Login;
using MSC.Contracts.Authentication;
using MSC.Domain.Common.Errors;

namespace MSC.Api.Controllers;

[AllowAnonymous]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResponse => Ok(_mapper.Map<AuthenticationResponse>(authResult.Value)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        // Ver si se puede mover esto a errores especficos del controlador
        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
            );
        }

        return authResult.Match(
            authResponse => Ok(_mapper.Map<AuthenticationResponse>(authResult.Value)),
            errors => Problem(errors)
        );
    }
}