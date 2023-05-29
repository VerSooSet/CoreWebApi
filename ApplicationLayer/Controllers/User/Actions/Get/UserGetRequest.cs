using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.User.Actions.Get
{
    public record UserGetRequest : IRequest<UserGetResponse>
    {
        public long Id { get; init; }
    }
}
