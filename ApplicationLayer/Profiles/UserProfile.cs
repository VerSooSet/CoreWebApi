using ApplicationLayer.Controllers.User;
using AutoMapper;
using Domain.Entitiyes;

namespace ApplicationLayer.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<User,UserDto>();
        }
    }
}
