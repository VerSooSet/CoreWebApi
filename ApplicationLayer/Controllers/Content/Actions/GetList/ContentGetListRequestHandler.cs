using Api.Requests.Abstractions;
using AutoMapper;
using Domain.Abstractions;
using Domain.Criteria;
using Queries.Abstractions;

namespace ApplicationLayer.Controllers.Content.Actions.GetList
{
    public class ContentGetListRequestHandler : IAsyncRequestHandler<ContentGetListRequest, ContentGetListResponse>
    {
        private readonly IAsyncQueryBuilder asyncQueryBuilder;
        private readonly IDBServiceWithSearch dbService;
        private readonly IMapper mapper;

        public ContentGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IDBServiceWithSearch dbService, IMapper mapper)
        {
            this.asyncQueryBuilder = asyncQueryBuilder;
            this.dbService = dbService;
            this.mapper = mapper;
        }
        public async Task<ContentGetListResponse> ExecuteAsync(ContentGetListRequest request)
        {
            List<Domain.Entitiyes.Content> content = await asyncQueryBuilder
                .For<List<Domain.Entitiyes.Content>>()
                .WithAsync(new FindContentItems(request.Search));
            if (content.Count==0)
            {
                var temp = await dbService.GetCollectionAsync<Domain.Entitiyes.Content>(request.Search);
                content = temp.ToList();
            }

            return new ContentGetListResponse(
                ContentItems: mapper.Map<IEnumerable<ContentListItemDto>>(content));
        }
    }
}
