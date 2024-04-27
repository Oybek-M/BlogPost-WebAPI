using BlogPost.Application.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Interfaces;

public interface ICommentService
{
    Task CreateAsync(AddCommentDto dto);
    Task<List<CommentDto>> GetAllAsync();
    Task<CommentDto> GetByIdAsync(int id);
    Task UpdateAsync(CommentDto dto);
    Task DeleteAsync(int id);
}
