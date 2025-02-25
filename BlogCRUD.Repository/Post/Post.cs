﻿using BlogCRUD.Repository.Categories;

namespace BlogCRUD.Repository.Post
{
    public class Post // <--- Add this class 2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        //Relation

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
