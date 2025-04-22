using Microsoft.AspNetCore.Mvc;
using QuestBoard.Application.Services;
using QuestBoard.Domain.DTO;
using QuestBoard.Infrastructure;
using QuestBoard.Infrastructure.Database;
using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddInfrastructureServices(builder.Configuration, appLogger);

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<QuestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user", async ([FromServices] UserService service, [FromQuery] string userId) =>
{
    return Results.Ok(await service.GetUserByIdAsync(userId));
})
.WithName("GetUser");

app.MapPost("/quest", async ([FromServices] QuestService service, [FromBody] QuestDTO data) =>
{
    await service.AddAync(data);
    return Results.Accepted();
})
.WithName("AddQuest");

app.MapGet("/quest", async ([FromServices] QuestService service, [FromQuery] string publisherId) =>
{
    return Results.Ok(await service.GetPublisherQuestsAsync(publisherId));
})
.WithName("GetPublisherQuests");

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

await app.RunAsync();
