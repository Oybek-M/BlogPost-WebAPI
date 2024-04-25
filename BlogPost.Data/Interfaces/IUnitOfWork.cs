namespace BlogPost.Data.Interfaces;

public interface IUnitOfWork
{
    IUserRepository User { get; }
    IPostRepository Post { get; }
    ICategoryRepository Category { get; }
    ICommentRepository Comment { get; }
    IHashTagRepository HashTag { get; }
}