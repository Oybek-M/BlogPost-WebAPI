using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.HashTagDtos;

public class AddTagDto
{
    public string Name { get; set; } = string.Empty;

    public static implicit operator HashTag(AddTagDto dto)
    {
        return new HashTag
        {
            Name = dto.Name
        };
    }
}
