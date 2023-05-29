using Api.Requests.Abstractions;
using ApplicationLayer.Controllers.User.Actions.GetList;

namespace ApplicationLayer.Controllers.Content.Actions.GetList
{
    public class ContentGetListRequest: IRequest<ContentGetListResponse>
    {
        public string? Search { get; init; }
    }
}
