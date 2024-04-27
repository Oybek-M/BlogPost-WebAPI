using System.Net;
using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Common.Validators;
using BlogPost.Application.DTOs.CommentDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using FluentValidation;

namespace BlogPost.Application.Services;

public class CommentService(IUnitOfWork unitOfWork, IValidator<Comment> validator) : ICommentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Comment> _validator = validator;

    public async Task CreateAsync(AddCommentDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
        {
            throw new ValidationException(result.GetErrorMessage());
        }

        await _unitOfWork.Comment.CreateAsync((Comment)dto);
    }
    
    public async Task<List<CommentDto>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comment.GetAllAsync();
        var commentsModel = comments
            .Select(item => (CommentDto)item).ToList();
        
        return commentsModel;
    }

    public async Task<CommentDto> GetByIdAsync(int id)
    {
        var comment = await _unitOfWork.Comment.GetByIdAsync(id);
        if (comment is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Comment is not found");
        }

        return (CommentDto)comment;
    }

    public async Task DeleteAsync(int id)
    {
        var comment = await _unitOfWork.Comment.GetByIdAsync(id);
        if (comment is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Comment is not found");
        }

        await _unitOfWork.Comment.DeleteAsync(comment);
    }

    public async Task UpdateAsync(CommentDto dto)
    {
        var comment = await _unitOfWork.Comment.GetByIdAsync(dto.Id);
        if (comment is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Comment is not found");
        }

        await _unitOfWork.Comment.UpdateAsync((Comment)dto);
    }
}
