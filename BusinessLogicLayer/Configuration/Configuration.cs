using AutoMapper;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;
using DomainLayer.NewFolder;

namespace BusinessLogicLayer.Configuration
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<Like, LikeDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
        }
    }
}
