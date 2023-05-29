using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ApiController.Abstractions
{
    public interface IHasDefaultFailActionResult
    {
        Func<Exception, IActionResult> Fail { get; }
    }
}
