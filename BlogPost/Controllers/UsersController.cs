using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("users")]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("id")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("email")]
    [Authorize]
    public async Task<IActionResult> GetByEmailAsync(string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        return Ok(user);
    }

    [HttpGet("phoneNumber")]
    [Authorize]
    public async Task<IActionResult> GetByPhoneAsync(string phoneNumber)
    {
        var user =  await _userService.GetByPhoneAsync(phoneNumber);
        return Ok(user);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAsync(int targetId, [FromForm] UpdateUserDto dto)
    {
        var updaterId = int.Parse(HttpContext.User.FindFirst("Id").Value);

        await _userService.UpdateAsync(updaterId, targetId, dto);
        return Ok();
    }

    [HttpDelete("id")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(int targetId)
    {
        var deleterId = int.Parse(HttpContext.User.FindFirst("Id").Value);

        await _userService.DeleteAsync(deleterId, targetId);
        return Ok();
    }
}
