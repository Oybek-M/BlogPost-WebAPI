using BlogPost.Application.DTOs.PostDtos;
using BlogPost.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService = postService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm]AddPostDto addPostDto)
    {
        await _postService.CreateAsync(addPostDto);
        return Ok();
    }

    [HttpGet("posts")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        await _postService.GetAllAsync();
        return Ok();
    }

    [HttpGet("id")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        await _postService.GetByIdAsync(id);
        return Ok();
    }

    [HttpGet("title")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByTitleAsync(string title)
    {
        await _postService.GetByTitleAsync(title);
        return Ok();
    }

    [HttpGet("category")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByCategoryAsync(int id)
    {
        await _postService.GetByCategoryAsync(id);
        return Ok();
    }

    [HttpGet("tag")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByTag(string tag)
    {
        await _postService.GetByTagAsync(tag);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync([FromForm]PostDto postDto)
    {
        await _postService.UpdateAsync(postDto);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _postService.DeleteAsync(id);
        return Ok();
    }
}
