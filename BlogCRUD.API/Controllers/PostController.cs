using BlogCRUD.Services.Post;
using BlogCRUD.Services.Post.Create;
using BlogCRUD.Services.Post.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCRUD.API.Controllers
{

    public class PostController(IPostService postService) : CustomControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var serviceResult = await postService.GetAllAsync();
            return CreateActionResult(serviceResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var serviceResult = await postService.GetByIdAsync(id);
            return CreateActionResult(serviceResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostRequest createPostRequest)
        {
            var serviceResult = await postService.CreateAsync(createPostRequest);
            return CreateActionResult(serviceResult);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id,[FromBody] UpdatePostContentRequest updatePostContentRequest)
        {
            var serviceResult = await postService.UpdateContentAsync(id,updatePostContentRequest);
            return CreateActionResult(serviceResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePostRequest updatePostRequest)
        {
            var serviceResult = await postService.UpdateAsync(id,updatePostRequest);
            return CreateActionResult(serviceResult);
        }

        [HttpDelete("{id}")]
        public async Task< IActionResult> Delete(int id)
        {
            var serviceResult = await postService.Delete(id);
            return CreateActionResult(serviceResult);
        }
    
        

    }
}
