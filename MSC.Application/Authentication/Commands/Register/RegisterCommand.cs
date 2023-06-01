using ErrorOr;
using MediatR;

using MSC.Application.Authentication.Common;

namespace MSC.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Name,
    string FirstSurname,
    string LastSurname,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;