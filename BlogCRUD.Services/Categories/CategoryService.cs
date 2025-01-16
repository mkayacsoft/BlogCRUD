using AutoMapper;
using BlogCRUD.Repository;
using BlogCRUD.Repository.Categories;
using BlogCRUD.Services.Categories.Create;
using BlogCRUD.Services.Categories.Update;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlogCRUD.Services.Categories
{
    public class CategoryService(ICategoryRepository _categoryRepository,IUnitOfWork _uniyOfWork,IMapper _mapper):ICategoryService
    {
        public async Task<ServiceResult<CategoryWithPostsDto>> GetCategoryWithPost(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryWithPostsAsync(categoryId);

            if (category is null)
            {
                return ServiceResult<CategoryWithPostsDto>.Failure("Category not found",HttpStatusCode.NotFound);
            }

            var categoryWithPostsDto =  _mapper.Map<CategoryWithPostsDto>(category);

            return ServiceResult<CategoryWithPostsDto>.Success(categoryWithPostsDto);

        }  
        public async Task<ServiceResult<List<CategoryWithPostsDto>>> GetCategoryWithPost()
        {
            var category = await _categoryRepository.GetCategoryWithPosts().ToListAsync();

            var categoryWithPostsDto =  _mapper.Map<List<CategoryWithPostsDto>>(category);

            return ServiceResult<List<CategoryWithPostsDto>>.Success(categoryWithPostsDto);

        }  

        public async Task<ServiceResult<List<CategoryDto>>> GetAllAsync()
        {
            var result = await _categoryRepository.GetAll().ToListAsync();
            var categoryAsDto = _mapper.Map<List<CategoryDto>>(result);

            return ServiceResult<List<CategoryDto>>.Success(categoryAsDto);

        }

        public async Task<ServiceResult<CategoryDto>> GetById(int id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);

            if (result is null)
            {
                return ServiceResult<CategoryDto>.Failure("Category not found",HttpStatusCode.NotFound);
            }

            var categoryAsDto = _mapper.Map<CategoryDto>(result);

            return ServiceResult<CategoryDto>.Success(categoryAsDto);

        }

        public async Task<ServiceResult<CreateCategoryResponse>> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var anyPost = await _categoryRepository.Where(x => x.Name == request.Name).AnyAsync();
            if (anyPost)
            {
                return ServiceResult<CreateCategoryResponse>.Failure("Post title already exist.", HttpStatusCode.BadRequest);
            }

            var result= _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(result);

            await _uniyOfWork.SaveChangesAsync();

            return ServiceResult<CreateCategoryResponse>.Success(new CreateCategoryResponse(result.Id));

        }

        public async Task<ServiceResult> UpdateCategoryAsync(int id,UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _categoryRepository.GetByIdAsync(id);
            if (result is null)
            {
                return ServiceResult.Failure("Category not found", HttpStatusCode.NotFound);
            }
            var anyPost = await _categoryRepository.Where(x => x.Name == updateCategoryRequest.Name && x.Id != result.Id).AnyAsync();

            if (anyPost)
            {
                return ServiceResult.Failure("Category name already exist.", HttpStatusCode.BadRequest);
            }

            result = _mapper.Map(updateCategoryRequest, result);
            _categoryRepository.Update(result);
            await _uniyOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteCategoryAsync(int id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);

            if (result is null)
            {
                return ServiceResult.Failure("Category not found", HttpStatusCode.NoContent);
            }

            _categoryRepository.Delete(result);

            await _uniyOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }
    }
}
