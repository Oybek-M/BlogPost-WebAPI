namespace BlogPost.Domain.Entities;

public class Base
{
    public int Id { get; set; } // General UID
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // General DateTime
}