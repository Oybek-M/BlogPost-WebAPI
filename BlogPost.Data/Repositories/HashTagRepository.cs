
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Data.Repositories;

public class HashTagRepository(AppDbContext dbContext) : GenericRepository<HashTag>(dbContext), IHashTagRepository
{
    public async Task<HashTag> GetByNameAsync(string name)
    {
        var hashTag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Name == name);
        return hashTag;
    }
}
