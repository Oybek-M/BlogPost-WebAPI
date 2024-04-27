using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Interfaces;

public interface IAdminService
{
    Task<List<User>> GetAllAdminAsync();
    Task ChangeUserRoleAsync(int id);
}
