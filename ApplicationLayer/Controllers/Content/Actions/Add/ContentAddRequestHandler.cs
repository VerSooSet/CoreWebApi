using Api.Requests.Abstractions;
using AutoMapper;
using Domain.Services.Content;
using Domain.Services.Users;

namespace ApplicationLayer.Controllers.Content.Actions.Add
{
    public class ContentAddRequestHandler: IAsyncRequestHandler<ContentAddRequest,ContentAddResponse>
    {
        private readonly IContentService service;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ContentAddRequestHandler(IContentService service, IUserService userService, IMapper mapper)
        {
            this.service = service;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<ContentAddResponse> ExecuteAsync(ContentAddRequest request)
        {
            var owner = await userService.GetUserAsync(
                Id: request.OwnerId);
            
            var content = await service.CreateContentAsync(
                Name: request.Name,
                Owner: owner,
                TypeId: request.TypeId
                );
            return new ContentAddResponse(
                Id: content.Id);
        }
    }
}
