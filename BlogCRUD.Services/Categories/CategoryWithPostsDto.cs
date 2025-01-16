using BlogCRUD.Services.Post;

namespace BlogCRUD.Services.Categories;

public class CategoryWithPostsDto(int Id, int name, List<PostDto> Posts);

