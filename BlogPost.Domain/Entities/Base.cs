namespace BlogPost.Domain.Entities;

public class Base
{
    public long Id { get; set; } // General UID
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // General DateTime
}