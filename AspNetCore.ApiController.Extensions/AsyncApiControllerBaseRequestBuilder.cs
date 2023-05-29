
using Api.Requests.Abstractions;
using AspNetCore.APIController.Abstractions;

namespace AspNetCore.ApiController.Extensions
{
    public class AsyncApiControllerBaseRequestBuilder
    {
        private readonly ApiControllerBase apiControllerBase;

        public AsyncApiControllerBaseRequestBuilder(ApiControllerBase apiControllerBase)
        {
            this.apiControllerBase = apiControllerBase;
        }
        public AsyncApiControllerBaseRequestFor<TResponse> For<TResponse>()
            where TResponse : IResponse
        => new(apiControllerBase);
    }
}
