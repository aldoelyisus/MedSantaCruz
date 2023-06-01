using ErrorOr;

namespace MSC.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail = Error.Conflict(
            code: "User.DuplicateEmail",
            description: "This email is already registered with another user"
        );
    }
}