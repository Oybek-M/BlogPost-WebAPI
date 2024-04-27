using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Common.Validators;
using BlogPost.Application.DTOs.CategoryDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using FluentValidation;
using System.Net;

namespace BlogPost.Application.Services;

public class CategoryService(IUnitOfWork unitOfWork,
                              IValidator<Category> validator)
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Category> _validator = validator;

    public async Task CreateAsync(AddCategoryDto dto)
    {
        var category = await _unitOfWork.Category.GetByNameAsync(dto.Name);
        if(category is not null)
        {
            throw new StatusCodeException(HttpStatusCode.AlreadyReported, "Category is already exist");
        }

        var result = await _validator.ValidateAsync(dto);
        if(!result.IsValid)
        {
            throw new ValidatorException(result.GetErrorMessage());
        }

        await _unitOfWork.Category.CreateAsync((Category)dto);
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Category.GetAllAsync();
        return categories.Select(c => (CategoryDto)c).ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if(category is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category is not found");
        }

        return (CategoryDto)category;
    }

    public async Task<CategoryDto> GetByNameAsync(string name)
    {
        var category = await _unitOfWork.Category.GetByNameAsync(name);
        if (category is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category is not found");
        }

        return (CategoryDto)category;
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(dto.Id);
        if( category is null )
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category does not exist");
        }

        var result = await _validator.ValidateAsync(dto);
        if(!result.IsValid)
        {
            throw new ValidationException(result.GetErrorMessage());
        }

        await _unitOfWork.Category.UpdateAsync((Category)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if(category is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category does not exist");
        }

        await _unitOfWork.Category.DeleteAsync(category);
    }
}
