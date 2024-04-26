using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Enums;
using FluentValidation;
using System.Net;

namespace BlogPost.Application.Services;

public class AdminService(IUnitOfWork unitOfWork, IValidator<User> validator) : IAdminService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<User> _validator = validator;

    public async Task ChangeUserRoleAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        if(user.Role == Role.SuperAdmin)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, "SuperAdmin faqatgina 'Owner' ga bo'ysunadi");
        }
        user.Role = user.Role == Role.Admin ? Role.User : Role.Admin;

        await _unitOfWork.User.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        await _unitOfWork.User.DeleteAsync(user);
    }

    public async Task<List<User>> GetAllAdminAsync()
    {
        var admins = await _unitOfWork.User.GetAllAsync();
        admins = admins.Where(u => u.Role == Role.Admin).ToList();

        return admins;
    }
}
