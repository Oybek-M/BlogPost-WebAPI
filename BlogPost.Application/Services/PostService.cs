using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Common.Validators;
using BlogPost.Application.DTOs.PostDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;

public class PostService(IUnitOfWork unitOfWork,
                         IValidator<Post> validator)
    : IPostService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Post> _validator = validator;

    public async Task CreateAsync(AddPostDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessage());

        var category = await _unitOfWork.Category.GetByIdAsync(dto.CategoryId);
        if(category is null)
        {
            throw new StatusCodeException(HttpStatusCode.Conflict, "Category is not found with this ID");
        }

        await _unitOfWork.Post.CreateAsync((Post)dto);
    }

    public async Task<List<PostDto>> GetAllAsync()
    {
        var posts = await _unitOfWork.Post.GetAllAsync();
        var categories = await _unitOfWork.Category.GetAllAsync();

        var models = new List<PostDto>();

        foreach (var post in posts)
        {
            var category = categories.First(p => p.Id == post.CategoryId);
            var dto = (PostDto)post;
            dto.Category = new Category()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };

            models.Add(dto);
        }

        return models;
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(id);
        if (post is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post is not found");
        }

        var category = await _unitOfWork.Category.GetByIdAsync(post.CategoryId);
        var model = (PostDto)post;


        model.Category = new Category()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return model;
    }

    public async Task<List<PostDto>> GetByTitleAsync(string title)
    {
        var posts = await _unitOfWork.Post.GetByTitleAsync(title);
        if (!posts.Any())
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post(s) is not found");
        }
        
        var postsModel = posts
            .Select(item => (PostDto)item).ToList();
        
        return postsModel;
    }

    public async Task<List<PostDto>> GetByCategoryAsync(int categoryId)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(categoryId);
        if (category is null)
        {
            throw new StatusCodeException(HttpStatusCode.Conflict, "Category is not found with this ID, so no posts either");
        }

        var posts = await _unitOfWork.Post.GetByCategoryAsync(categoryId);

        if (!posts.Any())
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post(s) is not found");
        }

        var postsModel = posts
            .Select(item => (PostDto)item).ToList();

        posts.Clear();
        return postsModel;
    }

    public Task<List<PostDto>> GetByTagAsync(string tagName)
    {
        throw new StatusCodeException(HttpStatusCode.NotImplemented, "Coming soon(works on service)");
    }

    public async Task UpdateAsync(PostDto dto)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(dto.Id);
        if(post is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post does not exist");
        }

        var result = await _validator.ValidateAsync(dto);
        if(!result.IsValid)
        {
            throw new ValidationException(result.GetErrorMessage());
        }

        dto.IsEdited = true;
        dto.EditedTime = DateTime.Now;

        await _unitOfWork.Post.UpdateAsync((Post)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(id);
        if (post is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post is not found");
        }

        await _unitOfWork.Post.DeleteAsync(post);
    }
}