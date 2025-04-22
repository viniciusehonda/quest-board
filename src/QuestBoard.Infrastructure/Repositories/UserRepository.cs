using System;
using Dapper;
using QuestBoard.Domain;
using QuestBoard.Domain.DTO;
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

    public async Task AddAsync(User user)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"
            INSERT INTO Users (id, name, email, createdat)
            VALUES (@Id, @Name, @Email, @CreatedAt)
        ", user);
    }

    public async Task<UserDTO?> GetUserByIdAsync(string id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<UserDTO>(@"
        SELECT id, name, email
        FROM Users
        WHERE Id = @Id
        LIMIT 1", new
        {
            Id = id
        });
    }
}
