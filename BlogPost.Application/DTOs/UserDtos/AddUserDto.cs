using BlogPost.Domain.Entities;
using BlogPost.Domain.Enums;

namespace BlogPost.Application.DTOs.UserDtos;

public class AddUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(AddUserDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Password = dto.Password,
            Gender = dto.Gender,
        };
    }
}
