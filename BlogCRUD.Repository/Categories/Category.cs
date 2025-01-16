using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Repository.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relation 
        //Bir Categorynin birden fazla postu olabilir.
        public List<Post.Post>? Posts { get; set; }
    }
}
