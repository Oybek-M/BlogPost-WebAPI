using BlogPost.Application.DTOs.UserDtos;

namespace BlogPost.Application.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetById(int id);
    Task<UserDto> GetByEmail(string email);
    Task<UserDto> GetByPhone(string phone);
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(int id);
}
