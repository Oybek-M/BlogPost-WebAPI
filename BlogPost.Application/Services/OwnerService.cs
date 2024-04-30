using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Enums;
using FluentValidation;
using System.Net;

namespace BlogPost.Application.Services;

public class OwnerService(IUnitOfWork unitOfWork,
                          IValidator<User> validator)
    : IOwnerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<User> _validator = validator;


    public async Task<List<User>> GetAllSuperAdminAsync()
    {
        var superAdmins = await _unitOfWork.User.GetAllAsync();
        superAdmins = superAdmins.Where(u => u.Role == Role.SuperAdmin).ToList();

        return superAdmins;
    }

    public async Task ChangeAdminRoleAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        if (user.Role == Role.Owner)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Jinnilik qilma !!!");
        }

        user.Role = user.Role == Role.SuperAdmin ? Role.Admin : Role.SuperAdmin;
        await _unitOfWork.User.UpdateAsync(user);
    }
}