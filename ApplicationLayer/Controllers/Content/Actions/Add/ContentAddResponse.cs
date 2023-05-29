using Api.Requests.Abstractions;

namespace ApplicationLayer.Controllers.Content.Actions.Add
{
    public record ContentAddResponse(long Id): IResponse;
}
