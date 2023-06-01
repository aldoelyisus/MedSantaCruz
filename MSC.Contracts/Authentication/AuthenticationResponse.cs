namespace MSC.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string Name,
    string FirstSurname,
    string LastSurname,
    string Email,
    string Token
);