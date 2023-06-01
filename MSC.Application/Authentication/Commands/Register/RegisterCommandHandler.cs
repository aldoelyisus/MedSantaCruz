using ErrorOr;
using MediatR;

using MSC.Application.Authentication.Common;
using MSC.Application.Common.Interfaces.Authentication;
using MSC.Application.Common.Interfaces.Persistence;
using MSC.Domain.Common.Errors;
using MSC.Domain.User;

namespace MSC.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate if user not exists already
        if(_userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        // Create user (generate unique ID)
        User user = User.Create(command.Name,
            command.FirstSurname,
            command.LastSurname,
            command.Email,
            command.Password,
            DateTime.UtcNow
        );

        // Persist user
        _userRepository.Add(user);

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}