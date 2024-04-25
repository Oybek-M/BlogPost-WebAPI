using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.PostDtos;

public class PostDto : AddPostDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int ViewsCount { get; set; }
    public int LikesCount { get; set; }
    public int DislikesCount {  get; set; }
    public int AuthorId { get; set; }
    public bool IsEdited { get; set; } = false;
    public DateTime EditedTime { get; set; } = DateTime.UtcNow;

    public Category Category { get; set; } = null;

    public static implicit operator PostDto(Post post)
    {
        return new PostDto()
        {
            Id = post.Id,
            ImageUrl = post.ImageUrl,
            Title = post.Title,
            Content = post.Content,
            Tags = post.Tags,
            CategoryId = post.CategoryId,
            ViewsCount = post.ViewsCount,
            LikesCount = post.LikesCount,
            DislikesCount = post.DislikesCount,
            AuthorId = post.AuthorId,
            IsEdited = post.IsEdited,
            EditedTime = post.EditedTime
        };
    }
}
