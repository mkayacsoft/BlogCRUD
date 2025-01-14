using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Services.Post;

public record PostDto(int Id, string Title, string Content, DateTime CreatedAt);
    

