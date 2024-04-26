using BlogPost.Application.DTOs.UserDtos;

namespace BlogPost.Application.Interfaces;

public interface IAccountService
{
    Task<bool> RegisterAsync(AddUserDto addUserDto);
    Task<string> LoginAsync(LoginDto loginDto);
    Task SendCodeToEmailAsync(string email);
    Task<bool> CheckEmailCodeAsync(string email, string code);
    Task SendCodeToPhoneAsync(string phoneNumber);
    Task<bool> CheckPhoneCodeAsync(string phoneNumber, string code);
}
