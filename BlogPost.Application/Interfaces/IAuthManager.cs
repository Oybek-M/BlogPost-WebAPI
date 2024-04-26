using BlogPost.Domain.Entities;

namespace BlogPost.Application.Interfaces;

public interface IAuthManager
{
    string GeneratedToken(User user);
}
