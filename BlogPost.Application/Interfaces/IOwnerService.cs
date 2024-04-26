using BlogPost.Domain.Entities;

namespace BlogPost.Application.Interfaces;

public interface IOwnerService
{
    Task ChangeUserRoleAsync(int id);
    Task<List<User>> GetAllSuperAdminAsync();
}
