using ApplicationLayer.Controllers.User;
using AutoMapper;
using Domain.Entitiyes;

namespace ApplicationLayer.Profiles
{
    public class UserListItemProfile: Profile
    {
        public UserListItemProfile() 
        {
            CreateMap<User, UserListItemDto>();
        }
    }
}
