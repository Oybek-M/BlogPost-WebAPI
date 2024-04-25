using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.CommentDtos;

public class CommentDto : AddCommentDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }

    public static implicit operator CommentDto(Comment comment)
    {
        return new CommentDto()
        {
            Id = comment.Id,
            PostId = comment.PostId,
            UserId = comment.UserId,
            CommentText = comment.CommentText
        };
    }

    public static implicit operator Comment(CommentDto dto)
    {
        return new Comment()
        {
            Id = dto.Id,
            PostId = dto.PostId,
            UserId = dto.UserId,
            CommentText = dto.CommentText
        };
    }
}
