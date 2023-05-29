using Api.Requests.Abstractions;
using ApplicationLayer.Controllers.Content.Actions.Add;
using ApplicationLayer.Controllers.Content.Actions.Get;
using ApplicationLayer.Controllers.Content.Actions.GetList;
using AspNetCore.ApiController.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : AppApiControllerBase
    {
        public ContentController(IAsyncRequestBuilder asyncRequestBuilder) : base(asyncRequestBuilder)
        {
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ContentAddResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> CreateContent(ContentAddRequest request)
           => this.RequestAsync()
               .For<ContentAddResponse>()
               .With(request);

        [HttpGet]
        ///<param name="request" example="1"></param>
        [Route("get")]
        [ProducesResponseType(typeof(ContentGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetContent([FromQuery]ContentGetRequest request)
            => this.RequestAsync()
                .For<ContentGetResponse>()
                .With(request);

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(ContentGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetListContents([FromQuery] ContentGetListRequest request)
            => this.RequestAsync()
                .For<ContentGetListResponse>()
                .With(request);

    }
}
