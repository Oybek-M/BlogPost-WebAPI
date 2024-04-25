using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.CategoryDtos;

public class AddCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static implicit operator Category(AddCategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }
}
