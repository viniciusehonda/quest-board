using System;
using System.Data;

namespace QuestBoard.Identity.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}