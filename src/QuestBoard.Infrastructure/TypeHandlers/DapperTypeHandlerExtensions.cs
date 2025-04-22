using System;
using Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace QuestBoard.Infrastructure.TypeHandlers;

public static class DapperTypeHandlerExtensions
{
    public static IServiceCollection AddDapperTypeHandlers(this IServiceCollection services)
    {
        SqlMapper.AddTypeHandler(new GuidTypeHandler());
        return services;
    }
}
