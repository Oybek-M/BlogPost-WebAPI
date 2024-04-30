using BlogPost.Application.DTOs.UserDtos;
using BlogPost.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminsController(IAdminService adminService,
                              IUserService userService)
    : ControllerBase
{
    private readonly IAdminService _adminService = adminService;
    private readonly IUserService _userService = userService;

    [HttpGet("admins")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> GetAllAdminAsync()
    {
        var admins = await _adminService.GetAllAdminAsync();
        return Ok(admins);
    }

    [HttpPost("id")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> ChangeUserRoleAsync(int id)
    {
        await _adminService.ChangeUserRoleAsync(id);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> UpdateUserAsync(int targetId, [FromForm]UpdateUserDto updateUserDto)
    {
        var updaterId = int.Parse(HttpContext.User.FindFirst("Id").Value);

        await _userService.UpdateAsync(updaterId, targetId, updateUserDto);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> DeleteUserAsync(int targetId)
    {
        var deleterId = int.Parse(HttpContext.User.FindFirst("Id").Value);

        await _userService.DeleteAsync(deleterId, targetId);
        return Ok();
    }
}
