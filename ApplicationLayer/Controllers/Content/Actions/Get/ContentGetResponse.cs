using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.Content.Actions.Get
{
    public record ContentGetResponse(ContentDto content): IResponse;
    
}
