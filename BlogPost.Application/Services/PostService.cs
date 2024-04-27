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
        /*
        var posts = await _unitOfWork.Post.GetAllAsync();
        posts = posts.Where(p => p.Title == title).ToList();

        if (posts is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post is not found");
        }

        return posts;
        */

        //throw new NotImplementedException();
        throw new StatusCodeException(HttpStatusCode.OK, "Coming soon...");

        /*
        var category = await _unitOfWork.Category.GetByNameAsync(post.Title);
        var models = (PostDto)post;


        model.Category = new Category()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return model;
        */
    }

    public Task<List<PostDto>> GetByCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PostDto> GetByTagAsync(string tagName)
    {
        throw new NotImplementedException();
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

        await _unitOfWork.Post.UpdateAsync((Post)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(id);
        if (post is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post dosn not exist");
        }

        await _unitOfWork.Post.DeleteAsync(post);
    }
}