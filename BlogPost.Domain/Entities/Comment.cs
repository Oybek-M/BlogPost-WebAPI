namespace BlogPost.Domain.Entities;

public class Comment : Base
{
    public int PostId {  get; set; } // Post ID
    public int UserId { get; set; } // Comment`s author
    public string CommentText { get; set; } = string.Empty; // Comment`s body

}
