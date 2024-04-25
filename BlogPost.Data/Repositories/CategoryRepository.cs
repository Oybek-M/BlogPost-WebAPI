
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Data.Repositories;

public class CategoryRepository(AppDbContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
{
    public async Task<Category> GetByNameAsync(string name)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        return category;
    }
}