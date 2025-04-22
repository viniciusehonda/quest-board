using System;
using System.Data;
using Dapper;

namespace QuestBoard.Infrastructure.TypeHandlers;

public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value;
        parameter.DbType = DbType.Guid;
    }

    public override Guid Parse(object value)
    {
        if (value == null || value == DBNull.Value)
        {
            return Guid.Empty;
        }

        if (value is string stringValue)
        {
            return Guid.Parse(stringValue);
        }

        return (Guid)value;
    }
}
