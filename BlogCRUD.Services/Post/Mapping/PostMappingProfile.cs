using AutoMapper;
using BlogCRUD.Services.Post;
using BlogCRUD.Services.Post.Create;
using BlogCRUD.Services.Post.Update;


namespace BlogCRUD.Services.Post.Mapping
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Repository.Post.Post, PostDto>().ReverseMap();
            CreateMap<CreatePostRequest, Repository.Post.Post>().ForMember(dest => dest.Title, opt => opt.MapFrom(src =>
                src.Title.ToLowerInvariant()));
            CreateMap<UpdatePostRequest, Repository.Post.Post>().ForMember(dest => dest.Title, opt => opt.MapFrom(src =>
                src.Title.ToLowerInvariant()));
            CreateMap<UpdatePostContentRequest, Repository.Post.Post>();

        }
    }
}
