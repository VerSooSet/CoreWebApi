using Api.Requests.Abstractions;
using AutoMapper;
using Domain.Services.Content;

namespace ApplicationLayer.Controllers.Content.Actions.Get
{
    public class ContentGetRequestHandler : IAsyncRequestHandler<ContentGetRequest, ContentGetResponse>
    {
        private readonly IContentService contentService;
        private readonly IMapper mapper;

        public ContentGetRequestHandler(IContentService contentService, IMapper mapper)
        {
            this.contentService = contentService;
            this.mapper = mapper;
        }

        public async Task<ContentGetResponse> ExecuteAsync(ContentGetRequest request)
        {
            Domain.Entitiyes.Content content = await contentService.GetContentAsync(
                Id: request.Id
            );
            return new ContentGetResponse(
                mapper.Map<ContentDto>(content));
        }
    }
}
