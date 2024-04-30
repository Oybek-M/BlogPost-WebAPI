using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Common.Security;
using BlogPost.Application.Common.Validators;
using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Application.Interfaces;
using BlogPost.Data.Interfaces;
using BlogPost.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace BlogPost.Application.Services;

public class AccountService(IUnitOfWork unitOfWork,
                            IAuthManager authManager,
                            IValidator<User> validator,
                            IMemoryCache memoryCache,
                            IEmailService emailService)
    : IAccountService
{
    public IAuthManager _authManager = authManager;

    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<User> _validator = validator;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly IEmailService _emailService = emailService;

    public async Task<bool> RegisterAsync(AddUserDto addUserDto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(addUserDto.Email);

        if (user is not null)
        {
            throw new StatusCodeException(HttpStatusCode.AlreadyReported, "User already exist");
        }

        var result = await _validator.ValidateAsync(addUserDto);
        if(!result.IsValid)
        {
            throw new ValidatorException(result.GetErrorMessage());
        }

        var model = (User)addUserDto;
        model.Password = PasswordHasher.GetHash(model.Password);

        await _unitOfWork.User.CreateAsync(model);

        return true;
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(loginDto.Email);

        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User nor found");
        }

        if (!user.Password.Equals(PasswordHasher.GetHash(loginDto.Password)))
        {
            throw new StatusCodeException(HttpStatusCode.Conflict, "Password is incorrect");
        }
        if(!user.EmailIsVerified)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, "User(email) is not verified.");
        }

        return _authManager.GeneratedToken(user);
    }

    public async Task SendCodeToEmailAsync(string email)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(email);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");
        }
        
        var code = GeneratedCode();
        _memoryCache.Set(email, code, TimeSpan.FromSeconds(100));
        
        await _emailService.SendMessageToEmailAsync(email, "Verification code!", code);
    }
    
    public async Task<bool> CheckEmailCodeAsync(string email, string code)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(email);
        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
        }

        if(_memoryCache.TryGetValue(email, out var result))
        {
            if(code.Equals(result))
            {
                user.EmailIsVerified = true;
                await _unitOfWork.User.UpdateAsync(user);
                return true;
            }
            else
            {
                throw new StatusCodeException(HttpStatusCode.Conflict, "Code is incorrect");
            }
        }
        else
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is expired");
        }
    }

    public Task SendCodeToPhoneAsync(string phoneNumber)
    {
        // Keyinroq yozishim mumkin
        throw new NotImplementedException();
    }

    public Task<bool> CheckPhoneCodeAsync(string phoneNumber, string code)
    {
        // Keyinroq yozishim mumkin
        throw new NotImplementedException();
    }

    private string GeneratedCode()
    {
        string code;
        code = new Random().Next(10000, 99999).ToString();
        return code;
    }
}
