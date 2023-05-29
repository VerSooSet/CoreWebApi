using Api.Requests.Abstractions;
using AspNetCore.ApiController.Abstractions;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.APIController.Abstractions;

namespace AspNetCore.ApiController.Extensions
{
    public static class AsyncApiControllerExtensions
    {
        public static Task<IActionResult> RequestAsync<TApiController, TRequest>(
            this TApiController apiController,
            TRequest request
            ) where TApiController :
                ControllerBase, 
                IAsyncApiController,
                IHasDefaultSuccessActionResult,
                IHasDefaultFailActionResult
            where TRequest : IRequest
        {
            return RequestAsync<TApiController, TRequest>(
                apiController,
                request,
                apiController.Success,
                apiController.Fail);
        }

        public static Task<IActionResult> RequestAsync<TApiController, TRequest, TResponse>(
            this TApiController apiController,
            TRequest request)
            where TApiController :
                ControllerBase,
                IAsyncApiController,
                IHasDefaultSuccessActionResult,
                IHasDefaultFailActionResult
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
            => RequestAsync(
                apiController,
                request,
                apiController.ResponseSuccess<TResponse>(),
                apiController.Fail);

        public static async Task<IActionResult> RequestAsync<TApiController, TRequest>(
            this TApiController apiController,
            TRequest request,
            Func<IActionResult> success,
            Func<Exception, IActionResult> fail)
            where TApiController :
                ControllerBase,
                IAsyncApiController,
                IHasDefaultSuccessActionResult,
                IHasDefaultFailActionResult
            where TRequest : IRequest
        {
            if (apiController == null)
                throw new ArgumentNullException(nameof(apiController));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                await apiController.AsyncRequestBuilder.ExecuteAsync(request);

                return success();
            }
            catch (Exception exception)
            {
                return fail(exception);
            }
        }

        public static async Task<IActionResult> RequestAsync<TApiController, TRequest, TResponse>(
            this TApiController apiController,
            TRequest request,
            Func<TResponse, IActionResult> success,
            Func<Exception, IActionResult> fail)
            where TApiController :
                ControllerBase,
                IAsyncApiController
                                
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            if (apiController == null)
                throw new ArgumentNullException(nameof(apiController));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                TResponse response = await apiController.AsyncRequestBuilder.ExecuteAsync<TRequest, TResponse>(request);
                                
                return success(response);
            }
            catch (Exception exception)
            {
                return fail(exception);
            }
        }
    }
}
