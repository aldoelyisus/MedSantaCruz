using ErrorOr;
using MediatR;
using MSC.Application.Authentication.Common;

namespace MSC.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
