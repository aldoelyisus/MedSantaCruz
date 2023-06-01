using ErrorOr;
using MediatR;

using MSC.Application.Authentication.Common;
using MSC.Application.Common.Interfaces.Authentication;
using MSC.Application.Common.Interfaces.Persistence;
using MSC.Domain.Common.Errors;

namespace MSC.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate user already exists
        var user = _userRepository.GetUserByEmail(query.Email);

        if(user is null)
            return Errors.Authentication.InvalidCredentials;

        // Validate the password is correct
        if(user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}