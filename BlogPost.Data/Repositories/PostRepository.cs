using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogPost.Data.Repositories;

public class PostRepository(AppDbContext dbContext)
    : GenericRepository<Post>(dbContext), IPostRepository
{
    public async Task<List<Post>> GetByTitleAsync(string title)
    {
        var posts = await _dbContext.Posts.ToListAsync();

        var filteredPosts = posts.Where(p => p.Title.ToLower()
                                 .Contains(title.ToLower()))
                                 .ToList();

        posts.Clear();
        return filteredPosts;
    }

    public async Task<List<Post>> GetByCategoryAsync(int categoryId)
    {
        var posts = await _dbContext.Posts.ToListAsync();
        var filteredPosts = posts
            .Where(p => p.CategoryId == categoryId).ToList();

        posts.Clear();
        return filteredPosts;
    }

    public async Task<List<Post>> GetByTagAsync(string hashTag)
    {
        var posts = await _dbContext.Posts.ToListAsync();
        var filteredPosts = new List<Post>();

        filteredPosts = posts
            .Where(post => post.Tags.Contains(hashTag))
            .ToList();

        posts.Clear();
        return filteredPosts;
    }
}
