using BlogPost.Domain.Entities;

namespace BlogPost.Application.Interfaces;

public interface IOwnerService
{
    Task<List<User>> GetAllSuperAdminAsync();
    Task ChangeAdminRoleAsync(int id);
}
