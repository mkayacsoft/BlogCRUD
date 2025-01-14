using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlogCRUD.Repository;
using BlogCRUD.Repository.Post;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUD.Services.Post
{
    public class PostService(IPostRepository postRepository, IUnitOfWork unitOfWork) : IPostService
    {
        public async Task<ServiceResult<List<PostDto>>> GetAllAsync()
        {
            var result = await postRepository.GetAll().ToListAsync();
            var postAsDto = result.Select(p => new PostDto(p.Id, p.Title, p.Content, p.CreatedAt)).ToList();


            return ServiceResult<List<PostDto>>.Success(postAsDto);
        }

        public async Task<ServiceResult<PostDto>> GetByIdAsync(int id)
        {
            var result = await postRepository.GetByIdAsync(id);
            if (result is null)
            {
                return ServiceResult<PostDto>.Failure("Post not found.", HttpStatusCode.NotFound)!;
            }

            var postAsDto = new PostDto(result.Id, result.Title, result.Content, result.CreatedAt);

            return ServiceResult<PostDto>.Success(postAsDto);
        }

        public async Task<ServiceResult<CreatePostResponse>> CreateAsync(CreatePostRequest createPostRequest)
        {
            var result = new Repository.Post.Post
            {
               Title = createPostRequest.Title, 
                Content = createPostRequest.Content
            };

            await postRepository.AddAsync(result);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult<CreatePostResponse>.Success(new CreatePostResponse(result.Id));

        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdatePostRequest updatePostRequest)
        {
            var result = await postRepository.GetByIdAsync(id);
            if (result is null)
            {
                return ServiceResult.Failure("Post not found.", HttpStatusCode.NotFound)!;
            }

            result.Title = updatePostRequest.Title;
            result.Content = updatePostRequest.Content;

            postRepository.Update(result);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> Delete(int id)
        {
            var result = await postRepository.GetByIdAsync(id);
            if (result is null)
            {
                return ServiceResult.Failure("Post not found.",HttpStatusCode.NoContent);
            }

            postRepository.Delete(result);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }
    }
}
