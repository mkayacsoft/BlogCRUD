using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Repository.Categories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category?> GetCategoryWithPostsAsync(int id);
        IQueryable<Category> GetCategoryWithPosts();
    }
}
