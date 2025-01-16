using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogCRUD.Repository;
using BlogCRUD.Repository.Post;
using BlogCRUD.Services.Post.Create;
using BlogCRUD.Services.Post.Update;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUD.Services.Post
{
    public class PostService(IPostRepository postRepository, IUnitOfWork unitOfWork,IMapper mapper) : IPostService
    {
        public async Task<ServiceResult<List<PostDto>>> GetAllAsync()
        {
            var result = await postRepository.GetAll().ToListAsync();

            #region Manuel mapping

            //var postAsDto = result.Select(p => new PostDto(p.Id, p.Title, p.Content, p.CreatedAt)).ToList();

            #endregion
             
            var postAsDto = mapper.Map<List<PostDto>>(result);

            return ServiceResult<List<PostDto>>.Success(postAsDto);
        }

        public async Task<ServiceResult<PostDto>> GetByIdAsync(int id)
        {
            var result = await postRepository.GetByIdAsync(id);
            if (result is null)
            {
                return ServiceResult<PostDto>.Failure("Post not found.", HttpStatusCode.NotFound)!;
            }

            #region Manuel Mapping

            //var postAsDto = new PostDto(result.Id, result.Title, result.Content, result.CreatedAt);

            #endregion

            var postAsDto = mapper.Map<PostDto>(result);

            return ServiceResult<PostDto>.Success(postAsDto);
        }

        public async Task<ServiceResult<CreatePostResponse>> CreateAsync(CreatePostRequest createPostRequest)
        {
            //Database Validation

            var anyPost = await postRepository.Where(x => x.Title == createPostRequest.Title).AnyAsync();
            if (anyPost)
            {
                return ServiceResult<CreatePostResponse>.Failure("Post title already exist.",HttpStatusCode.BadRequest);
            }

            //Service

            #region Manuel 

            //var result = new Repository.Post.Post
            //{
            //    Title = createPostRequest.Title, 
            //    Content = createPostRequest.Content
            //};

                #endregion

            var result = mapper.Map<Repository.Post.Post>(createPostRequest);

            await postRepository.AddAsync(result);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult<CreatePostResponse>.Success(new CreatePostResponse(result.Id));

        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdatePostRequest updatePostRequest)
        {
            var result = await postRepository.GetByIdAsync(id); // entity
            if (result is null)
            {
                return ServiceResult.Failure("Post not found.", HttpStatusCode.NotFound)!;
            }

            var anyPost = await postRepository.Where(x => x.Title == updatePostRequest.Title && x.Id != result.Id).AnyAsync();

            if (anyPost)
            {
                return ServiceResult.Failure("Post title already exist.", HttpStatusCode.BadRequest);
            }

            #region Manuel

            //result.Title = updatePostRequest.Title;
            //result.Content = updatePostRequest.Content;

            #endregion

            result = mapper.Map(updatePostRequest, result); // elinde nesne varsa böyle mapleyebilirsin

            postRepository.Update(result);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        } 
        public async Task<ServiceResult> UpdateContentAsync(int id, UpdatePostContentRequest updatePostContentRequest)
        {
            var result = await postRepository.GetByIdAsync(id); // entity
            if (result is null)
            {
                return ServiceResult.Failure("Post not found.", HttpStatusCode.NotFound)!;
            }

            var anyPost = await postRepository.Where(x => x.Content == updatePostContentRequest.Content && x.Id != result.Id).AnyAsync();

            if (anyPost)
            {
                return ServiceResult.Failure("Same post content already exist.", HttpStatusCode.BadRequest);
            }

            #region Manuel

            //result.Title = updatePostRequest.Title;
            //result.Content = updatePostRequest.Content;

            #endregion

            result = mapper.Map(updatePostContentRequest, result); // elinde nesne varsa böyle mapleyebilirsin

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
