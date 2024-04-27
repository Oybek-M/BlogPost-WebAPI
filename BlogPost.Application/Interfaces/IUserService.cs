using BlogPost.Application.DTOs.UserDtos;

namespace BlogPost.Application.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> GetByEmailAsync(string email);
    Task<UserDto> GetByPhoneAsync(string phone);
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(int id);
}
