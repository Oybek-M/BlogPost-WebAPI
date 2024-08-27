using Microsoft.EntityFrameworkCore;

namespace BlogPost.Data.Repositories;

public class UserRepository(AppDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(m => m.Email == email);
        return user;
    }

    public async Task<User> GetByPhoneAsync(string phoneNumber)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
        return user;
    }
}
