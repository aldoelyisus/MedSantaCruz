using MSC.Application.Common.Interfaces.Persistence;
using MSC.Domain.User;

namespace MSC.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    //static because is instanced as scoped
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        // if(user == null)
        //     throw new ArgumentNullException();

        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        if(email == null)
            throw new ArgumentNullException();

        return _users.SingleOrDefault(user => user.Email == email);
    }
}