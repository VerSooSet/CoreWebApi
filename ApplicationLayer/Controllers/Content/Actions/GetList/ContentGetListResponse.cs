
using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.Content.Actions.GetList
{
    public record ContentGetListResponse(IEnumerable<ContentListItemDto> ContentItems) : IResponse;
}
