namespace BlogPost.Data.Interfaces;

public interface IGenericRepository<T>
{
    Task CreateAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
