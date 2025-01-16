using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUD.Repository.Categories
{
    public class CategoryRepository(ApplicationDbContext context)
        : GenericRepository<Category>(context), ICategoryRepository
    {
        public Task<Category?> GetCategoryWithPostsAsync(int id)
        {
            return context.Categories.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Category> GetCategoryWithPosts()
        {
            return context.Categories.Include(x => x.Posts).AsQueryable();
        }
    }

}
