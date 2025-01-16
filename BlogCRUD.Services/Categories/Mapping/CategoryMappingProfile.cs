using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogCRUD.Repository.Categories;
using BlogCRUD.Services.Categories.Create;
using BlogCRUD.Services.Categories.Update;

namespace BlogCRUD.Services.Categories.Mapping
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithPostsDto>().ReverseMap();
            CreateMap<CreateCategoryRequest, CategoryDto>();
            CreateMap<UpdateCategoryRequest, CategoryDto>();
        }
    }
}
