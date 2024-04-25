namespace BlogPost.Data.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    ICommentRepository Comment { get; }
    IHashTagRepository HashTag { get; }
    IPostRepository Post { get; }
    IUserRepository User { get; }
}