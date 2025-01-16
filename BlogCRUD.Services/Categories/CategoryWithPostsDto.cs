using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCRUD.Services.Post;

namespace BlogCRUD.Services.Categories;

public class CategoryWithPostsDto(int Id, int name, List<PostDto> Posts);

