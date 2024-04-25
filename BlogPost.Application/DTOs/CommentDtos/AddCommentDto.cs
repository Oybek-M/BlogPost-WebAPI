using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.CommentDtos;

public class AddCommentDto
{
    public string CommentText {  get; set; } = string.Empty;

    public static implicit operator Comment(AddCommentDto dto)
    {
        return new Comment
        {
            CommentText = dto.CommentText
        };
    }
}
