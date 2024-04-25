namespace BlogPost.Data.Interfaces;

public interface IHashTagRepository : IGenericRepository<HashTag>
{
    Task<HashTag> GetByNameAsync(string name);
}
