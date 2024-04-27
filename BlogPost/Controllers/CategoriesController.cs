using BlogPost.Application.DTOs.CategoryDtos;
using BlogPost.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddCategoryDto addCategoryDto)
    {
        await _categoryService.CreateAsync(addCategoryDto);
        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        await _categoryService.GetAllAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        await _categoryService.GetByIdAsync(id);
        return Ok();
    }

    [HttpGet("{name}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByNameAsync(string name)
    {
        await _categoryService.GetByNameAsync(name);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync([FromForm]CategoryDto addCategoryDto)
    {
        await _categoryService.UpdateAsync(addCategoryDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok();
    }
}
