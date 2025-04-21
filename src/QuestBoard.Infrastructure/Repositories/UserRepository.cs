using System;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Database;

namespace QuestBoard.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public UserRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
}
