namespace BlogCRUD.Repository.Categories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category?> GetCategoryWithPostsAsync(int id);
        IQueryable<Category> GetCategoryWithPosts();
    }
}
