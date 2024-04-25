namespace BlogPost.Data.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByPhoneAsync(string phoneNumber);
}