using System;
using Dapper;

namespace QuestBoard.Infrastructure.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Quests (
            Id CHAR(36) PRIMARY KEY,
            Title VARCHAR(255) NOT NULL,
            Description TEXT NOT NULL,
            Status INTEGER NOT NULL,
            Difficulty INTEGER NOT NULL,
            PublisherId VARCHAR(255) NOT NULL,
            CreatedAt TIMESTAMP WITH TIME ZONE NOT NULL,
            UpdatedAt TIMESTAMP WITH TIME ZONE
        )");

        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Users (
            Id VARCHAR(255) PRIMARY KEY,
            Name VARCHAR(100) UNIQUE NOT NULL,
            Email VARCHAR(255) UNIQUE NOT NULL,
            CreatedAt TIMESTAMP WITH TIME ZONE NOT NULL,
            UpdatedAt TIMESTAMP WITH TIME ZONE
        )");

        var constraintExists = await connection.ExecuteScalarAsync<bool>(@"
            SELECT EXISTS (
                SELECT conname
                FROM pg_constraint
                WHERE contype = 'f'
                AND conname = 'fk_quest_publisher'
            );");

        if (!constraintExists)
        {
            await connection.ExecuteAsync(@"
                ALTER TABLE Quests
                ADD CONSTRAINT FK_Quest_Publisher
                FOREIGN KEY (PublisherId)
                REFERENCES Users(Id)");
        }
    }
}
