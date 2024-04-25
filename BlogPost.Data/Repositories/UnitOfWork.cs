namespace BlogPost.Data.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public IUserRepository User => new UserRepository(_appDbContext);

    public IPostRepository Post => new PostRepository(_appDbContext);

    public ICategoryRepository Category => new CategoryRepository(_appDbContext);

    public ICommentRepository Comment => new CommentRepository(_appDbContext);

    public IHashTagRepository HashTag => new HashTagRepository(_appDbContext);
}
