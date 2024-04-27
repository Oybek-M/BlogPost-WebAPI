using BlogPost.Application.DTOs.PostDtos;

namespace BlogPost.Application.Interfaces;

public interface IPostService
{
    Task CreateAsync(AddPostDto dto);
    Task<List<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(int id);
    Task<List<PostDto>> GetByTitleAsync(string title);
    Task<List<PostDto>> GetByCategoryAsync(int id); // Category ID
    Task<List<PostDto>> GetByTagAsync(string tagName);
    Task UpdateAsync(PostDto dto);
    Task DeleteAsync(int id);
}
