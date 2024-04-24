using BlogPost.Domain.Entities;
using BlogPost.Domain.Enums;

namespace Domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = string.Empty; // User`s Firstname
    public string LastName { get; set; } = string.Empty; // Users`s Lastname
    public string PhoneNumber { get; set; } = string.Empty; // User`s Phonenumber
    public bool PhoneIsVerified { get; set; } = false; // User`s phonenumber is Verified
    public string Email { get; set; } = string.Empty; // User`s Email
    public bool EmailIsVerified { get; set; } = false; // User`s email is Verified
    public string Password { get; set; } = string.Empty; // User`s Password
    public Gender Gender { get; set; } // User`s Gender
    public Role Role { get; set; } = Role.User; // User`s Role in App(lication)
}