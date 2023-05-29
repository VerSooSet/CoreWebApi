using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.User.Actions.GetList
{
    public record UserGetListRequest : IRequest<UserGetListResponse>
    {
        public string? Search { get; init; }
    }
}
