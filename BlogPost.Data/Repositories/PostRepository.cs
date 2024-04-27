using Microsoft.EntityFrameworkCore;

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

        return filteredPosts;
    }

    public async Task<List<Post>> GetByCategoryAsync(int categoryId)
    {
        var posts = await _dbContext.Posts.ToListAsync();

        var filteredPosts = posts.
            Where(p => p.CategoryId == categoryId).ToList();

        return filteredPosts;
    }

    async Task<List<Post>> GetByTagAsync(string hashTag)
    {
        var posts = await _dbContext.Posts.ToListAsync();
        var filteredPosts = new List<Post>();

        foreach (var post in posts)
        {
            if (post.Tags.Contains(hashTag))
            {
                filteredPosts.Add(post);
            }
        }

        return filteredPosts;
    }
}
