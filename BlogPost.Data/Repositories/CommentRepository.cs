namespace BlogPost.Data.Repositories;

public class CommentRepository(AppDbContext dbContext) : GenericRepository<Comment>(dbContext), ICommentRepository
{ }
