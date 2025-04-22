using System;
using Dapper;
using QuestBoard.Domain;
using QuestBoard.Domain.DTO;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Database;

namespace QuestBoard.Infrastructure.Repositories;

public class QuestRepository : IQuestRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public QuestRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task AddAsync(Quest quest)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"
                INSERT INTO Quests (id, title, description, status, difficulty, publisherid, createdat)
                VALUES (@Id, @Title, @Description, @Status, @Difficulty, @PublisherId, @CreatedAt)
            ", quest);
    }

    public async Task<IEnumerable<QuestDTO>> GetPublisherQuestsAsync(string publisherId)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<QuestDTO>(@"SELECT id, title, description, status, difficulty, publisherid, createdat FROM Quests WHERE publisherId = @PublisherId",
        new
        {
            PublisherId = publisherId
        });
    }

    public async Task<QuestDTO?> GetQuestByIdAsync(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<QuestDTO>(@"
            SELECT id, title, description, status, difficulty, publisherid, createdat FROM Quests WHERE Id = @Id LIMIT 1
        ", new { Id = id.ToString() });
    }
}
