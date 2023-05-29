using Api.Requests.Abstractions;
using AspNetCore.APIController.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ApiController.Extensions
{
    public class AsyncApiControllerBaseRequestFor<TResponse>
            where TResponse : IResponse
    {
        private readonly ApiControllerBase apiController;

        public AsyncApiControllerBaseRequestFor(ApiControllerBase apiController)
        {
            this.apiController = apiController;
        }

        public Task<IActionResult> With<TRequest>(TRequest request)
            where TRequest : IRequest<TResponse>
        => apiController.RequestAsync<ApiControllerBase, TRequest,TResponse>(request);
    }
}
