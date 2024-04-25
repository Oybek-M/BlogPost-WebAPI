using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.CategoryDtos;

public class CategoryDto : AddCategoryDto
{
    public int Id { get; set; }

    public static implicit operator CategoryDto(Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public static implicit operator Category(CategoryDto dto)
    {
        return new Category()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description
        };
    }
}
