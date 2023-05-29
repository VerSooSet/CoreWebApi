using ApplicationLayer.Controllers.Content;
using AutoMapper;
using Domain.Entitiyes;

namespace ApplicationLayer.Profiles
{
    public class ContentProfile: Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentDto>();
        }
    }
}
