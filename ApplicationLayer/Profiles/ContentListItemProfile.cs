using ApplicationLayer.Controllers.Content;
using AutoMapper;
using Domain.Entitiyes;

namespace ApplicationLayer.Profiles
{
    public class ContentListItemProfile : Profile
    {
        public ContentListItemProfile()
        {
            CreateMap<Content, ContentListItemDto>();
        }
    }
}
