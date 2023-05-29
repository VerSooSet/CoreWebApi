using Api.Requests.Abstractions;
using AutoMapper;
using Domain.Entitiyes;
using Domain.Services.Users;

namespace ApplicationLayer.Controllers.User.Actions.Get
{
    public class UserGetRequestHandler : IAsyncRequestHandler<UserGetRequest, UserGetResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserGetRequestHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        public async Task<UserGetResponse> ExecuteAsync(UserGetRequest request)
        {
            Domain.Entitiyes.User user = await userService.GetUserAsync(
                Id: request.Id
            );
            return new UserGetResponse(
                mapper.Map<UserDto>(user));
        }
    }
}
