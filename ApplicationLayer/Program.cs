using Command.Abstractions;
using Database.N;
using Domain.Abstractions;
using Domain.Commands.Contexts;
using Domain.Services.Users;
using FizzWare.NBuilder;
using Persistence.Commands;
using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");*/


var testData = new ConcurrentDictionary<long, IEntity>();

//var options = builder.Services.AddOptions<MSSQLConnectionFactoryOptions>();

app.MapGet("/createuser", async (string name, string password, long cityId, CancellationToken cancellationToken) =>
{
    //new Options<MSSQLConnectionFactoryOptions>();
    var provider = new DbTransactionProvider(new MSSQLConnectionFactory(""));
    IAsyncCommand<ICommandContext> command = (IAsyncCommand<ICommandContext>)new CreateUserCommand(provider);
    var builder = new DefaultAsyncCommandBuilder(command);
    
    var dbService = new DBService(testData, 8);
    IUserService service = new UserService(builder, dbService);
    var user = service.CreateUserAsync(name,password,cityId,cancellationToken);
    Console.WriteLine(user);
}
);
/*
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
*/
app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}