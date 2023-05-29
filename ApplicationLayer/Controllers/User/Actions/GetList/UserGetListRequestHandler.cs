using Api.Requests.Abstractions;
using AutoMapper;
using Database.N;
using Domain.Abstractions;
using Domain.Criteria;
using Domain.Entitiyes;
using Queries.Abstractions;

namespace ApplicationLayer.Controllers.User.Actions.GetList
{
    public class UserGetListRequestHandler : IAsyncRequestHandler<UserGetListRequest, UserGetListResponse>
    {
        private readonly IAsyncQueryBuilder asyncQueryBuilder;
        private readonly IDBServiceWithSearch dbService;
        private readonly IMapper mapper;

        public UserGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IDBServiceWithSearch dbService, IMapper mapper)
        {
            this.asyncQueryBuilder = asyncQueryBuilder;
            this.dbService = dbService;
            this.mapper = mapper;
        }

        public async Task<UserGetListResponse> ExecuteAsync(UserGetListRequest request)
        {
            List<Domain.Entitiyes.User> users = await asyncQueryBuilder
                .For<List<Domain.Entitiyes.User>>()
                .WithAsync(new FindUsers(request.Search));
            if (users.Count == 0)
            {
                var temp = await dbService.GetCollectionAsync<Domain.Entitiyes.User>(request.Search);
                users = temp.ToList();
            }
            return new UserGetListResponse(
                Users: mapper.Map<IEnumerable<UserListItemDto>>(users));
        }
    }
}
