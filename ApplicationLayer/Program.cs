using ApplicationLayer;
using ApplicationLayer.DI;
using ApplicationLayer.Swagger;
using Domain.Filters;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("SQLConnectionString");
builder.Services.AddRegisterDependencies(connectionString);

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