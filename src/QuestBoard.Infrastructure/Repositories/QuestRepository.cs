using System;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Database;

namespace QuestBoard.Infrastructure.Repositories;

public class QuestRepository : IQuestRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public QuestRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }}
