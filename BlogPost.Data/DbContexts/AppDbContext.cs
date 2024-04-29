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
                Password = "186cf774c97b60a1c106ef718d10970a6a06e06bef89553d9ae65d938a886eae",
                EmailIsVerified = true,
                PhoneIsVerified = true,
                Role = Role.Owner
            });
    }
}
