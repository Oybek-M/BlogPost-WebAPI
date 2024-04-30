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
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromForm]AddPostDto addPostDto)
    {
        await _postService.CreateAsync(addPostDto);
        return Ok();
    }

    [HttpGet("posts")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        var posts = await _postService.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("id")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var post = await _postService.GetByIdAsync(id);
        return Ok(post);
    }

    [HttpGet("title")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByTitleAsync(string title)
    {
        var post =  await _postService.GetByTitleAsync(title);
        return Ok(post);
    }

    [HttpGet("category")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByCategoryAsync(int id)
    {
        var post = await _postService.GetByCategoryAsync(id);
        return Ok(post);
    }

    [HttpGet("tag")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByTag(string tag)
    {
        var post = await _postService.GetByTagAsync(tag);
        return Ok(post);
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
