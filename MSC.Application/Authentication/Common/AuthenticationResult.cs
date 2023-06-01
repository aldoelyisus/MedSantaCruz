using MSC.Domain.User;

namespace MSC.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);
