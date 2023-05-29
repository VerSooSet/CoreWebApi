using Api.Requests.Abstractions;
using AspNetCore.APIController.Abstractions;

namespace ApplicationLayer.Controllers
{
    public class AppApiControllerBase: ApiControllerBase
    {
        public AppApiControllerBase(
            IAsyncRequestBuilder asyncRequestBuilder
            ): base(asyncRequestBuilder)
        { 
        }
    }
}
