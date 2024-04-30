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

        // User(model) => UserDto(model)
        var userModels = new List<UserDto>();
        foreach (var user in users)
        {
            var userDto = (UserDto)user;
            userModels.Add(userDto);
        }

        return userModels;
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
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task<UserDto> GetByPhoneAsync(string phone)
    {
        var user = await _unitOfWork.User.GetByPhoneAsync(phone);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        return (UserDto)user;
    }

    public async Task UpdateAsync(int updaterId, int targetId, UpdateUserDto dto)
    {
        var updaterUser = await _unitOfWork.User.GetByIdAsync(updaterId);

        if (updaterId != targetId && updaterUser.Role == Role.User)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable, "Your role is not accepted to update a user");
        }
        else
        {
            var model = await _unitOfWork.User.GetByIdAsync(targetId);

            // Target User is not null
            if (model is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
            }


            var user = (User)dto;
            user.Id = targetId;
            user.CreatedAt = TimeHelper.GetCurrentTime();
            user.Password = model.Password;

            if (model.Email != dto.Email)
            {
                user.EmailIsVerified = false;
            }

            if (model.PhoneNumber != dto.PhoneNumber)
            {
                user.PhoneIsVerified = false;
            }


            await _unitOfWork.User.UpdateAsync(user);
            throw new StatusCodeException(HttpStatusCode.OK, "User has been updated succesfully");
        }
    }

    public async Task DeleteAsync(int deleterId, int targetId)
    {
        var deleterUser = await _unitOfWork.User.GetByIdAsync(deleterId);

        if (deleterId != targetId && deleterUser.Role == Role.User)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable, "Your role is not accepted to delete a user");
        }
        else
        {
            var targetUser = await _unitOfWork.User.GetByIdAsync(targetId);

            // Target User is not null
            if (targetUser is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
            }


            if (targetUser.Role == Role.Owner)
            {
                throw new StatusCodeException(HttpStatusCode.Conflict, "Egalikni boshqaga o'tkazish KK");
            }
            else if (targetUser.Role == Role.SuperAdmin)
            {
                throw new StatusCodeException(HttpStatusCode.Conflict, "SuperAdmin larni faqat Owner boshqara oladi");
            }
            else if (targetUser.Role == Role.Admin)
            {
                throw new StatusCodeException(HttpStatusCode.Conflict, "Admin larni faqat SuperAdmin boshqara oladi");
            }


            await _unitOfWork.User.DeleteAsync(targetUser);
            throw new StatusCodeException(HttpStatusCode.OK, "User has been deleted sucessfully");
        }
    }
}
