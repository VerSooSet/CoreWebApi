
using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.User.Actions.Add
{
    public record UserAddResponse(long Id) : IResponse;
}
