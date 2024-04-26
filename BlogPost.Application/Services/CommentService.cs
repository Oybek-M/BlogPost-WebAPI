using BlogPost.Application.DTOs.CommentDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using FluentValidation;

namespace BlogPost.Application.Services;

public class CommentService(IUnitOfWork unitOfWork, IValidator validator) : ICommentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator _validator = validator;

    public async Task CreateAsync(AddCommentDto dto)
    {
        var comment = await _unitOfWork.Comment.GetByIdAsync(dto.Id);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CommentDto dto)
    {
        throw new NotImplementedException();
    }
}
