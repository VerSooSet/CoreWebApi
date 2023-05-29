using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.Content.Actions.Get
{
    public class ContentGetRequest: IRequest<ContentGetResponse>
    {
        public long Id { get; init; }
        
    }
}
