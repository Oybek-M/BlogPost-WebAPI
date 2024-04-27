using BlogPost.Domain.Entities;

namespace BlogPost.Application.Interfaces;

public interface IOwnerService
{
    Task ChangeAdminRoleAsync(int id);
    Task<List<User>> GetAllSuperAdminAsync();
}
