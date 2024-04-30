using BlogPost.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController(IOwnerService ownerService,
                             IUserService userService)
    : ControllerBase
{
    private readonly IOwnerService _ownerService = ownerService;
    private readonly IUserService _userService = userService;

    [HttpGet("superAdmins")]
    [Authorize(Roles = "Owner")]
    public async Task<IActionResult> GetAllSuperAdminAsync()
    {
        var superAdmins = await _ownerService.GetAllSuperAdminAsync();
        return Ok(superAdmins);
    }

    [HttpPost("id")]
    [Authorize(Roles = "Owner")]
    public async Task<IActionResult> ChangeAdminRoleAsync(int id)
    {
        await _ownerService.ChangeAdminRoleAsync(id);
        return Ok();
    }
}
