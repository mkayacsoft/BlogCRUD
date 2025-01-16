using BlogCRUD.Services.Categories.Create;
using BlogCRUD.Services.Categories.Update;

namespace BlogCRUD.Services.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoryWithPostsDto>> GetCategoryWithPost(int categoryId);
        Task<ServiceResult<List<CategoryWithPostsDto>>> GetCategoryWithPost();
        Task<ServiceResult<List<CategoryDto>>> GetAllAsync();
        Task<ServiceResult<CategoryDto>> GetById(int id);
        Task<ServiceResult<CreateCategoryResponse>> CreateCategoryAsync(CreateCategoryRequest request);
        Task<ServiceResult> UpdateCategoryAsync(int id,UpdateCategoryRequest updateCategoryRequest);

        Task<ServiceResult> DeleteCategoryAsync(int id);






    }
}
