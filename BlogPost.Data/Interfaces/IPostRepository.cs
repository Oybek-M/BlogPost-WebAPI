namespace BlogPost.Data.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetByTitleAsync(string title);
}
