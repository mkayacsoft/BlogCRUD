namespace BlogCRUD.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
