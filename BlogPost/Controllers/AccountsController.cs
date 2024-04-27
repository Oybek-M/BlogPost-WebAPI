using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlogPost.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromForm] AddUserDto addUserDto)
    {
        var result = await _accountService.RegisterAsync(addUserDto);
        return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto loginDto)
    {
        var result = await _accountService.LoginAsync(loginDto);
        return Ok(result);
    }

    [HttpPost("sendCodeToEmail")]
    public async Task<IActionResult> SendCodeToEmailAsync([FromForm] string email)
    {
        await _accountService.SendCodeToEmailAsync(email);
        return Ok();
    }

    [HttpPost("checkEmailCode")]
    public async Task<IActionResult> CheckEmailCodeAsync([FromForm]string email, [FromForm]string code)
    {
        await _accountService.CheckEmailCodeAsync(email, code);
        return Ok();
    }


    [HttpPost("sendCodeToPhone")]
    public async Task<IActionResult> SendCodeToPhoneAsync([FromForm] string phoneNumber)
    {
        await _accountService.SendCodeToPhoneAsync(phoneNumber);
        return Ok("Coming soon...(with 'Eskiz.uz)");
    }

    [HttpPost("checkPhoneCode")]
    public async Task<IActionResult> CheckPhoneCode([FromForm] string phoneNumber, [FromForm] string code)
    {
        await _accountService.CheckPhoneCodeAsync(phoneNumber, code);
        return Ok("Coming soon...(also)");
    }
}
