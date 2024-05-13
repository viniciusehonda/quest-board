using Ardalis.Result;
using Ardalis.SharedKernel;

namespace QuestBoard.UseCases;

public record GetUserQuery(Guid userId) : IQuery<Result<UserDTO>>;
