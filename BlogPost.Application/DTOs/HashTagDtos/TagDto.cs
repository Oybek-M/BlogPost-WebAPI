using BlogPost.Domain.Entities;

namespace BlogPost.Application.DTOs.HashTagDtos;

public class HashTagDto : AddTagDto
{
    public int Id { get; set; }

    public static implicit operator HashTagDto(HashTag tag)
    {
        return new HashTagDto()
        {
            Id = tag.Id,
            Name = tag.Name
        };
    }


    public static implicit operator HashTag(HashTagDto dto)
    {
        return new HashTag()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}
