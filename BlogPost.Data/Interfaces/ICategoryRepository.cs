namespace BlogPost.Data.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetByNameAsync(int id);
}
