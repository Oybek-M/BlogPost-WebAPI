using BlogPost.Domain.Entities;
using BlogPost.Domain.Enums;

namespace BlogPost.Application.DTOs.UserDtos;

public class UpdateUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Gender = dto.Gender
        };
    }
}
