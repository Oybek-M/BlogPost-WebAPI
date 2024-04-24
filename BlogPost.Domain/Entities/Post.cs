﻿namespace BlogPost.Domain.Entities;

public class Post : Base
{
    public string ImageUrl { get; set; } = string.Empty; // Image(Url/Path) of Post
    public string Title { get; set; } = string.Empty; // Title of Post
    public string Content { get; set; } = string.Empty; // Content of Post
    public List<HashTag> Tags { get; set; } = new List<HashTag>(); // HashTags
    public int ViewsCount { get; set; } // Vievers
    public int LikeCount { get; set; } // Likes
    public int DislikeCount { get; set; } // DisLikes
    public int CategoryId { get; set; } // Post Category
    public int AuthorId { get; set; } // Post`s Author
    public bool IsEdited { get; set; } = false; // Post is edited after posted ?
    public DateTime EditedTime { get; set; } = DateTime.UtcNow; // If edited, Edited-Time
}