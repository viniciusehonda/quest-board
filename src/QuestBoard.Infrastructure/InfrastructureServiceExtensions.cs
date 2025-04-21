// using Ardalis.GuardClauses;
// using Ardalis.SharedKernel;
// using QuestBoard.Core.Interfaces;
// using QuestBoard.Core.Services;
// using QuestBoard.Infrastructure.Data;
// using QuestBoard.Infrastructure.Data.Queries;
// using QuestBoard.Infrastructure.Email;
// using QuestBoard.UseCases.Contributors.List;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Database;
using QuestBoard.Infrastructure.Repositories;

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
