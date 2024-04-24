namespace BlogPost.Domain.Entities;

public class Category : Base
{
    public string Name { get; set; } = string.Empty; // Category Name
    public string Description {  get; set; } = string.Empty; // Category Description
}
