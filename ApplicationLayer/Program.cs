using ApplicationLayer;
using ApplicationLayer.DI;
using ApplicationLayer.Swagger;
using Database.N;
using Domain.DI;
using Domain.Entitiyes;
using Domain.Filters;
using Domain.Initializers;
using Domain.Services;
using Domain.Services.Users;
using Persistence.Commands;
using Persistence.Queries;


var builder = WebApplication.CreateBuilder(args);
void ConfigureServices(WebApplicationBuilder builder)
{
    string connectionString = builder.Configuration.GetConnectionString("SQLConnectionString");
    DatabaseInitializer.Init(connectionString);

    builder.Services.AddScoped<TransactionFilter>();
    builder.Services.AddSingleton<IDBService, DBService>();

    builder.Services.AddDatabase<MSSQLConnectionFactory, DbTransactionProvider>();
    builder.Services.AddCommandsFromAssembly<CreateUserCommand>();

    builder.Services.AddQueriesFromAssembly<FindUsersQuery>();
    builder.Services.AddQueriesFromAssembly<FindUserCountByLoginQuery>();
    builder.Services.AddQueriesFromAssembly<FindUserByIdQuery>();
    builder.Services.AddQueriesFromAssembly<FindUserByLoginQuery>();

    builder.Services.AddDomainServicesFromAssembly<UserServiceBase>();

    builder.Services.Configure<MSSQLConnectionFactoryOptions>(options =>
    {
        options.ConnectionString = connectionString;
    });
}
ConfigureServices(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

//!REF
builder.Services.AddControllersWithViews(mvcOptions =>
{
    mvcOptions.Filters.AddService<TransactionFilter>();
});

var app = builder.Build();
// must be the first middleware, to ensure exceptions at all levels are handled
app.UseMiddleware<ExceptionHandlingMiddleware>();

app = SwaggerExtensions.UseSwagger(app);

app.UseHttpsRedirection();

app.MapGet("/createuser", async (IUserService service, string name, string password, long cityId, CancellationToken cancellationToken) =>
{
    await service.CreateUserAsync(name, password, cityId, cancellationToken);
    Console.WriteLine(String.Format("{0}, try to creating User with {1}, {2}, {3}",DateTime.Now.ToShortTimeString(),name,password,cityId));
});

app.MapGet("/deluser", async (IUserService service, string name, long id, CancellationToken cancellationToken) =>
{
    await service.DeleteUserAsync(name,id, cancellationToken);
    Console.WriteLine(String.Format("{0}, try to deleting User with {1}, {2}", DateTime.Now.ToShortTimeString(), id, name));
});

app.MapGet("/getuser", async (IUserService service, string name, long id, CancellationToken cancellationToken) =>
{
    await service.GetUserAsync(id, cancellationToken);
    Console.WriteLine(String.Format("{0}, answer for requesting User by {1}, {2}", DateTime.Now.ToShortTimeString(), id, name));
});

app.Map("/getuser", async (IUserService service, string name, long id, CancellationToken cancellationToken) =>
{
    await service.GetUserAsync(id, cancellationToken);
    Console.WriteLine(String.Format("{0}, answer for requesting User by {1}, {2}", DateTime.Now.ToShortTimeString(), id, name));
});

app.MapGet("/getusers", async (IUserService service, CancellationToken cancellationToken) =>
{
    var elements = await service.GetUserCollectionAsync(cancellationToken) ?? new List<User>();
    
    Console.WriteLine(
        String.Format("receiving collection an {0} of {1} elements", DateTime.Now.ToShortTimeString(), elements.Count)
    );
    foreach (var each in elements)
        Console.WriteLine(String.Format("Founded a User with {1}, {2}", each.Id, each.Name));
});

app.Run();