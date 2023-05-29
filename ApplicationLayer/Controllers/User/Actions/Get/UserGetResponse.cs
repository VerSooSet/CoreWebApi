using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.User.Actions.Get
{
    public record UserGetResponse(UserDto User) : IResponse;
}
