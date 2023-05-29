using Api.Requests.Abstractions;
using AutoMapper;
using Domain.Services.Users;

namespace ApplicationLayer.Controllers.User.Actions.Add
{
    public class UserAddRequestHandler : IAsyncRequestHandler<UserAddRequest, UserAddResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserAddRequestHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.mapper = mapper;
        }

        public async Task<UserAddResponse> ExecuteAsync(UserAddRequest request)
        {
            Domain.Entitiyes.User user = await userService.CreateUserAsync(
                Name: request.Login.Trim(),
                Password: request.Password,
                CityId: request.CityId
            );
            return new UserAddResponse(
                Id: user.Id);
        }
    }
}
