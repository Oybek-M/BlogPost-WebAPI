namespace BlogPost.Domain.Entities;

public class Comment : Base
{
    public long PostId {  get; set; } // Post ID
    public long UserId { get; set; } // Comment`s author
    public string CommentText { get; set; } = string.Empty; // Comment`s body
}
