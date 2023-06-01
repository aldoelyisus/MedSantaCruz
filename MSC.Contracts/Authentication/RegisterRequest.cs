namespace MSC.Contracts.Authentication;

public record RegisterRequest(
    string Name,
    string FirstSurname,
    string LastSurname,
    string Email,
    string Password
);