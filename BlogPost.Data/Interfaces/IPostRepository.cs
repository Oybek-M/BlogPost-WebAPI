namespace BlogPost.Data.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetByTitleAsync(string title);
    Task<List<Post>> GetByCategoryAsync(int categoryId);
    Task<List<Post>> GetByTagAsync(string hashTag);
}
