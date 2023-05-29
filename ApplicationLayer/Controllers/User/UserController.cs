using Api.Requests.Abstractions;
using ApplicationLayer.Controllers.User.Actions.Add;
using ApplicationLayer.Controllers.User.Actions.Get;
using ApplicationLayer.Controllers.User.Actions.GetList;
using AspNetCore.ApiController.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppApiControllerBase
    {
        public UserController(IAsyncRequestBuilder asyncRequestBuilder)
            : base(asyncRequestBuilder)
        { }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(UserAddResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> CreateUser(UserAddRequest request)
            => this.RequestAsync()
                .For<UserAddResponse>()
                .With(request);

        [HttpGet]
        ///<param name="request" example="1"></param>
        [Route("get")]
        [ProducesResponseType(typeof(UserGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetUser([FromQuery]UserGetRequest request)
            => this.RequestAsync()
                .For<UserGetResponse>()
                .With(request);

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(UserGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetListUser([FromQuery] UserGetListRequest request)
            => this.RequestAsync()
                .For<UserGetListResponse>()
                .With(request);

    }

}
