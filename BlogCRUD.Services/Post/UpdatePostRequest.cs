using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Services.Post;

public record UpdatePostRequest(string Title, string Content);
    
