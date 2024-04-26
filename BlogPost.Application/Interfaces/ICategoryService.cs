using BlogPost.Application.DTOs.CategoryDtos;

namespace BlogPost.Application.Interfaces;

public interface ICategoryService
{
    Task CreateAsync(AddCategoryDto dto);
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<CategoryDto> GetByNameAsync(string name);
    Task UpdateAsync(CategoryDto dto);
    Task DeleteAsync(int id);
}
