using AutoMapper;

namespace Shmelev_Backend_Task3
{
    public class ForumMapperProfile:Profile
    {
        public ForumMapperProfile()
        {
            CreateMap<Board,BoardCreateModel>().ReverseMap();
            CreateMap<Board,BoardEditModel>().ReverseMap();

            CreateMap<Thread, ThreadCreateModel>().ReverseMap();
            CreateMap<Thread, ThreadEditModel>().ReverseMap();

            CreateMap<Post, PostCreateModel>().ReverseMap();
            CreateMap<Post, PostEditModel>().ReverseMap();

        }
    }
}
