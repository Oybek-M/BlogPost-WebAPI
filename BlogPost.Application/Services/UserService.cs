using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Common.Helper;
using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using System.Net;
using BlogPost.Domain.Enums;

namespace BlogPost.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();
        return users.Select(u => (UserDto)u).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task<UserDto> GetByEmailAsync(string email)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(email);
        if(user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task<UserDto> GetByPhoneAsync(string phone)
    {
        var user = await _unitOfWork.User.GetByPhoneAsync(phone);
        if(user is null )
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {
        var model = await _unitOfWork.User.GetByIdAsync(id);
        if(model is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }
        
        var user = (User)dto;
        user.Id = id;
        user.CreatedAt = TimeHelper.GetCurrentTime();
        user.Password = model.Password;

        if (model.Email == dto.Email)
        {
            user.EmailIsVerified = false;
        }

        if (model.PhoneNumber == dto.PhoneNumber)
        {
            user.PhoneIsVerified = false;
        }

        await _unitOfWork.User.UpdateAsync(user);
        throw new StatusCodeException(HttpStatusCode.OK, "User has been updated succesfully");
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user.Role == Role.Owner)
        {
            throw new StatusCodeException(HttpStatusCode.Conflict, "Egalikni boshqaga o'tkazish KK");
        } else if (user.Role == Role.SuperAdmin)
        {
            throw new StatusCodeException(HttpStatusCode.Conflict, "SuperAdmin larni faqat Owner boshqara oladi");
        } else if (user.Role == Role.Admin)
        {
            throw new StatusCodeException(HttpStatusCode.Conflict, "Admin larni faqat SuperAdmin boshqara oladi");
        }

        if(user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        await _unitOfWork.User.DeleteAsync(user);
        throw new StatusCodeException(HttpStatusCode.OK, "User has been deleted sucessfully");
    }
}
