using Api.Requests.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ApiController.Abstractions
{
    public interface IHasDefaultSuccessActionResult
    {
        Func<IActionResult> Success { get; }
        Func<TResponse, IActionResult> ResponseSuccess<TResponse>()
            where TResponse : IResponse;
    }
}
