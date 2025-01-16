using BlogCRUD.Services.Post.Create;
using BlogCRUD.Services.Post.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Services.Post
{
    public interface IPostService
    {
        Task<ServiceResult<List<PostDto>>> GetAllAsync();
        Task<ServiceResult<PostDto>> GetByIdAsync(int id);
        Task<ServiceResult<CreatePostResponse>> CreateAsync(CreatePostRequest createPostRequest);
        Task<ServiceResult> UpdateAsync(int id, UpdatePostRequest updatePostRequest);

        Task<ServiceResult> UpdateContentAsync(int id, UpdatePostContentRequest updatePostContentRequest);
        Task<ServiceResult> Delete(int id);


    }
}
