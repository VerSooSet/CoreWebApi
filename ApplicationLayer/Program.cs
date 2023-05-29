using Api.Requests.Abstractions;
using ApplicationLayer;
using ApplicationLayer.Controllers.Content.Actions.Add;
using ApplicationLayer.Controllers.Content.Actions.Get;
using ApplicationLayer.Controllers.Content.Actions.GetList;
using ApplicationLayer.Controllers.User.Actions.Add;
using ApplicationLayer.Controllers.User.Actions.Get;
using ApplicationLayer.Controllers.User.Actions.GetList;
using ApplicationLayer.DI;
using ApplicationLayer.Swagger;
using Database.N;
using Domain.Abstractions;
using Domain.DI;
using Domain.Filters;
using Domain.Initializers;
using Domain.Services;
using Persistence.Commands;
using Persistence.Queries;


var builder = WebApplication.CreateBuilder(args);
void ConfigureServices(WebApplicationBuilder builder)
{
    string connectionString = builder.Configuration.GetConnectionString("SQLConnectionString");
    DatabaseInitializer.Init(connectionString);

    builder.Services.AddScoped<TransactionFilter>();
    builder.Services.AddSingleton<IDBServiceWithSearch, DBService>();
    
    builder.Services.AddScoped<IAsyncRequestBuilder,DefaultAsyncRequestBuilder>();

    builder.Services.AddScoped(typeof(IAsyncRequestHandlerFactory),typeof(ApplicationLayer.DI.Factories.AsyncRequestHandlerFactory));
    
    //!REF to another IoC container
    builder.Services.AddScoped(typeof(IAsyncRequestHandler<UserAddRequest, UserAddResponse>), typeof(UserAddRequestHandler));
    builder.Services.AddScoped(typeof(IAsyncRequestHandler<UserGetRequest,UserGetResponse>), typeof(UserGetRequestHandler));
    builder.Services.AddScoped(typeof(IAsyncRequestHandler<UserGetListRequest, UserGetListResponse>), typeof(UserGetListRequestHandler));
    
    builder.Services.AddScoped(typeof(IAsyncRequestHandler<ContentAddRequest, ContentAddResponse>), typeof(ContentAddRequestHandler));
    builder.Services.AddScoped(typeof(IAsyncRequestHandler<ContentGetRequest,ContentGetResponse>), typeof(ContentGetRequestHandler));
    builder.Services.AddScoped(typeof(IAsyncRequestHandler<ContentGetListRequest, ContentGetListResponse>), typeof(ContentGetListRequestHandler));

    builder.Services.AddDatabase<MSSQLConnectionFactory, DbTransactionProvider>();
    
    builder.Services.AddCommandsFromAssembly<CreateUserCommand>();
    builder.Services.AddCommandsFromAssembly<CreateContentCommand>();
    
    builder.Services.AddQueriesFromAssembly<FindUsersQuery>();
    builder.Services.AddQueriesFromAssembly<FindUserCountByLoginQuery>();
    builder.Services.AddQueriesFromAssembly<FindUserByIdQuery>();
    builder.Services.AddQueriesFromAssembly<FindUserByLoginQuery>();

    builder.Services.AddQueriesFromAssembly<FindContentsQuery>();
    builder.Services.AddQueriesFromAssembly<FindContentByIdQuery>();

    builder.Services.AddDomainServicesFromAssembly<UserServiceBase>();
    builder.Services.AddDomainServicesFromAssembly<ContentServiceBase>();

    builder.Services.Configure<MSSQLConnectionFactoryOptions>(options =>
    {
        options.ConnectionString = connectionString;
    });
}
ConfigureServices(builder);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAutoMapper(typeof(MarkerAppAssembly));


builder.Services.AddControllersWithViews(mvcOptions =>
{
    mvcOptions.Filters.AddService<TransactionFilter>();
});

var app = builder.Build();

app.MapControllers();
// must be the first middleware, to ensure exceptions at all levels are handled
app.UseMiddleware<ExceptionHandlingMiddleware>();

app = SwaggerExtensions.UseSwagger(app);

app.UseHttpsRedirection();

app.Run();