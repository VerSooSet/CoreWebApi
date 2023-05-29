using Api.Requests.Abstractions;
using AspNetCore.ApiController.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.APIController.Abstractions
{
    [ApiController]
    public class ApiControllerBase : 
        ControllerBase,
        IAsyncApiController,
        IHasDefaultSuccessActionResult,
        IHasDefaultFailActionResult
    {
        private readonly IAsyncRequestBuilder asyncRequestBuilder;

        public ApiControllerBase(IAsyncRequestBuilder asyncRequestBuilder)
        {
            this.asyncRequestBuilder = asyncRequestBuilder?? throw new ArgumentNullException(nameof(asyncRequestBuilder));
        }

        public IAsyncRequestBuilder AsyncRequestBuilder => asyncRequestBuilder;

        public virtual Func<IActionResult> Success
            => () => new OkResult();
        public virtual Func<Exception, IActionResult> Fail
           => (Exception exception) => new BadRequestObjectResult(exception.Message);

        public virtual Func<TResponse, IActionResult> ResponseSuccess<TResponse>()
            where TResponse : IResponse
            => (TResponse response) => new OkObjectResult(response);
    }
}