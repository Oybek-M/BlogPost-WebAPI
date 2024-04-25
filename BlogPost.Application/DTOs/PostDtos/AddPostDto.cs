using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.PostDtos;

public class AddPostDto
{
    public string Title { get; set; } = string.Empty;
    public string Content {  get; set; } = string.Empty;
    public List<HashTag> Tags { get; set; }
    public int CategoryId { get; set; }

    public static implicit operator Post(AddPostDto dto)
    {
        return new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            Tags = dto.Tags,
            CategoryId = dto.CategoryId
        };
    }
}
