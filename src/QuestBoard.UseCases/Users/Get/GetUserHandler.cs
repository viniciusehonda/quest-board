using Ardalis.Result;
using Ardalis.SharedKernel;
using QuestBoard.Core;

namespace QuestBoard.UseCases;

public class GetUserHandler(IReadRepository<User> _repository)
: IQueryHandler<GetUserQuery, Result<UserDTO>>
{
  public async Task<Result<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    UserByIdSpec spec = new UserByIdSpec(request.userId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity == null) return Result.NotFound();

    return new UserDTO(entity.Id, entity.FirstName, entity.LastName, entity.Email);
  }
}
