using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Common.Helper;
using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using System.Net;

namespace BlogPost.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();
        return users.Select(u => (UserDto)u).ToList();
    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(email);
        if(user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task<UserDto> GetByPhone(string phone)
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

        await _unitOfWork.User.UpdateAsync(user);
        throw new StatusCodeException(HttpStatusCode.OK, "User has been updated succesfully");
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if(user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        await _unitOfWork.User.DeleteAsync(user);
        throw new StatusCodeException(HttpStatusCode.OK, "User has been deleted sucessfully");
    }
}
