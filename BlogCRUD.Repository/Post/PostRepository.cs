namespace BlogCRUD.Repository.Post
{
    public class PostRepository(ApplicationDbContext context) : GenericRepository<Post>(context),IPostRepository
    {

    }
}
