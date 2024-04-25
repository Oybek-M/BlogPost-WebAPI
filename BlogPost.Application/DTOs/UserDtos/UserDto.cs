using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.UserDtos;

public class UserDto : AddUserDto
{
    public int Id { get; set; }

    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Password = user.Password,
            Gender = user.Gender,
        };
    }
}
