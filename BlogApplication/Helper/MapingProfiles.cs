using AutoMapper;
using Domain;
using ServiceLayer.DTO;

namespace BlogApplication.Helper
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();

            CreateMap<Blog, BlogDTO>();
            CreateMap<BlogDTO, Blog>();

            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();

            CreateMap<Tag, TagDTO>();
            CreateMap<TagDTO, TagDTO>();
        }
    }
}
