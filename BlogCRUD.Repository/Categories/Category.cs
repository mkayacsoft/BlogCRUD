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
