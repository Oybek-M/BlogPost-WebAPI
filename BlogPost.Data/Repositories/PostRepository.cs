using Microsoft.EntityFrameworkCore;

namespace BlogPost.Data.Repositories;

public class PostRepository(AppDbContext dbContext) : GenericRepository<Post>(dbContext), IPostRepository
{
    public async Task<List<Post>> GetByTitleAsync(string title)
    {
        var posts = await _dbContext.Posts.ToListAsync();

        var filteredPosts = posts.Where(p => p.Title.ToLower()
                                 .Contains(title.ToLower()))
                                 .ToList();

        return filteredPosts;
    }
}
