using Api.Requests.Abstractions;
using ApplicationLayer.Controllers.Content.Actions.Add;
using ApplicationLayer.Controllers.Content.Actions.Get;
using ApplicationLayer.Controllers.Content.Actions.GetList;
using ApplicationLayer.Controllers.User.Actions.Add;
using ApplicationLayer.Controllers.User.Actions.Get;
using ApplicationLayer.Controllers.User.Actions.GetList;
using Database.Fake;
using Database.N;
using Domain.Abstractions;
using Domain.DI;
using Domain.Filters;
using Domain.Initializers;
using Domain.Services;
using Persistence.Commands;
using Persistence.Queries;

namespace ApplicationLayer.DI
{
    public static class EndpointDefinitionExtensions
    {
        public static void AddRegisterDependencies(this IServiceCollection services, string connectionString)
        {
            DatabaseInitializer.Init(connectionString);

            services.Configure<MSSQLConnectionFactoryOptions>(options =>
            {
                options.ConnectionString = connectionString;
            });
            services.AddScoped<TransactionFilter>();
            services.AddSingleton<IDBServiceWithSearch, DBService>();
            services.AddScoped<IAsyncRequestBuilder, DefaultAsyncRequestBuilder>();
            services.AddScoped(typeof(IAsyncRequestHandlerFactory), typeof(Factories.AsyncRequestHandlerFactory));

            //!REF to another IoC container.
            //Coz that is just a fix for a while. Microsoft Dependency Injection container hasn't register generic-types dependencies with associated types of my Api.Requests.
            //So, i would register generics one-by-one at this time.
            #region Here. Needs to fix it  !
            services.AddScoped(typeof(IAsyncRequestHandler<UserAddRequest, UserAddResponse>), typeof(UserAddRequestHandler));
            services.AddScoped(typeof(IAsyncRequestHandler<UserGetRequest, UserGetResponse>), typeof(UserGetRequestHandler));
            services.AddScoped(typeof(IAsyncRequestHandler<UserGetListRequest, UserGetListResponse>), typeof(UserGetListRequestHandler));

            services.AddScoped(typeof(IAsyncRequestHandler<ContentAddRequest, ContentAddResponse>), typeof(ContentAddRequestHandler));
            services.AddScoped(typeof(IAsyncRequestHandler<ContentGetRequest, ContentGetResponse>), typeof(ContentGetRequestHandler));
            services.AddScoped(typeof(IAsyncRequestHandler<ContentGetListRequest, ContentGetListResponse>), typeof(ContentGetListRequestHandler));
            #endregion

            services.AddDatabase<MSSQLConnectionFactory, DbTransactionProvider>();

            services.AddCommandsFromAssembly<CreateUserCommand>();
            services.AddCommandsFromAssembly<CreateContentCommand>();

            services.AddQueriesFromAssembly<FindUsersQuery>();
            services.AddQueriesFromAssembly<FindUserCountByLoginQuery>();
            services.AddQueriesFromAssembly<FindUserByIdQuery>();
            services.AddQueriesFromAssembly<FindUserByLoginQuery>();

            services.AddQueriesFromAssembly<FindContentsQuery>();
            services.AddQueriesFromAssembly<FindContentByIdQuery>();

            services.AddDomainServicesFromAssembly<UserServiceBase>();
            services.AddDomainServicesFromAssembly<ContentServiceBase>();
        }
    }
}
