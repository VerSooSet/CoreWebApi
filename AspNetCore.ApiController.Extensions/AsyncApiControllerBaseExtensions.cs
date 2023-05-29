using Api.Requests.Abstractions;
using AspNetCore.APIController.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ApiController.Extensions
{
    public static class AsyncApiControllerBaseExtensions
    {
        public static Task<IActionResult> RequestAsync<TRequest, TResponse>(
            this ApiControllerBase apiController,
            TRequest request
            )
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            return apiController.RequestAsync<ApiControllerBase, TRequest, TResponse>(request);
        }

        public static AsyncApiControllerBaseRequestBuilder RequestAsync(
            this ApiControllerBase apiController)
            => new(apiController);
    }
}
