using BlogPost.Application.DTOs.PostDtos;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Interfaces;

public interface IHashTagService
{
    Task CreateAsync(AddPostDto dto);
    Task<List<HashTag>> GetAllAsync();
    Task<HashTag> GetByIdAsync(int id);
    Task<HashTag> GetByNameAsync(string tagName);
    Task UpdateAsync(PostDto dto);
    Task DeleteAsync(int id);
}
