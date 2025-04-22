using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Database;
using QuestBoard.Infrastructure.Providers;
using QuestBoard.Infrastructure.Repositories;
using QuestBoard.Infrastructure.TypeHandlers;

namespace QuestBoard.Infrastructure;

public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("PostgresqlConnectionString");

    if (string.IsNullOrEmpty(connectionString))
    {
      throw new Exception("Invalid PostgreSQL connectionString");
    }

    services.AddSingleton<IDbConnectionFactory>(provider => new NpgsqlConnectionFactory(connectionString));
    services.AddSingleton<DatabaseInitializer>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

    services.AddDapperTypeHandlers();
    services.RegisterRepositories();

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }

  private static void RegisterRepositories(this IServiceCollection services)
  {
    services.AddScoped<IQuestRepository, QuestRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
  }
}
