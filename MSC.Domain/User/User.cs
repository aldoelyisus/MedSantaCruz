using MSC.Domain.Common.Models;
using MSC.Domain.User.ValueObjects;

namespace MSC.Domain.User;

 public class User : AggregateRoot<UserId>
{
    public string Name { get; set; } = null!;
    public string FirstSurname { get; set; } = null!;
    public string LastSurname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }

    private User(UserId id, string name, string firstSurname, string lastSurname, string email, string password, DateTime registrationDate) : base(id)
    {
        Name = name;
        FirstSurname = firstSurname;
        LastSurname = lastSurname;
        Email = email;
        Password = password;
        RegistrationDate = registrationDate;
    }

    public static User Create(string name, string firstSurname, string lastSurname, string email, string password, DateTime registrationDate)
    {
        return new(UserId.CreateUnique(), name, firstSurname, lastSurname, email, password, registrationDate);
    }
}