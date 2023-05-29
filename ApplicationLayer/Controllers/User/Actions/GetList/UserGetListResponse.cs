using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.User.Actions.GetList
{
    
    public record UserGetListResponse(IEnumerable<UserListItemDto> Users) : IResponse;
    
}
