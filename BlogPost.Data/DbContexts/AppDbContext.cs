using BlogPost.Domain.Entities;
using BlogPost.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<HashTag> Tags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Oybek",
                LastName = "Muxtaraliyev",
                PhoneNumber = "+998941061243",
                Email = "oybekmuxtaraliyev@gmail.com",
                Gender = Gender.Male,
                Password = "a117bab00ec44e1aaf315bdfb86e0698fed13725d4e6202b7ae6ad051525fd17",
                Role = Role.Owner
            });
    }
}
