using Api.Requests.Abstractions;

namespace AspNetCore.APIController.Abstractions
{
    public interface IAsyncApiController
    {
        IAsyncRequestBuilder AsyncRequestBuilder { get;}
    }
}
