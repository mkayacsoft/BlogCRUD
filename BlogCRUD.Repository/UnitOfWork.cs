namespace BlogCRUD.Repository
{
    public class UnitOfWork(ApplicationDbContext context): IUnitOfWork
    {
        private readonly ApplicationDbContext _context=context;
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();

        }
    }
}
